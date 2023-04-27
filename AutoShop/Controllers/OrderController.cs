using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.Controllers;

public class OrderController : Controller
{
    private readonly IAllOrders _iAllOrders;
    private readonly ShopCartService _shopCartService;

    public OrderController(IAllOrders iAllOrders, ShopCartService shopCartService)
    {
        _iAllOrders = iAllOrders;
        _shopCartService = shopCartService;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        _shopCartService.ListCartItems = _shopCartService.GetShopCartItems();

        if (_shopCartService.ListCartItems.Count <= 0)
        {
            ModelState.AddModelError("", "You must have goods");
        }

        if (ModelState.IsValid)
        {
            _iAllOrders.CreateOrder(order);
            return RedirectToAction(nameof(Completed));
        }

        return View(order);
    }


    public IActionResult Completed(Order order)
    {
        return View();
    }
}