using CalorieTracker.Utils;

namespace CalorieTracker;

public abstract class Macro(float amount = 0) {
    public abstract string Name { get; }
    public float Amount { get; set; } = amount;
    public abstract int CaloriesPerGram { get; }
}

public class Protein(float amount = 0) : Macro(amount) {
    public override string Name => "Protein";
    public override int CaloriesPerGram => MacroUtils.ProteinCaloriesPerGram;
}

public class Carbohydrates(float amount = 0) : Macro(amount) {
    public override string Name => "Carbohydrates";
    public override int CaloriesPerGram => MacroUtils.CarbohydratesCaloriesPerGram;
}

public class Fat(float amount = 0) : Macro(amount) {
    public override string Name => "Fat";
    public override int CaloriesPerGram => MacroUtils.FatCaloriesPerGram;
}

public class Alcohol(float amount = 0) : Macro(amount) {
    public override string Name => "Alcohol";
    public override int CaloriesPerGram => MacroUtils.AlcoholCaloriesPerGram;
}