using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Goblin : Monster
{
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Goblin;
    protected override int LifeLower { get; set; } = 55;
    protected override int LifeHigher { get; set; } = 80;
    public Goblin(int level) : base(level)
    {
        Strength *= Modifier + 20;
        Life = RandomHP() * Modifier;
        MonsterAttribute = RandomAttributes(GoblinAttributes());
        Name = GetName();
    }

    private string GoblinAttributes()
    {
        return "Tiny;Small;Precarious;Tinker;Pointy;Busy";
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
            "That one is so small, can it really be dangerous?",
            "It looks like that one is building a rocket.. Oh no, it's a rocket launcher...",
            "Nice googles!!",
            "Can I have that cool helmet?"
        };
        int choice = randomNumber.Next(0, strings.Length);
        return strings[choice];
    }
}