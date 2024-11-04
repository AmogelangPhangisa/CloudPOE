namespace KhumaloCraft.Shared.DTOs;

public class OrderItemDTO
{
  public int? OrderItemId { get; set; }
  public int ProductId { get; set; }
  public string ProductName { get; set; }
  public decimal Price { get; set; }
  public int Quantity { get; set; } = 1;

  public string? OrderId { get; set; }
}

