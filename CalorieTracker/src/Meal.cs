namespace CalorieTracker;

public record Meal(long Id, string Name, params MealComponent[] Ingredients);

public record MealComponent(long Id, string? Name) {
    public required Protein Protein { get; init; }
    public required Carbohydrates Carbohydrates { get; init; }
    public required Fat Fat { get; init; }
    public required Alcohol Alcohol { get; init; }
}