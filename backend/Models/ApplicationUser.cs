using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }=null!;
        public string LastName { get; set; }=null!;

        public ICollection<ServiceBooked> ServicesBooked { get; set; } = new List<ServiceBooked>();


    }
}