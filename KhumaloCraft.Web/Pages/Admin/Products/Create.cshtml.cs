using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using KhumaloCraft.Shared.DTOs;

namespace KhumaloCraft.Web.Pages.Admin.Products
{
	public class CreateModel : PageModel
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CreateModel(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[BindProperty]
		public ProductDTO Product { get; set; }
		public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
		public async Task<IActionResult> OnGetAsync()
		{
			await LoadCategoriesAsync();

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				await LoadCategoriesAsync();
				return Page();
			}

			var jsonProduct = JsonSerializer.Serialize(Product);
			var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
			var client = _httpClientFactory.CreateClient("BusinessAPI");
			var response = await client.PostAsync("/api/products", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToPage("/Admin/Products/Index");
			}

			ModelState.AddModelError(string.Empty, "Error creating product.");
			return Page();
		}

		private async Task LoadCategoriesAsync()
		{
			var client = _httpClientFactory.CreateClient("BusinessAPI");
			var response = await client.GetAsync("/api/categories");
			if (response.IsSuccessStatusCode)
			{
				var jsonResponse = await response.Content.ReadAsStringAsync();
				Categories = JsonSerializer.Deserialize<List<CategoryDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			}
		}
	}
}
