namespace backend.Models;

public class ServiceProvided
{
    private int Id { get; set; }

    private int AppointmentId { get; set; }
    private Appointment Appointment { get; set; } = null!;
    private int ServiceId { get; set; }
    private Service Service { get; set; } = null!;
    private int Price { get; set; }  
}
