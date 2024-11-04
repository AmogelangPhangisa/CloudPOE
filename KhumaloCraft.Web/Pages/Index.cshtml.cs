using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;
    private readonly HttpClient _httpClient;
    public List<ProductDTO> ProductList { get; set; } = new List<ProductDTO>();

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
    {
      _logger = logger;
      _httpClient = httpClientFactory.CreateClient("BusinessAPI");
    }

    public async Task OnGetAsync()
    {
      try
      {
        var response = await _httpClient.GetAsync("api/products");

        if (response.IsSuccessStatusCode)
        {
          var jsonResponse = await response.Content.ReadAsStringAsync();
          ProductList = JsonSerializer.Deserialize<List<ProductDTO>>(jsonResponse, new JsonSerializerOptions
          {
            PropertyNameCaseInsensitive = true
          }) ?? new List<ProductDTO>();
        }
        else
        {
          // Log API response status code
          _logger.LogError("API returned status code: {StatusCode}", response.StatusCode);
        }
      }
      catch (Exception ex)
      {
        // Catch and log any unexpected errors
        _logger.LogError(ex, "An error occurred while fetching products.");
      }
    }
  }
}
