using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Troll : Monster
{
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Troll;
    protected override int LifeLower { get; set; } = 45;
    protected override int LifeHigher { get; set; } = 90;
    public Troll(int level) : base(level)
    {
        Strength *= Modifier * 2 + 10;
        Life = RandomHP() * Modifier;
        MonsterAttribute = RandomAttributes(TrollAttributes());
        Name = GetName();
    }

    private string TrollAttributes()
    {
        return "Fast;Acrobatic;Fearless;Dangerous";
    }
    internal override string GetName()
    {
        return $"{MonsterAttribute} {MonsterType}";
    }
        
    public override int ExperiencePoints(Hero hero)
    {
        int exp = 140 - (hero.Level * 10);
        if (exp < 15)
            return 15;
        return exp;
    }
        
    public override string EncounterText()
    {
        string[] strings = {
            "You hear something close to you, you look up and see...",
            "Whoooosh, you feel the air from a spear going past you in full speed",
            "Blimey, what is that thing?",
            "You hear a loud battlecry, you turn around and see..."
        };
        int choice = randomNumber.Next(0, strings.Length);
        return strings[choice];
    }
}