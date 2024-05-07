using CalorieTracker.Utils;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieTracker.Tests.Utils;

[TestClass]
[TestSubject(typeof(DishExtensions))]
public class DishExtensionsTests {
    private const int MacroAmount = 10;
    private static Dish dish;

    [TestInitialize]
    public static void TestInitialize(TestContext context) {
        var ingredients = new Ingredient[] {
            new("Test1") {
                Protein = new Protein(MacroAmount),
                Carbohydrates = new Carbohydrates(MacroAmount),
                Fat = new Fat(MacroAmount),
                Alcohol = new Alcohol(MacroAmount)
            },
            new("Test2") {
                Protein = new Protein(MacroAmount),
                Carbohydrates = new Carbohydrates(MacroAmount),
                Fat = new Fat(MacroAmount),
                Alcohol = new Alcohol(MacroAmount)
            }
        };

        dish = new Dish("Test", ingredients);
    }

    [TestCleanup]
    public static void TestCleanup(TestContext context) {
        dish = null;
    }

    [TestMethod]
    public void GetMacrosReturnsAllMacros() {
        var macros = dish.GetMacros();

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
        var totalCalories = macroCalories * dish.Ingredients.Length;

        Assert.AreEqual(totalCalories, dish.TotalCalories());
    }
}