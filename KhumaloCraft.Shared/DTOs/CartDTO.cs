namespace KhumaloCraft.Shared.DTOs;

public class CartDTO
{
  public string CartId { get; set; }
  public List<CartItemDTO> Items { get; set; } = new List<CartItemDTO>();
}

