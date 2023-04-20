using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Models.Monster.MonsterTypes;

public class Ogre : Monster
{
    // Ogre will be the first real challenge before meeting those early bosses
    // Very high hp and high str, will have enough initiative be sometimes be able to hit before hero
    public override string MonsterAttribute { get; init; }
    public override MonsterTypes MonsterType { get; init; } = MonsterTypes.Ogre;
    protected override int LifeLower { get; set; } = 55;
    protected override int LifeHigher { get; set; } = 110;
    public Ogre(int level) : base(level)
    {
        Strength *= Modifier * 3;
        Life = RandomHP();
        MonsterAttribute = RandomAttributes(OgreAttributes());
        Name = GetName();
    }

    private string OgreAttributes()
    {
        return "Tiny;Gigantic;Strong;Bouldering;Shadowing;Big;Mama;Scary;Dangerous;Alpha;Omega;Fearful";
    }
    internal override string GetName()
    {
        return $"{MonsterAttribute} {MonsterType}";
    }
        
    public override int ExperiencePoints(Hero hero)
    {
        int exp = 220 - (hero.Level * 10);
        if (exp < 20)
            return 20;
        return exp;

    }
    public override string EncounterText()
    {
        string[] strings = {
            "Oh my, you are huge!",
            "Can you please not hurt me...?",
            "You look like the other thing I killed 5 seconds ago, just smaller!",
            "You see a big shadow looming over your head, you turn around and see.....",
            "You see someone trying to hide behind a tree, too bad he is so big that the tree looks like it is the one hiding"
        };
        int choice = randomNumber.Next(0, strings.Length);
        return strings[choice];
    }
}