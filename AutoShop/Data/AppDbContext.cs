using AutoShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<ShopCartItem> ShopCartItems { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
}