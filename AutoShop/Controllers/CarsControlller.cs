using AutoShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;

namespace AutoShop.Controllers;

public class CarsController : Controller
{
    private readonly IAllCars _iAllCars;
    private readonly ICarsCategory _carsCategory;

    public CarsController(IAllCars iAllCars, ICarsCategory carsCategory)
    {
        _iAllCars = iAllCars;
        _carsCategory = carsCategory;
    }

    public IActionResult CarsList(string category)
    {
        IEnumerable<Car> cars;

        if (string.IsNullOrEmpty(category))
        {
            cars = _iAllCars.GetCars;
        }
        else if (string.Equals("ClassicCar", category, StringComparison.OrdinalIgnoreCase))
        {
            cars = _iAllCars.GetCars.Where(i => i.Category.CategoryName.Equals("ClassicCar")).OrderBy(d=> d.Id);
        }
        else
        {
            cars = _iAllCars.GetCars.Where(i => i.Category.CategoryName.Equals("ElectroCar")).OrderBy(d=> d.Id);
        }

        return View(cars);
    }
      
}