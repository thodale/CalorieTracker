namespace CalorieTracker;

public record Dish(string Name, params Ingredient[] Ingredients)
{
    public Guid Id { get; } = Guid.NewGuid();
};