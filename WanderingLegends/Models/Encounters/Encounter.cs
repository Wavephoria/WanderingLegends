namespace WanderingLegends.Models.Encounters;

public abstract class Encounter
{
    protected List<string> text;
    protected Random random = new();
    
    public string CheckEncounter(string a)
    {
        Encounter encounter;
        switch (a.ToLower())
        {
            case "cave":
                encounter = new Cave();
                return encounter.FlavourText();
            case "deep forest":
                encounter = new DeepForest();
                return encounter.FlavourText();
            case "forest":
                encounter = new Forest();
                return encounter.FlavourText();
            case "grasslands":
                encounter = new Grasslands();
                return encounter.FlavourText();
            case "hills":
                encounter = new Hill();
                return encounter.FlavourText();
            case "mountain":
                encounter = new Mountain();
                return encounter.FlavourText();
            case "road":
                encounter = new Road();
                return encounter.FlavourText();
            case "sandlands":
                encounter = new Sandlands();
                return encounter.FlavourText();
            case "town":
                encounter = new Town();
                return encounter.FlavourText();
            case "water":
                encounter = new Water();
                return encounter.FlavourText();
        }
        return "Cave";
    }
    public abstract string FlavourText();
}

public class Cave : Encounter
{
    public override string FlavourText()
    {
        text = new List<string>
        {
            "You look inside and it is so dark, you feel scared that something might show up to scare you!"
        };
        return text[0];
    }
}
public class DeepForest : Encounter
{
    public override string FlavourText()
    {
        text = new List<string>
        {
            "The thick forest surrounds you, cutting off all but the faintest traces of light",
            "The canopy overhead is so thick that the forest floor is almost in complete darkness",
            "The dense forest is home to a wide variety of flora and fauna, from towering trees to elusive creatures",
            "The shadows in the forest seem to hold secrets, tempting you to explore deeper",
            "The forest is alive with the sounds of birds, insects, and small animals",
            "The thick underbrush and winding paths make it easy to get lost in the forest",
            "The forest is filled with the scent of pine, moss, and damp earth",
            "The trees loom overhead, creating a sense of being watched by unseen eyes",
            "The forest is a place of mystery and magic, with hidden groves and ancient ruins",
            "The forest floor is covered in a thick layer of leaves and underbrush, muffling your footsteps as you explore"
        };
        return text[random.Next(0, text.Count)];
    }
}
public class Forest : Encounter
{
    public override string FlavourText()
    {
        text = new List<string>
        {
            "Sunlight filters through the canopy, casting shadows on the forest floor.",
            "The rustling of leaves and chirping of birds create a peaceful ambiance",
            "The forest is quiet, except for the occasional rustle of underbrush",
            "The earthy scent of pine fills the air as you wander through the woods",
            "The ground is covered in a soft bed of leaves, muffling your footsteps",
            "The winding path leads deeper into the mysterious forest",
            "The trees tower above you, creating a canopy of greenery",
            "Small animals scurry around in the underbrush, hidden from view",
            "The forest is a peaceful oasis, far from the hustle and bustle of civilization",
            "The woods are alive with the sounds of nature, from rustling leaves to chirping birds"
        };
        return text[random.Next(0, text.Count)];
    }
}
public class Grasslands : Encounter
{
    public override string FlavourText()
    {
        text = new List<string>
        {
            "You look around you and all you see is grass",
            "You see so many slimes around you",
            "You feel a sneeze coming, do you sense some allergy coming?",
            "You see a lot of yellow flowers, what a beautiful world!",
            "You feel the calmness of the area with bees flying around you",
            "The grasslands stretch out before you, a sea of waving grasses",
            "The sun beats down on the grassy expanse, creating a warm and inviting atmosphere",
            "The grasslands are home to a variety of wildlife, from grazing herds to swift predators",
            "The tall grasses rustle in the wind, creating a soothing sound",
            "The air is filled with the scent of wildflowers and fresh grass",
            "The grasslands seem endless, stretching out as far as the eye can see",
            "The wide open spaces of the grasslands are a refreshing change from the cramped forests",
            "The soft, rolling hills of the grasslands create a peaceful and serene landscape",
            "The grasslands are a perfect place to watch the sunrise or sunset",
            "The grasses sway gently in the breeze, creating a mesmerizing visual display"
        };
        return text[random.Next(0, text.Count)];
    }
}
public class Hill : Encounter
{
    public override string FlavourText()
    {
        text = new List<string>
        {
            "The hills stretch out before you, rising and falling like gentle waves",
            "The climb up the hills is steep, but the view from the top is worth it",
            "The hills are alive with the sound of wildlife, from chirping birds to scampering rodents",
            "The grassy hillsides are dotted with wildflowers, adding splashes of color to the landscape",
            "The hills offer a sweeping panorama of the surrounding countryside",
            "The rocky outcroppings and boulders make for challenging but rewarding climbs",
            "The hillsides are covered in short, sweet-smelling grasses that rustle in the breeze",
            "The hills are a place of peace and tranquility, far from the hustle and bustle of civilization",
            "The hills offer a chance to exercise and explore, with plenty of space to roam",
            "The hills are a perfect place to watch the clouds drift by or to stargaze at night"
        };
        return text[random.Next(0, text.Count)];
    }
}
public class Mountain : Encounter
{
    public override string FlavourText()
    {
        return "Cave";
    }
}
public class Road : Encounter
{
    public override string FlavourText()
    {
        return "Cave";
    }
}
public class Sandlands : Encounter
{
    public override string FlavourText()
    {
        return "Cave";
    }
}
public class Town : Encounter
{
    public override string FlavourText()
    {
        return "Cave";
    }
}
public class Water : Encounter
{
    public override string FlavourText()
    {
        return "You stand on a beach and look at the water";
    }
}