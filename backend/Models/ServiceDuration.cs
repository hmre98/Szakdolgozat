namespace backend.Models;
public class ServiceDuration
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;
    public int DurationMinutes { get; set; }
}