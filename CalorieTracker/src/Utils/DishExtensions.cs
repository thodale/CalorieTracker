namespace CalorieTracker.Utils;

public static class DishExtensions
{
    public static IEnumerable<Macro> GetMacros(this Dish dish)
    {
        return dish.Ingredients.SelectMany(i => new Macro[] { i.Protein, i.Carbohydrates, i.Fat, i.Alcohol });
    }
    
    public static int TotalCalories(this Dish dish)
    {
        return dish.GetMacros().Sum(m => m.TotalCalories());
    }
}