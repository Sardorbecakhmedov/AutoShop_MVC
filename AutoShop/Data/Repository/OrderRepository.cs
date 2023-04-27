using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;

namespace AutoShop.Data.Repository;

public class OrderRepository : IAllOrders
{
    private readonly AppDbContext _appDbContext;
    private readonly ShopCartService _shopCartService;

    public OrderRepository(AppDbContext appDbContext, ShopCartService shopCartService)
    {
        _appDbContext = appDbContext;
        _shopCartService = shopCartService;
    }


    public void CreateOrder(Order order)
    {
        order.CreatedDate = DateTime.Now;
        _appDbContext.Orders.Add(order);

        var listCars = _shopCartService.ListCartItems;

        foreach (var car in listCars)
        {
            var orderDetail = new OrderDetail
            {
                CarId = car.Id,
                OrderId  = order.Id,
                Price = car.Price,
            };

            _appDbContext.OrderDetails.Add(orderDetail);
        }

        _appDbContext.SaveChanges();
    }
}