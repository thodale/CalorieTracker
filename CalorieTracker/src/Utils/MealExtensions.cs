namespace CalorieTracker.Utils;

public static class MealExtensions {
    public static List<Macro> GetMacros(this Meal meal) {
        return meal.Ingredients.SelectMany(i => new Macro[] {
            i.Protein,
            i.Carbohydrates,
            i.Fat,
            i.Alcohol
        }).ToList();
    }

    public static int TotalCalories(this Meal meal) {
        return meal.GetMacros().Sum(m => m.TotalCalories());
    }
}