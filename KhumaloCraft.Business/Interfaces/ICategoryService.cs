using KhumaloCraft.Shared.DTOs;

namespace KhumaloCraft.Business.Interfaces;

public interface ICategoryService
{
  Task<List<CategoryDTO>> GetAllCategories();
  Task<CategoryDTO?> GetCategoryById(int categoryId);
  Task AddCategory(CategoryDTO categoryDTO);
  Task UpdateCategory(CategoryDTO categoryDTO);
  Task DeleteCategory(int categoryId);
}
