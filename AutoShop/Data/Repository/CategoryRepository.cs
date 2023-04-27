using AutoShop.Data.Interfaces;
using AutoShop.Data.Models;

namespace AutoShop.Data.Repository;

public class CategoryRepository : ICarsCategory
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext appDbContext) =>  _context = appDbContext;

    public IEnumerable<Category> AllCategories => _context.Categories;
}