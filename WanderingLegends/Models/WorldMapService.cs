using System.Runtime.CompilerServices;
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
            case "WB":
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
                if (randomNumber < 35)
                    return (null, encounter);
                if (randomNumber < 55)
                    return (new Snake(hero.Level), encounter);
                if (randomNumber < 85)
                    return (new Slime(hero.Level), encounter);
                if (randomNumber < 95)
                    return (new Troll(hero.Level), encounter);
                return (new Ogre(hero.Level), encounter);
            case "mountain":
                encounter = new Mountain();
                if (randomNumber < 10)
                    return (null, encounter);
                if (randomNumber < 50)
                    return (new Spider(hero.Level), encounter);
                if (randomNumber < 75)
                    return (new Goblin(hero.Level), encounter);
                if (randomNumber < 90)
                    return (new Gorilla(hero.Level), encounter);
                return (new Dragon(hero.Level), encounter);
            case "deep forest":
                encounter = new DeepForest();
                if (randomNumber < 20)
                    return (null, encounter);
                if (randomNumber < 45)
                    return (new Snake(hero.Level), encounter);
                if (randomNumber < 70)
                    return (new Spider(hero.Level), encounter);
                if (randomNumber < 90)
                    return (new Troll(hero.Level), encounter);
                return (new Ogre(hero.Level), encounter);
            case "water":
                encounter = new Water();
                return (null, encounter);
            case "grasslands":
                encounter = new Grasslands();
                if (randomNumber < 40)
                    return (null, encounter);
                if (randomNumber < 80)
                    return (new Slime(hero.Level), encounter);
                if (randomNumber < 90)
                    return (new Snake(hero.Level), encounter);
                if (randomNumber < 95)
                    return (new Wolf(hero.Level), encounter);
                return (new Skeleton(hero.Level), encounter);
            case "sandlands":
                encounter = new Sandlands();
                if (randomNumber < 20)
                    return (null, encounter);
                if (randomNumber < 30)
                    return (new Slime(hero.Level), encounter);
                if (randomNumber < 60)
                    return (new Wolf(hero.Level), encounter);
                if (randomNumber < 85)
                    return (new Dingo(hero.Level), encounter);
                return (new Skeleton(hero.Level), encounter);
            case "hills":
                encounter = new Hill();
                if (randomNumber < 15)
                    return (null, encounter);
                if (randomNumber < 50)
                    return (new Skeleton(hero.Level), encounter);
                if (randomNumber < 80)
                    return (new Goblin(hero.Level), encounter);
                if (randomNumber < 90)
                    return (new Ogre(hero.Level), encounter);
                return (new Gorilla(hero.Level), encounter);
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