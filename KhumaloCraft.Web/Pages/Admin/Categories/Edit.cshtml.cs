using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;


namespace KhumaloCraft.Web.Pages.Admin.Categories
{
	public class EditModel : PageModel
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILogger<EditModel> _logger;
		public EditModel(IHttpClientFactory httpClientFactory, ILogger<EditModel> logger)
		{
			_httpClientFactory = httpClientFactory;
			_logger = logger;
		}

		[BindProperty]
		public CategoryDTO Category { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			var client = _httpClientFactory.CreateClient("BusinessAPI");
			var response = await client.GetAsync($"/api/categories/{id}");

			if (response.IsSuccessStatusCode)
			{
				var jsonResponse = await response.Content.ReadAsStringAsync();
				Category = JsonSerializer.Deserialize<CategoryDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			}

			if (Category == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var jsonCategory = JsonSerializer.Serialize(Category);
			_logger.LogInformation($"Sending JSON to API: {jsonCategory}");
			var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
			var client = _httpClientFactory.CreateClient("BusinessAPI");
			var response = await client.PutAsync($"/api/categories/{Category.CategoryId}", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToPage("/Admin/Categories/Index");
			}

			_logger.LogError($"Failed to update category. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
			ModelState.AddModelError(string.Empty, "Error updating category.");
			return Page();
		}
	}
}
