using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;

namespace AutoShop.Data.Mocks;

public class MockCategory : ICarsCategory
{
    public IEnumerable<Category> AllCategories =>
        new List<Category>
        {
            new Category{ CategoryName = "ElectroCar", Description = "Super car" },
            new Category{ CategoryName = "ClassicCar", Description = "Classic car" }
        };
}
