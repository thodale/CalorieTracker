using System.Text.Json;
using CalorieTracker.Utils;

namespace CalorieTracker.Database;

public class NutrimentData(JsonElement nutrimentsElement) {
    private const string GramUnit = "_100g";
    private const string MilliliterUnit = "_100ml";

    public float GetMacroAmount(string propertyName) {
        // Alcohol is given as a percentage as a float, so we need to handle it separately.
        if (propertyName == OpenFoodFactsUtils.AlcoholPropertyName)
            return nutrimentsElement.GetFloatPropertyValue(propertyName);

        var unit = GetFoodUnit(propertyName);
        return nutrimentsElement.GetFloatPropertyValue(propertyName + unit);
    }

    public string GetFoodUnit(string propertyName) {
        var unit = nutrimentsElement.GetStringPropertyValue(propertyName + "_unit");

        return unit switch {
            "g" => GramUnit,
            "ml" => MilliliterUnit,
            _ => throw new ArgumentException("Unknown unit type.")
        };
    }
}