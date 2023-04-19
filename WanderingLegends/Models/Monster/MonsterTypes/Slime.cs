using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Slime : Monster
{
    // Slimes are the basic enemy, low hp, low str, no initiative
    // Early enemy there for level up and some drops
    public override SlimeColor Color { get; init; }
    public override MonsterTypes MonsterType { get; init; }
    protected override int LifeLower { get; set; } = 10;
    protected override int LifeHigher { get; set; } = 19;
    public Slime(int level) : base(level)
    {
        Strength = Strength * Modifier / 2;
        Life = RandomHP() * Modifier;
        Color = RandomColor();
        Name = GetName();
        MonsterType = MonsterTypes.Slime;
    }

    internal override string GetName()
    {
        return $"{Color} {MonsterType}";
    }

    public override int ExperiencePoints(Hero hero)
    {
        int exp = 80 - (hero.Level * 10);
        if (exp < 5)
            return 5;
        return exp;
    }

    public override string EncounterText()
    {
        string[] strings = {
            "You hear something razzling in the bush!",
            "You see something slimey ahead",
            "What is that thing?!?!",
            "That one looks weak!!!",
            "Come on, not another one of these!"
        };
        int choice = randomNumber.Next(1, strings.Length);
        return strings[choice];
    }
}