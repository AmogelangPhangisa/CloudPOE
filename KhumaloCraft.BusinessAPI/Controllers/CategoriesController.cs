using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Business.Interfaces;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace KhumaloCraft.BusinessAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllCategories()
    {
      var categories = await _categoryService.GetAllCategories();
      return Ok(categories);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
      var category = await _categoryService.GetCategoryById(id);
      if (category == null) return NotFound();
      return Ok(category);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCategory([FromBody] CategoryDTO categoryDTO)
    {
      await _categoryService.AddCategory(categoryDTO);
      return Ok("Category added successfully");
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
    {
      if (id != categoryDTO.CategoryId) return BadRequest("Category ID mismatch");

      await _categoryService.UpdateCategory(categoryDTO);
      return Ok("Category updated successfully");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
      await _categoryService.DeleteCategory(id);
      return Ok("Category deleted successfully");
    }
  }
}
