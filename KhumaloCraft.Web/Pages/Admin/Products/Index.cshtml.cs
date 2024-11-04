using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Products
{
  public class IndexModel : PageModel
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();

    public async Task OnGetAsync()
    {
      var client = _httpClientFactory.CreateClient("BusinessAPI");
      var response = await client.GetAsync("/api/products");
      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Products = JsonSerializer.Deserialize<List<ProductDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
      }
    }
  }
}
