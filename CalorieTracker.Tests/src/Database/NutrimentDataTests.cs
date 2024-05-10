using System;
using System.Text.Json;
using CalorieTracker.Database;
using CalorieTracker.Tests.DummyData;
using CalorieTracker.Utils;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieTracker.Tests.Database;

[TestClass]
[TestSubject(typeof(NutrimentData))]
public class NutrimentDataTests {
    private NutrimentData nutrimentData;

    [TestInitialize]
    public void TestInitialize() {
        var jsonDocument = JsonDocument.Parse(OffDummyData.DummyProduct());
        var productJson = jsonDocument.RootElement.GetProperty(OpenFoodFactsUtils.ProductPropertyName);
        nutrimentData = new NutrimentData(productJson.GetProperty(OpenFoodFactsUtils.NutrimentsPropertyName));
    }

    [TestMethod]
    public void GetMacroAmountReturnsCorrectAmount() {
        var carbsAmount = nutrimentData.GetMacroAmount(OpenFoodFactsUtils.CarbohydratesPropertyName);
        var proteinAmount = nutrimentData.GetMacroAmount(OpenFoodFactsUtils.ProteinPropertyName);
        var fatAmount = nutrimentData.GetMacroAmount(OpenFoodFactsUtils.FatPropertyName);
        var alcoholAmount = nutrimentData.GetMacroAmount(OpenFoodFactsUtils.AlcoholPropertyName);

        Assert.AreEqual(57, carbsAmount);
        Assert.AreEqual(6.5, proteinAmount);
        Assert.AreEqual(31, fatAmount);
        Assert.AreEqual(0, alcoholAmount);
    }

    [TestMethod]
    public void GetFoodUnitReturnsCorrectUnit() {
        var carbsUnit = nutrimentData.GetFoodUnit(OpenFoodFactsUtils.CarbohydratesPropertyName);
        var proteinUnit = nutrimentData.GetFoodUnit(OpenFoodFactsUtils.ProteinPropertyName);
        var fatUnit = nutrimentData.GetFoodUnit(OpenFoodFactsUtils.FatPropertyName);

        Assert.AreEqual("_100g", carbsUnit);
        Assert.AreEqual("_100g", proteinUnit);
        Assert.AreEqual("_100g", fatUnit);

        Assert.ThrowsException<ArgumentException>(() =>
            nutrimentData.GetFoodUnit(OpenFoodFactsUtils.AlcoholPropertyName));
    }
}