using AutoShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoShop.Data.Interfaces;

namespace AutoShop.Controllers;

public class HomeController : Controller
{
    private readonly IAllCars _allCars;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IAllCars allCars)
    {
        _logger = logger;
        _allCars = allCars;
    }

    public IActionResult Index()
    {
        var allCarsIsFav = _allCars.GetFavCars.ToList();

        return View(allCarsIsFav);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}