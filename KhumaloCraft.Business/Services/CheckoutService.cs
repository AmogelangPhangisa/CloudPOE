using System;

namespace KhumaloCraft.Business.Services;

public class CheckoutService
{
  private readonly CartService _cartService;

  public CheckoutService(CartService cartService)
  {
    _cartService = cartService;
  }

  public string ProcessCheckout(string cartId)
  {
    var cart = _cartService.GetCartById(cartId);
    if (cart == null || !cart.Items.Any())
    {
      throw new Exception("Cart is empty.");
    }

    // Simulate processing order and generating order number
    string orderNumber = Guid.NewGuid().ToString();

    // Clear the cart after checkout
    _cartService.ClearCart(cartId);

    return orderNumber;
  }
}
