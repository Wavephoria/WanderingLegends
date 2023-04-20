using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Spider : Monster
{
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Spider;
    protected override int LifeLower { get; set; } = 25;
    protected override int LifeHigher { get; set; } = 40;
    public Spider(int level) : base(level)
    {
        Strength *= Modifier + 3;
        Life = RandomHP() * Modifier;
        MonsterAttribute = RandomAttributes(SpiderAttributes());
        Name = GetName();
    }

    private string SpiderAttributes()
    {
        return "Hairy;Poisonous;Tiny;Googly;Petite";
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
            "Spidey Spidey Spidey",
            "Big and hairy spider is right in front of you..",
            "That one looks deadly...",
            "Is it poisonous?"
        };
        int choice = randomNumber.Next(0, strings.Length);
        return strings[choice];
    }
}