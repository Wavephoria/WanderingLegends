namespace WanderingLegends.Models;

public abstract class BaseAttributes
{
    public Random randomNumber = new Random();
    public string Name { get; init; }
    public int Protection { get; set; } = 0;
    public int MagicProtection { get; set; } = 0;
    public int Strength { get; set; } = 10;
    public int Life { get; set; }
    public int Level { get; set; } = 1;
    public int Range { get; set; } = 1;
    public int Initiative { get; set; } = 0;

    internal abstract string GetName();
}