using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Data.Repository;

public class CarRepository : IAllCars
{
    private readonly AppDbContext _appDbContext;

    public CarRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public IEnumerable<Car> GetCars => _appDbContext.Cars.Include(c => c.Category);
    public IEnumerable<Car> GetFavCars => _appDbContext.Cars.Where(t=>t.IsFavourite).Include(c => c.Category);
    public Car GetObjectCar(int carId) => _appDbContext.Cars.FirstOrDefault(i => i.Id == carId)!;

}