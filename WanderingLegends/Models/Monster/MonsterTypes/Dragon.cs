using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Dragon : Monster
{
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Dragon;
    protected override int LifeLower { get; set; } = 100;
    protected override int LifeHigher { get; set; } = 250;
    public Dragon(int level) : base(level)
    {
        Strength *= Modifier * 4;
        Life = RandomHP() * Modifier;
        MonsterAttribute = RandomAttributes(DragonAttributes());
        Name = GetName();
    }

    private string DragonAttributes()
    {
        return "Black;White;FireBreathing;Enormous;Graceful;Elegant;Pretty;Golden;Furious";
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
            "That is one beautiful dragon but it doesn't look happy to see me...",
            "Looks like a huge shadow over there...",
            "Is this the end for me?",
            "It is getting hotter by the second..."
        };
        int choice = randomNumber.Next(0, strings.Length);
        return strings[choice];
    }
}