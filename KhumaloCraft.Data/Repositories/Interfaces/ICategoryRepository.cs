using KhumaloCraft.Data.Entities;

namespace KhumaloCraft.Data.Repositories.Interfaces;

public interface ICategoryRepository
{
  Task<List<Category>> GetAllCategoriesAsync();
  Task<Category?> GetCategoryByIdAsync(int categoryId);
  Task AddCategoryAsync(Category category);
  Task UpdateCategoryAsync(Category category);
  Task DeleteCategoryAsync(Category category);
  Task SaveChangesAsync();
}
