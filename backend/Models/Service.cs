namespace backend.Models;

public class Service
{
    private int Id { get; set; }
    private string Name { get; set; } = string.Empty;
    private decimal Price { get; set; }

    private ICollection<ServiceProvided> ServicesProvided { get; set; } = new List<ServiceProvided>();
    private ICollection<ServiceBooked> ServicesBooked { get; set; } = new List<ServiceBooked>();

}