namespace CalorieTracker;

public abstract class Macro(float amount)
{
    public abstract string Name { get; }
    public float Amount { get; set; } = amount;
    public abstract int CaloriesPerGram { get; }
}

public class Protein(float amount) : Macro(amount)
{
    public override string Name => "Protein";
    public override int CaloriesPerGram => 4;
}

public class Carbohydrates(float amount) : Macro(amount)
{
    
    public override string Name => "Carbohydrates";
    public override int CaloriesPerGram => 4;
}

public class Fat(float amount) : Macro(amount)
{
    public override string Name => "Fat";
    public override int CaloriesPerGram => 9;
}

public class Alcohol(float amount) : Macro(amount)
{
    public override string Name => "Alcohol";
    public override int CaloriesPerGram => 7;
}