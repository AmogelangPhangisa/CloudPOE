using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhumaloCraft.Data.Entities
{
  public class Product
  {
    public int ProductId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [MaxLength(255)]
    public string ImageSrc { get; set; }

    [Required]
    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
  }
}