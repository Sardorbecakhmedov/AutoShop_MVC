
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Data.Models;

public class ShopCartService
{
    public string ShopCartId { get; set; } = null!;
    public List<ShopCartItem> ListCartItems { get; set; } = null!;


    private readonly AppDbContext _context;
    public ShopCartService(AppDbContext context) => _context = context;


    public static ShopCartService GetShopCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        
        var context = services.GetService<AppDbContext>();

        var shopCartId = session.GetString("CartId") ??  Guid.NewGuid().ToString();

        session.SetString("CartId", shopCartId);

        return new ShopCartService(context) {  ShopCartId = shopCartId };
    }

    public void AddShopCart(Car car)
    {
        _context.ShopCartItems.Add(new ShopCartItem
        {
            ShopCartId = ShopCartId,
            Car = car,
            Price = car.Price
        });

        _context.SaveChanges();
    }

    public List<ShopCartItem> GetShopCartItems()
    {
        return _context.ShopCartItems.Where(id => id.ShopCartId == ShopCartId).Include(s=>s.Car).ToList();
    }
}