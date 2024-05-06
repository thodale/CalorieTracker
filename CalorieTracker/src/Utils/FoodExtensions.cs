namespace CalorieTracker.Utils;

public static class FoodExtensions
{
    public static IEnumerable<Macro> GetMacros(this Food food)
    {
        return food.Ingredients.SelectMany(i => new Macro[] { i.Protein, i.Carbohydrates, i.Fat, i.Alcohol });
    }
    
    public static int TotalCalories(this Food food)
    {
        return food.GetMacros().Sum(m => m.TotalCalories());
    }
}