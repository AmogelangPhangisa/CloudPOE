using Microsoft.EntityFrameworkCore;
using KhumaloCraft.Data.Data;
using KhumaloCraft.Data.Entities;
using KhumaloCraft.Data.Repositories.Interfaces;

namespace KhumaloCraft.Data.Repositories.Implementations;

public class CategoryRepository : ICategoryRepository
{
  private readonly ApplicationDbContext _dbContext;

  public CategoryRepository(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<List<Category>> GetAllCategoriesAsync()
  {
    return await _dbContext.Categories.ToListAsync();
  }

  public async Task<Category?> GetCategoryByIdAsync(int categoryId)
  {
    return await _dbContext.Categories.FindAsync(categoryId);
  }

  public async Task AddCategoryAsync(Category category)
  {
    await _dbContext.Categories.AddAsync(category);
  }

  public Task UpdateCategoryAsync(Category category)
  {
    _dbContext.Categories.Update(category);

    return Task.CompletedTask;
  }

  public Task DeleteCategoryAsync(Category category)
  {
    _dbContext.Categories.Remove(category);

    return Task.CompletedTask;
  }

  public async Task SaveChangesAsync()
  {
    await _dbContext.SaveChangesAsync();
  }
}
