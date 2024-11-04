namespace KhumaloCraft.Data.Entities;

public class Cart
{
  public string CartId { get; set; } = Guid.NewGuid().ToString();
  public List<CartItem> Items { get; set; } = new List<CartItem>();
  public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);
  public DateTime LastUpdatedAt { get; set; }
  public string? UserId { get; set; }
  public User? User { get; set; }
}