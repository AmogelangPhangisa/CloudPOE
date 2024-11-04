using KhumaloCraft.Business.Interfaces;
using KhumaloCraft.Data.Entities;
using KhumaloCraft.Data.Repositories.Interfaces;
using KhumaloCraft.Shared.DTOs;

namespace KhumaloCraft.Business.Services;

public class CategoryService : ICategoryService
{
  private readonly ICategoryRepository _categoryRepository;

  public CategoryService(ICategoryRepository categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  public async Task<List<CategoryDTO>> GetAllCategories()
  {
    var categories = await _categoryRepository.GetAllCategoriesAsync();
    return categories.Select(c => new CategoryDTO
    {
      CategoryId = c.CategoryId,
      CategoryName = c.CategoryName
    }).ToList();
  }

  public async Task<CategoryDTO?> GetCategoryById(int categoryId)
  {
    var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
    if (category == null) return null;

    return new CategoryDTO
    {
      CategoryId = category.CategoryId,
      CategoryName = category.CategoryName
    };
  }

  public async Task AddCategory(CategoryDTO categoryDTO)
  {
    var category = new Category
    {
      CategoryName = categoryDTO.CategoryName
    };

    await _categoryRepository.AddCategoryAsync(category);
    await _categoryRepository.SaveChangesAsync();
  }

  public async Task UpdateCategory(CategoryDTO categoryDTO)
  {
    var category = await _categoryRepository.GetCategoryByIdAsync(categoryDTO.CategoryId);
    if (category == null) return;

    category.CategoryName = categoryDTO.CategoryName;

    await _categoryRepository.UpdateCategoryAsync(category);
    await _categoryRepository.SaveChangesAsync();
  }

  public async Task DeleteCategory(int categoryId)
  {
    var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
    if (category == null) return;

    await _categoryRepository.DeleteCategoryAsync(category);
    await _categoryRepository.SaveChangesAsync();
  }
}
