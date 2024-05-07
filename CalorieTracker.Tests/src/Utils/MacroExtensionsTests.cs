using CalorieTracker.Utils;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieTracker.Tests.Utils;

[TestClass]
[TestSubject(typeof(MacroExtensions))]
public class MacroExtensionsTests {

    [TestMethod]
    public void TestTotalCalories() {
        const int amount = 10;

        var fat = new Fat(amount);
        var alcohol = new Alcohol(amount);
        var protein = new Protein(amount);
        var carbohydrates = new Carbohydrates(amount);

        Assert.AreEqual(40, protein.TotalCalories());
        Assert.AreEqual(40, carbohydrates.TotalCalories());
        Assert.AreEqual(70, alcohol.TotalCalories());
        Assert.AreEqual(90, fat.TotalCalories());
    }
}