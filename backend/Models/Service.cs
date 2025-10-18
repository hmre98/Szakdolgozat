namespace backend.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int DurationMinutes { get; set; }

    public ICollection<ServiceProvided> ServicesProvided { get; set; } = new List<ServiceProvided>();
    public ICollection<ServiceBooked> ServicesBooked { get; set; } = new List<ServiceBooked>();
    public ICollection<ServiceDuration> Durations { get; set; } = new List<ServiceDuration>();

}