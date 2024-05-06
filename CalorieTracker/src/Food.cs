namespace CalorieTracker;

public record Food(string Name, params Ingredient[] Ingredients)
{
    public Guid Id { get; } = Guid.NewGuid();
};