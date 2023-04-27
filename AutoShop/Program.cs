using AutoShop.Data;
using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;
using AutoShop.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutoShop;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();


        var addDbContext = builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite("Data source = Autoshop.db");
        });

        builder.Services.AddTransient<IAllCars, CarRepository>();
        builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
        builder.Services.AddTransient<IAllOrders, OrderRepository>();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped(ShopCartService.GetShopCart);

        
        builder.Services.AddMvc();

        builder.Services.AddSession();
        builder.Services.AddMemoryCache();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseSession();

        using ( var scope = app.Services.CreateScope() )
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            WriteDbData.Initial(context);
        }


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

}