using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Pages.Auth
{
  public class LogoutModel : PageModel
  {
    public async Task<IActionResult> OnPostAsync()
    {
      Response.Cookies.Delete("AuthToken");
      Response.Cookies.Delete("CartId");

      return RedirectToPage("/Index");
    }
  }
}
