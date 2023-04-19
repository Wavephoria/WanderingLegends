using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Snake : Monster
{
    // Snakes have higher hp than slimes but will be around the same str and no initiative
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Snake;
    protected override int LifeLower { get; set; } = 21;
    protected override int LifeHigher { get; set; } = 34;
    public Snake(int level) : base(level)
    {
        Strength *= Modifier;
        Life = RandomHP() * Modifier;
        MonsterAttribute = RandomAttributes(SnakeAttributes());
        Name = GetName();
    }

    private string SnakeAttributes()
    {
        return "Slimey;Fearless;Sneaky;Bush;Cobra;Anaconda;Fast;Scary;Angry;Cute";
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
            "You hear something from the bush to your right!",
            "That one looks slimey!",
            "How is that one so big?",
            "Oh no! I am scared of snakes....",
            "You look so small, can I take you home?"
        };
        int choice = randomNumber.Next(1, strings.Length);
        return strings[choice];
    }
}