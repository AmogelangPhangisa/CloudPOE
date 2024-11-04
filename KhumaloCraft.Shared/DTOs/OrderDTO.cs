namespace KhumaloCraft.Shared.DTOs;

public class OrderDTO
{
  public string? OrderId { get; set; }
  public string UserId { get; set; }
  public DateTime? OrderDate { get; set; }
  public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
}

