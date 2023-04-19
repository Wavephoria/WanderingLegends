using WanderingLegends.Models.Encounters;
using WanderingLegends.Models.Heroes;
using WanderingLegends.Models.Monster.MonsterTypes;
using WanderingLegends.Models.Monster;
using WanderingLegends.Views.WanderingLegends;

namespace WanderingLegends.Models;

public class WorldMapService
{
    public string[,] MapGrid { get; set; }
    public Random random = new Random();

    public WorldMapService()
    {
        // Making a world map with size of 64x64
        string[,] grid = GeneratingTheMap();
        MapGrid = grid;
    }

    private string[,] GeneratingTheMap()
    {
        string[,] grid = new string[64, 64];
        // Absolute path, should be relative path but can't get it to work
        string filepath = @"/Users/wavephoria/Library/CloudStorage/OneDrive-Personal/RiderProjects/WanderingLegends/WanderingLegends/wwwroot/map/WorldMapExcelCSV.csv";
        // string filepath = "/map/WorldMapExcelCSV.csv";
        string mapString = File.ReadAllText(filepath);
        string[] mapArray = mapString.Split(';', '\n');
        int x = 0;
        int y = 0;
        foreach (var line in mapArray)
        {
            if (line.Length > 1)
                grid[x, y] = line.Substring(0, 1);
            else
                grid[x, y] = line;
            y++;

            if (y == 64)
            {
                x++;
                y = 0;
            }
        }

        return grid;
    }

    internal string Name(string v)
    {
        switch (v)
        {
            case "F":
                return "Forest";
            case "M":
                return "Mountain";
            case "Q":
                return "Deep Forest";
            case "W":
                return "Water";
            case "G":
                return "Grasslands";
            case "S":
                return "Sandlands";
            case "H":
                return "Hills";
            case "C":
                return "Cave";
            case "T":
                return "Town";
            case "D":
                return "Dungeon";
            case "R":
                return "Road";
            default:
                return "Error";
        }
    }

    public (Monster.Monster, Encounter) CheckBiome(GameStartVM gameStart, int x, int y)
    {
        Encounter encounter;
        Hero hero = gameStart.hero;
        hero.X = x;
        hero.Y = y;
        string a = gameStart.worldMap.Name(gameStart.worldMap.MapGrid[x, y]);
        int randomNumber = random.Next(1, 101);
        switch (a.ToLower())
        {
            case "forest":
                encounter = new Forest();
                if (randomNumber < 25)
                    return (null, encounter);
                else if (randomNumber < 65)
                    return (new Slime(hero.Level), encounter);
                return (new Snake(hero.Level), encounter);
            case "mountain":
                encounter = new Mountain();
                if (randomNumber < 35)
                    return (null, encounter);
                return (new Ogre(hero.Level), encounter);
            case "deep forest":
                encounter = new DeepForest();
                if (randomNumber < 10)
                    return (null, encounter);
                else if (randomNumber < 65)
                    return (new Snake(hero.Level), encounter);
                return (new Ogre(hero.Level), encounter);
            case "water":
                return (null, null);
            case "grasslands":
                encounter = new Grasslands();
                if (randomNumber < 50)
                    return (null, encounter);
                else if (randomNumber < 55)
                    return (new Slime(hero.Level), encounter);
                else if (randomNumber < 60)
                    return (new Snake(hero.Level), encounter);
                else if (randomNumber < 65)
                    return (new Skeleton(hero.Level), encounter);
                return (new Ogre(hero.Level), encounter);
            case "sandlands":
                encounter = new Sandlands();
                if (randomNumber < 10)
                    return (null, encounter);
                return (new Skeleton(hero.Level), encounter);
            case "hills":
                encounter = new Hill();
                if (randomNumber < 50)
                    return (null, encounter);
                return (new Slime(hero.Level), encounter);
            case "cave":
                encounter = new Cave();
                return (null, encounter);
            case "town":
                encounter = new Town();
                return (null, encounter);
            case "dungeon":
                encounter = new Cave();
                return (null, encounter);
            case "road":
                encounter = new Road();
                if (randomNumber < 80)
                    return (null, encounter);
                return (new Slime(hero.Level), encounter);
        }

        return (null, null);
    }
}