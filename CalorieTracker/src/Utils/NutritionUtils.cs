namespace CalorieTracker.Utils;

public static class NutritionUtils {
    private const float AlcoholDensityInGrams = 0.789f;

    /// <summary>
    ///     Returns the amount of alcohol in grams from the given percentage and volume.
    /// </summary>
    /// <param name="percentageAmount">Alcohol amount denominated in percent.</param>
    /// <param name="volume">The amount of liquid in milliliters.</param>
    /// <returns></returns>
    public static float GetAlcoholAmountInGramsFromPercentage(float percentageAmount, float volume = 100) {
        return volume * (percentageAmount / 100) * AlcoholDensityInGrams;
    }
}