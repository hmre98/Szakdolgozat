using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }=null!;
        public string LastName { get; set; }=null!;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();


    }
}