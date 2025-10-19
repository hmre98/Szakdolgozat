using Microsoft.AspNetCore.Identity;

namespace backend.Models;

    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }=null!;
        public ApplicationUser User { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime ExpectedEndTime { get; set; }
        public int PriceExpected { get; set; }
        public bool Canceled { get; set; }= false;
        public string? CancellationReason { get; set; }

        public ICollection<ServiceProvided> ServicesProvided { get; set; } = new List<ServiceProvided>();
        public ICollection<ServiceBooked> ServicesBooked { get; set; } = new List<ServiceBooked>();

    }
