using System.Text.Json;

namespace CalorieTracker.Utils;

public static class JsonElementExtensions {
    public static float GetFloatPropertyValue(this JsonElement element, string propertyName) {
        return element.TryGetProperty(propertyName, out var property) ? property.GetSingle() : 0;
    }

    public static string? GetStringPropertyValue(this JsonElement element, string propertyName) {
        return element.TryGetProperty(propertyName, out var property) ? property.GetString() : string.Empty;
    }
}