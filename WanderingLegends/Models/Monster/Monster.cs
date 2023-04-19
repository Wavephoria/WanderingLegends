using WanderingLegends.Models.Encounters;
using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster;

public abstract class Monster : BaseAttributes
{
    public virtual SlimeColor Color { get; init; }
    public virtual string MonsterAttribute { get; init; } 
    public virtual MonsterTypes MonsterType { get; init; }
    protected virtual int LifeLower { get; set; } = 0;
    protected virtual int LifeHigher { get; set; } = 100;
    protected int Modifier { get; set; }
    public abstract int ExperiencePoints(Hero hero);
    public abstract string EncounterText();
    public Encounter encounter;

    protected Monster(int level)
    {
        int modifier = CheckModifier(level);
        Modifier = modifier;
    }

    private int CheckModifier(int level)
    {
        double modifier;
        if (level > 1)
        {
            modifier = level * 0.75;
        }
        else
            modifier = 1.0;

        return (int)Math.Round(modifier);
    }
    internal int RandomHP()
    {
        int life = randomNumber.Next(LifeLower, LifeHigher);
        return life;
    }
    internal SlimeColor RandomColor()
    {
        Array values = Enum.GetValues(typeof(SlimeColor));
        SlimeColor randomColor = (SlimeColor)values.GetValue(randomNumber.Next(values.Length))!;
        return randomColor;
    }
    internal string RandomAttributes(string attr)
    {
        string[] names = attr.Split(';');
        int choice = randomNumber.Next(1, names.Length);
        return names[choice];
    }
    public enum MonsterTypes
    {
        Slime, Snake, Troll, Ogre, Skeleton
    }

    public enum SlimeColor
    {
        Blue, Green, Red, White, Black, Purple, Orange, Golden, Silver, Teal
    }

    public enum MonsterAttributes
    {
        Dashing, Angry, Cute, Picky, Sneaky, Dark, Tough, Normal, Slender, Tiny
    }
}