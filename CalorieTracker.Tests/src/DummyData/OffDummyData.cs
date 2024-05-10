using System;
using System.IO;

namespace CalorieTracker.Tests.DummyData;

public static class OffDummyData {
    private const string DummyDataPath = "src/DummyData/";
    private const string Extension = ".json";

    public static string DummyProduct() {
        return File.ReadAllText(GetPath("OffDummyProduct"));
    }

    private static string GetPath(string fileName) {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DummyDataPath, fileName + Extension);
    }
}