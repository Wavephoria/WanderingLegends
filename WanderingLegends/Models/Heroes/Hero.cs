namespace WanderingLegends.Models.Heroes;

public class Hero : BaseAttributes
{
    public int StartingLife { get; set; }
    public HeroClasses HeroClass { get; init; }
    // public Elements Element { get; set; }
    public int FocusPercentage { get; set; }
    public int ExperiencePoints { get; set; }
        
    // Position and Coordinates
    public int[,] Position = new int[64, 64];
    public int X { get; set; } = 45;
    public int Y { get; set; } = 15;
    public int StartPosition { get; private set; }
        
    // Items and Equipment
    // public Backpack Backpack;
    // public Pouch Pouch;
    // // Armor items
    // public Armor Armor { get; set; }
    // // Weapon items
    public WorldMapService worldMap;

    public Hero()
    {
        WorldMapService worldMap = new WorldMapService();
        StartPosition = Position[X, Y];
        Name = GetName();
        Level = 1;
        HeroClass = HeroClasses.Adventurer;
        Life = randomNumber.Next(100, 151);
        StartingLife = Life;
        // Backpack = new Backpack($"{Name}s backpack");
        // Backpack.open.Add(new Item("Napkins"));
        // Pouch = new Pouch();
        Initiative = randomNumber.Next(50, 101);
        FocusPercentage = 100;
    }
    internal override string GetName()
    {
        string listOfMale = "Jeremiah;Abraham;Douglas;Edgar;Jonathan;Marcus;Benjamin;Sylvester;David;Jacob";
        string listOfFemale = "Maria;Jenny;Johanna;Angelina;Sarah;Michelle;Buffy";
        string[] names;
        if (randomNumber.Next(1, 3) == 1)
            names = listOfMale.Split(';');
        else
            names = listOfFemale.Split(';');
        return names[randomNumber.Next(1, names.Length)];
    }
    
    public enum HeroClasses
    {
        Wizard, Berserker, Shaman, WitchDoctor, Holy, Undertaker, Adventurer
    }
    enum Elements
    {
        none, fire, ice, thunder, water, wind, dark, light
    }
    public void LevelUp()
    {
        Level++;
        ExperiencePoints -= 100;
        Strength += randomNumber.Next(1, 4);
        Protection += randomNumber.Next(0, 4);
        StartingLife += 10;
        Life = StartingLife;
        if (ExperiencePoints >= 100)
            LevelUp();
    }
}