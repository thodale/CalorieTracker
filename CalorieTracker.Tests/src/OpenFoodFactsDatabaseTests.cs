using System.Net.Http;
using System.Threading.Tasks;
using CalorieTracker.Tests.DummyData;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieTracker.Tests;

[TestClass]
[TestSubject(typeof(OpenFoodFactsDatabase))]
public class OpenFoodFactsDatabaseTests {
    private const long Id = 3045140105502;
    private HttpClient mockHttpClient;

    [TestInitialize]
    public void TestInitialize() {
        var fakeHttpMessageHandler = new FakeHttpMessageHandler(OffDummyData.DummyProduct());

        mockHttpClient = new HttpClient(fakeHttpMessageHandler);
    }


    [TestMethod]
    public async Task GetMealComponentByIdReturnsMealComponent() {
        var database = new OpenFoodFactsDatabase(mockHttpClient);

        var mealComponent = await database.GetMealComponentById(Id);

        Assert.IsNotNull(mealComponent);
    }

    [TestMethod]
    public async Task GetMealComponentByIdReturnsCorrectMealComponentData() {
        var database = new OpenFoodFactsDatabase(mockHttpClient);

        var mealComponent = await database.GetMealComponentById(Id);

        Assert.AreEqual("Milka Lait Alpin", mealComponent.Name);
        Assert.AreEqual(Id, mealComponent.Id);
        Assert.AreEqual(6.5, mealComponent.Protein.Amount);
        Assert.AreEqual(57, mealComponent.Carbohydrates.Amount);
        Assert.AreEqual(31, mealComponent.Fat.Amount);
        Assert.AreEqual(0, mealComponent.Alcohol.Amount);
    }
}