using System.ComponentModel.DataAnnotations;

namespace KhumaloCraft.Shared.DTOs;

public class RegisterDTO
{
  [Required]
  public string Email { get; set; }

  [Required]
  [MinLength(6)]
  public string Password { get; set; }

  [Required]
  [MinLength(6)]
  public string ConfirmPassword { get; set; }

  [Required]
  public string FirstName { get; set; }

  [Required]
  public string LastName { get; set; }
}

