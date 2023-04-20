using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Gorilla : Monster
{
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Gorilla;
    protected override int LifeLower { get; set; } = 90;
    protected override int LifeHigher { get; set; } = 120;
    public Gorilla(int level) : base(level)
    {
        Strength *= Modifier * 3;
        Life = RandomHP() * Modifier;
        MonsterAttribute = RandomAttributes(GorillaAttributes());
        Name = GetName();
    }

    private string GorillaAttributes()
    {
        return "Huge;Towering;Gigantic;Angry;Menacing;Bouldering;Apey;Funky;Grumpy;Hungry";
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
            "You see something big, hairy and strong right in front of you..",
            "You hear something strange, like someone getting ready to confront you with full force..",
            "You see banana peels on the ground, could this be?",
            "What? Is that Donkey Kong?"
        };
        int choice = randomNumber.Next(0, strings.Length);
        return strings[choice];
    }
}