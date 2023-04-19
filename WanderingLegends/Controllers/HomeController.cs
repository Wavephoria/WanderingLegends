using Microsoft.AspNetCore.Mvc;
using WanderingLegends.Models.Heroes;

namespace WanderingLegends.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("/AboutMe")]
    public IActionResult AboutMe()
    {
        return View();
    }

    [HttpGet("/OtherProjects")]
    public IActionResult OtherProjects()
    {
        return View();
    }

    [HttpGet("/Boredtopia")]
    public IActionResult BoredTopia()
    {
        return View();
    }
}