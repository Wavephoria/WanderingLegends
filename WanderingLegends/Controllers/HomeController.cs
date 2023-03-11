using Microsoft.AspNetCore.Mvc;

namespace WanderingLegends.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
}