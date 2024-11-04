using KhumaloCraft.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.BusinessAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CheckoutController : ControllerBase
  {
    private readonly CheckoutService _checkoutService;

    public CheckoutController(CheckoutService checkoutService)
    {
      _checkoutService = checkoutService;
    }

    [HttpPost("{cartId}")]
    public IActionResult Checkout(string cartId)
    {
      try
      {
        var orderNumber = _checkoutService.ProcessCheckout(cartId);
        return Ok(new { OrderNumber = orderNumber });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
