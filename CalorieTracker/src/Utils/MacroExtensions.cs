namespace CalorieTracker.Utils;

public static class MacroExtensions
{
    public static int TotalCalories(this Macro macro)
    {
        return (int)(macro.Amount * macro.CaloriesPerGram);
    }
}