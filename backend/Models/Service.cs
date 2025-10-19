namespace backend.Models;

public class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public decimal MaterialCost { get; set; } 

    public int CategoryId { get; set; }
    public ServiceCategory? Category { get; set; }

    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }

    public decimal? DiscountPrice { get; set; }
    public DateTime? DiscountValidUntil { get; set; }

    public bool IsActive { get; set; } = true;


    public ICollection<ServiceProvided> ServicesProvided { get; set; } = new List<ServiceProvided>();
    public ICollection<ServiceBooked> ServicesBooked { get; set; } = new List<ServiceBooked>();
    public ICollection<ServiceDuration> Durations { get; set; } = new List<ServiceDuration>();
    public ICollection<ServiceMaterial> Materials { get; set; } = new List<ServiceMaterial>();

}
