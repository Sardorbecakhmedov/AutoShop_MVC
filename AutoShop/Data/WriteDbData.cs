using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Data;

public class WriteDbData
{
    public static void Initial(AppDbContext context)
    {
        if (!context.Categories.Any())
        {
            context.Categories.AddRange(GetCategories.Select(c=>c.Value));
        }

        if (!context.Cars.Any())
        {
            context.Cars.AddRange(
                new Car
                {
                    Name = "Tesla Model S",
                    ShortDesc = "Fast car",
                    LongDesc = "Super fast car tesla",
                    Img = @"\img\tesla.jpg",
                    Price = 45000,
                    IsFavourite = true,
                    Available = true,
                    Category = GetCategories["ElectroCar"]
                },
                new Car
                {
                    Name = "Fort Fiesta",
                    ShortDesc = "Fast car",
                    LongDesc = "Super fast car Ford fiesta",
                    Img = @"\img\fiesta.jpg",
                    Price = 15000,
                    IsFavourite = false,
                    Available = true,
                    Category = GetCategories["ClassicCar"]
                },
                new Car
                {
                    Name = "BMW X5",
                    ShortDesc = "Sport car",
                    LongDesc = "Super fast car bmw",
                    Img = @"\img\bmw.jpg",
                    Price = 55000,
                    IsFavourite = true,
                    Available = true,
                    Category = GetCategories["ClassicCar"]
                },
                new Car
                {
                    Name = "Mercedes C class",
                    ShortDesc = "Comfort cars",
                    LongDesc = "Super fast car Mercedes c class",
                    Img = @"\img\mercedes.jpg",
                    Price = 65000,
                    IsFavourite = false,
                    Available = true,
                    Category = GetCategories["ClassicCar"]
                },
                new Car
                {
                    Name = "Nissan leaf",
                    ShortDesc = "Comfort cars",
                    LongDesc = "Super fast car Mercedes c class",
                    Img = @"\img\nissanLeaf.jpg",
                    Price = 35000,
                    IsFavourite = false,
                    Available = true,
                    Category = GetCategories["ElectroCar"]
                },
                new Car
                {
                    Name = "Zaparoj X",
                    ShortDesc = "Super comfort cars",
                    LongDesc = "Super fast car Zaparoj c class",
                    Img = @"\img\zaparoj.jpg",
                    Price = 65000,
                    IsFavourite = true,
                    Available = true,
                    Category = GetCategories["ClassicCar"]
                }

                );
        }

        context.SaveChanges();
    }

    private static Dictionary<string, Category>? _categories;
    public static Dictionary<string, Category> GetCategories
    {
        get
        {
            if (_categories != null) 
                return _categories;

            var list = new List<Category>
            {
                new() { CategoryName = "ElectroCar", Description = "Super car" },
                new() { CategoryName = "ClassicCar", Description = "Classic car" }
            };

            _categories = new Dictionary<string, Category>();

            foreach (var el in list)
                _categories.Add(el.CategoryName, el);

            return _categories;
        }
    }

}