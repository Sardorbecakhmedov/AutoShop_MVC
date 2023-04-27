using AutoShop.Data.Models;

namespace AutoShop.Data.Interfaces;

public interface IAllCars
{
    IEnumerable<Car> GetCars { get; }
    IEnumerable<Car> GetFavCars { get;  }
    Car GetObjectCar(int carId);
}
