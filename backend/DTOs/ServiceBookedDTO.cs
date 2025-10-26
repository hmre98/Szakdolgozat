namespace backend.DTOs;

public class ServiceBookedDTO
{
    public int AppointmentId { get; set; }   
    public int ServiceId { get; set; }       
    public int DurationMinutes { get; set; } 
    public decimal Price { get; set; }       
}
