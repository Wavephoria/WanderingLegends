using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Skeleton : Monster
{
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Skeleton;
    protected override int LifeLower { get; set; } = 35;
    protected override int LifeHigher { get; set; } = 64;
    public Skeleton(int level) : base(level)
    {
        Strength *= Modifier;
        Life = RandomHP() * Modifier;
        MonsterAttribute = RandomAttributes(SkeletonAttributes());
        Name = GetName();
    }

    private string SkeletonAttributes()
    {
        return "Boney;Bony;Wilfredo;Bono;Skelly;Undead;Unjust;Dry;Winnie;Starving;Dead";
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
            "It looks like you are already dead, why are you still here?",
            "You see something in the distance, it looks very dead....",
            "Do you want some of my food, ey?",
            "A skeleton.... How??!?",
            "You back to your grave, you pathetic thing!"
        };
        int choice = randomNumber.Next(1, strings.Length);
        return strings[choice];
    }
}