using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class EditClaimDTO
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
