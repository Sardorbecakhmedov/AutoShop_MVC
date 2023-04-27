using AutoShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;

namespace AutoShop.Controllers;

public class ShopCartController : Controller
{
    private readonly IAllCars _iAllCars;
    private readonly ShopCartService _shopCart;

    public ShopCartController(IAllCars iAllCars, ShopCartService shopCart)
    {
        _iAllCars = iAllCars;
        _shopCart = shopCart;
    }

    public IActionResult ShowCart()
    {
        _shopCart.ListCartItems = _shopCart.GetShopCartItems();
        
        return View(_shopCart.ListCartItems);
    }

    public RedirectToActionResult AddToCart(int carId)
    {
        var car = _iAllCars.GetCars.FirstOrDefault(car => car.Id == carId);

        if (car != null)
        {
            _shopCart.AddShopCart(car);
        }

        return RedirectToAction(nameof(ShowCart));
    }


}