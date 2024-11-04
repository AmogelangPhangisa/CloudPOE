using System.Text;
using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Categories
{
  public class CreateModel : PageModel
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public CreateModel(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    [BindProperty]
    public CategoryDTO Category { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var jsonCategory = JsonSerializer.Serialize(Category);
      var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");

      var client = _httpClientFactory.CreateClient("BusinessAPI");
      var response = await client.PostAsync("/api/categories", content);

      if (response.IsSuccessStatusCode)
      {
        return RedirectToPage("/Admin/Categories/Index");
      }

      ModelState.AddModelError(string.Empty, "Error creating category.");
      return Page();
    }
  }
}
