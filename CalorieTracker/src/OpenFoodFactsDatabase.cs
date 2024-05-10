using System.Text.Json;
using CalorieTracker.Database;
using CalorieTracker.Utils;

namespace CalorieTracker;

public class OpenFoodFactsDatabase : IDatabase {
    private const string HeaderValue = "Calorie Tracker/0.1 (www.github.com/thodale/CalorieTracker)";
    private const string HeaderName = "User-Agent";

    private readonly HttpClient client;
    private readonly Uri endpoint = new("https://world.openfoodfacts.org");

    public OpenFoodFactsDatabase(HttpClient client) {
        this.client = client;
        client.DefaultRequestHeaders.Add(HeaderName, HeaderValue);
    }

    /// <summary>
    ///     Given a barcode, retrieves the meal component from the OpenFoodFacts database.
    /// </summary>
    public async Task<MealComponent> GetMealComponentById(long barcode) {
        var productData = await GetProductFromDatabase(barcode);
        return ParseProductData(productData);
    }

    private static MealComponent ParseProductData(string productData) {
        var jsonDocument = JsonDocument.Parse(productData);

        var productJson = jsonDocument.RootElement.GetProperty(OpenFoodFactsUtils.ProductPropertyName);
        var productName = productJson.GetStringPropertyValue(OpenFoodFactsUtils.ProductNamePropertyName);
        var productId = ParseId(productJson.GetStringPropertyValue(OpenFoodFactsUtils.ProductIdPropertyName));
        var nutrimentsData = new NutrimentData(productJson.GetProperty(OpenFoodFactsUtils.NutrimentsPropertyName));

        return ParseNutrimentData(nutrimentsData, productId, productName);
    }

    private static MealComponent ParseNutrimentData(NutrimentData nutrimentData, long productId, string? productName) {
        var carbohydrates = nutrimentData.GetMacroAmount(OpenFoodFactsUtils.CarbohydratesPropertyName);
        var protein = nutrimentData.GetMacroAmount(OpenFoodFactsUtils.ProteinPropertyName);
        var fat = nutrimentData.GetMacroAmount(OpenFoodFactsUtils.FatPropertyName);
        var alcohol = nutrimentData.GetMacroAmount(OpenFoodFactsUtils.AlcoholPropertyName);

        // Alcohol is always given as a percentage, so we need to convert it to grams.
        var alcoholInGrams = NutritionUtils.GetAlcoholAmountInGramsFromPercentage(alcohol);

        return new MealComponent(productId, productName) {
            Protein = new Protein(protein),
            Carbohydrates = new Carbohydrates(carbohydrates),
            Fat = new Fat(fat),
            Alcohol = new Alcohol(alcoholInGrams)
        };
    }

    private static long ParseId(string? productId) {
        if (!long.TryParse(productId, out var parsedId))
            throw new Exception("Failed to parse product id. Expected an int64.");

        return parsedId;
    }

    private async Task<string> GetProductFromDatabase(long barcode) {
        var response = await client.GetAsync($"{endpoint}/api/v0/product/{barcode}.json");

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Failed to retrieve product data: {response.StatusCode}");

        return await response.Content.ReadAsStringAsync();
    }
}