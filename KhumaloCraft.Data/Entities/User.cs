using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace KhumaloCraft.Data.Entities
{
  public class User : IdentityUser
  {
    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; }
  }
}