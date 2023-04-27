using AutoShop.Data.Models;

namespace AutoShop.Data.Interfaces;

public interface ICarsCategory
{
    IEnumerable<Category> AllCategories { get; }
}
