using CalorieTracker.Utils;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieTracker.Tests.Utils;

[TestClass]
[TestSubject(typeof(MealExtensions))]
public class MealExtensionsTests {
    private const int MacroAmount = 10;
    private static Meal meal;

    [TestInitialize]
    public static void TestInitialize(TestContext context) {
        var ingredients = new MealComponent[] {
            new(1, "Test1") {
                Protein = new Protein(MacroAmount),
                Carbohydrates = new Carbohydrates(MacroAmount),
                Fat = new Fat(MacroAmount),
                Alcohol = new Alcohol(MacroAmount)
            },
            new(2, "Test2") {
                Protein = new Protein(MacroAmount),
                Carbohydrates = new Carbohydrates(MacroAmount),
                Fat = new Fat(MacroAmount),
                Alcohol = new Alcohol(MacroAmount)
            }
        };

        meal = new Meal(1, "Test", ingredients);
    }

    [TestCleanup]
    public static void TestCleanup(TestContext context) {
        meal = null;
    }

    [TestMethod]
    public void GetMacrosReturnsAllMacros() {
        var macros = meal.GetMacros();

        Assert.AreEqual(8, macros.Count);
    }

    [TestMethod]
    public void TotalCaloriesReturnsSumOfAllMacros() {
        // This assumes that both dishes have the same amount of macros
        var proteinCalories = MacroAmount * MacroUtils.ProteinCaloriesPerGram;
        var carbohydratesCalories = MacroAmount * MacroUtils.CarbohydratesCaloriesPerGram;
        var fatCalories = MacroAmount * MacroUtils.FatCaloriesPerGram;
        var alcoholCalories = MacroAmount * MacroUtils.AlcoholCaloriesPerGram;

        var macroCalories = proteinCalories + carbohydratesCalories + fatCalories + alcoholCalories;
        var totalCalories = macroCalories * meal.Ingredients.Length;

        Assert.AreEqual(totalCalories, meal.TotalCalories());
    }
}