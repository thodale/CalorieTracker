namespace CalorieTracker.Database;

public interface IDatabase {
    Task<MealComponent> GetMealComponentById(long id);
}