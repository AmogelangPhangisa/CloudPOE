using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Products
{
  public class DeleteModel : PageModel
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public DeleteModel(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    [BindProperty]
    public int Id { get; set; }

    public IActionResult OnGet(int id)
    {
      Id = id;
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      var client = _httpClientFactory.CreateClient("BusinessAPI");
      var response = await client.DeleteAsync($"/api/products/{Id}");

      if (response.IsSuccessStatusCode)
      {
        return RedirectToPage("/Admin/Products/Index");
      }

      ModelState.AddModelError(string.Empty, "Error deleting product.");
      return Page();
    }
  }

}
