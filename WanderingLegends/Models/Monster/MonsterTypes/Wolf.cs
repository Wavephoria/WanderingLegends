using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Wolf : Monster
{
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Wolf;
    protected override int LifeLower { get; set; } = 40;
    protected override int LifeHigher { get; set; } = 50;
    public Wolf(int level) : base(level)
    {
        Strength *= Modifier + 8;
        Life = RandomHP() * Modifier;
        MonsterAttribute = RandomAttributes(WolfAttributes());
        Name = GetName();
    }

    private string WolfAttributes()
    {
        return "WolfGang;Hairy;Drowling;Hungry;Terrifying;DogLike";
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
            "You feel something stalking you...",
            "You hear a loud growl from behind you...",
            "You see something in the distance, it looks like a dog!",
            "You look around, feeling you might have walked into something bad.."
        };
        int choice = randomNumber.Next(0, strings.Length);
        return strings[choice];
    }
}