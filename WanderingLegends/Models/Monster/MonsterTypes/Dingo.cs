using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Dingo : Monster
{
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Dingo;
    protected override int LifeLower { get; set; } = 40;
    protected override int LifeHigher { get; set; } = 60;
    public Dingo(int level) : base(level)
    {
        Strength *= Modifier + 10;
        Life = RandomHP() * Modifier;
        MonsterAttribute = RandomAttributes(DingoAttributes());
        Name = GetName();
    }

    private string DingoAttributes()
    {
        return "Slinky;Teal;Wild;Hungry;Stalking";
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
            "Is that really a dog?",
            "That one looks really hungry..."
        };
        int choice = randomNumber.Next(0, strings.Length);
        return strings[choice];
    }
}