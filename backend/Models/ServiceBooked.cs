namespace backend.Models;

public class ServiceBooked
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;
    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;
    public int Price { get; set; }  

    int DurationId { get; set; }
    public ServiceDuration Duration { get; set; } = null!;

    public ICollection<ServiceBookedMaterial>? Materials { get; set; } = new List<ServiceBookedMaterial>();
}
