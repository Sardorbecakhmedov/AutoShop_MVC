using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;

namespace AutoShop.Data.Mocks;

public class MockCars : IAllCars
{
    private readonly ICarsCategory _carsCategory = new MockCategory();

    public IEnumerable<Car> GetFavCars { get; set; } = new List<Car>();

    public Car GetObjectCar(int carId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Car> GetCars =>
        new List<Car>
        {
            new Car 
            {
                Name = "Tesla Model S", 
                ShortDesc = "Fast car", 
                LongDesc = "Super fast car tesla",
                Img = @"\img\tesla.jpg",
                Price = 45000,
                IsFavourite = true,
                Available = true,
                Category = _carsCategory.AllCategories.Last()             
            },
            new Car
            {
                Name = "Fort Fiesta",
                ShortDesc = "Fast car",
                LongDesc = "Super fast car Ford fiesta",
                Img = @"\img\fiesta.jpg",
                Price = 15000,
                IsFavourite = true,
                Available = true,
                Category = _carsCategory.AllCategories.First()
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
                Category = _carsCategory.AllCategories.First()
            },
            new Car
            {
                Name = "Mercedes C class",
                ShortDesc = "Comfort cars",
                LongDesc = "Super fast car Mercedes c class",
                Img = @"\img\mercedes.jpg",
                Price = 65000,
                IsFavourite = true,
                Available = true,
                Category = _carsCategory.AllCategories.First()
            },
            new Car
            {
                Name = "Nissan leaf",
                ShortDesc = "Comfort cars",
                LongDesc = "Super fast car Mercedes c class",
                Img = @"\img\nissanLeaf.jpg",
                Price = 35000,
                IsFavourite = true,
                Available = true,
                Category = _carsCategory.AllCategories.Last()
            }
        };
}
