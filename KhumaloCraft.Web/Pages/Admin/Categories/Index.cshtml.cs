using System.Net.Http.Headers;
using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Categories
{
  public class IndexModel : PageModel
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

    public async Task OnGetAsync()
    {
      var client = _httpClientFactory.CreateClient("BusinessAPI");
      var response = await client.GetAsync("api/categories");
      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Categories = JsonSerializer.Deserialize<List<CategoryDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
      }
    }
  }
}
