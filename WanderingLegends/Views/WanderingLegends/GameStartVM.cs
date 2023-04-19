using WanderingLegends.Models;
using WanderingLegends.Models.Encounters;
using WanderingLegends.Models.Heroes;
using WanderingLegends.Models.Monster;

namespace WanderingLegends.Views.WanderingLegends;

public class GameStartVM
{
    public Hero hero { get; set; }
    public WorldMapService worldMap { get; set; }
    public Encounter encounter { get; set; }
    public Monster monster { get; set; }
}