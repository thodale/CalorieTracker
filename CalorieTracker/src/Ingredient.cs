namespace CalorieTracker;

public record Ingredient(string Name)
{
    public Guid Id { get; } = Guid.NewGuid();
    public required Protein Protein { get; init; }
    public required Carbohydrates Carbohydrates { get; init; }
    public required Fat Fat { get; init; }
    public Alcohol Alcohol { get; init; }
};



