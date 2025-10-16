using Microsoft.AspNetCore.Identity;

namespace backend.Models;

    public class Appointment
    {
        private int Id { get; set; }
        private DateTime DateCreated { get; set; }
        private int UserId { get; set; }
        private IdentityUser User { get; set; } = null!;
        private DateTime StartTime { get; set; }
        private DateTime ExpectedEndTime { get; set; }
        private DateTime? EndTime { get; set; }
        private int PriceExpected { get; set; }
        private int? PriceActual { get; set; }
        private int? Discount { get; set; }
        private bool Canceled { get; set; }= false;
        private string? CancellationReason { get; set; }

        private ICollection<ServiceProvided> ServicesProvided { get; set; } = new List<ServiceProvided>();
        private ICollection<ServiceBooked> ServicesBooked { get; set; } = new List<ServiceBooked>();
        
    }
