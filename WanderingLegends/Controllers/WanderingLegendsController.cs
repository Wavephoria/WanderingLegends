using Microsoft.AspNetCore.Mvc;
using WanderingLegends.Models;
using WanderingLegends.Models.Monster;
using WanderingLegends.Models.Heroes;
using WanderingLegends.Views.WanderingLegends;

namespace WanderingLegends.Controllers;

public class WanderingLegendsController : Controller
{
    private static HeroService _heroService = new();
    private static GameStartVM _gameStartVm = new();
    
    private static Monster _monster;
    [HttpGet("/Main")]
    public IActionResult Main()
    {
        return View();
    }
    [HttpGet("/Main/Start")]
    public IActionResult GameStart()
    {
        _gameStartVm.hero = _heroService.GeneratingNewHero();
        _gameStartVm.worldMap =  new WorldMapService();
        return View(_gameStartVm);
    }
    [HttpGet("/Main/Exploring")]
    public IActionResult ExploringWorld()
    {
        return View(_gameStartVm);
    }
    [HttpGet("/Main/Encounter")]
    public IActionResult Encounter(int x, int y)
    {
        var (monster, encounter) = _gameStartVm.worldMap.CheckBiome(_gameStartVm, x, y);
        _gameStartVm.encounter = encounter;
        _monster = monster;
        if (monster != null)
            return RedirectToAction(nameof(Fight));
        return View(_gameStartVm);
    }
    [HttpGet("/Main/Fight")]
    public IActionResult Fight()
    {
        GameStartVM fightVm = _gameStartVm;
        fightVm.monster = _monster;
        fightVm.hero = _gameStartVm.hero;
        return View(fightVm);
    }

    [HttpGet("/Main/Fight/BattleEvaluation")]
    public IActionResult BattleEvaluation()
    {
        GameStartVM fightVm = _gameStartVm;
        fightVm.monster = _monster;
        fightVm.hero = _gameStartVm.hero;
        _heroService.BattlingEnemy(fightVm);
        return View(fightVm);
    }
}