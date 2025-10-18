using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class UserCredentialsDTO
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
}
