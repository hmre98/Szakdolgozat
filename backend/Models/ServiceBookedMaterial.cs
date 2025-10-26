namespace backend.Models;

public class ServiceBookedMaterial
{
    public int Id { get; set; }

    public int ServiceBookedId { get; set; }
    public ServiceBooked ServiceBooked { get; set; }

    public ICollection<Material> Material { get; set; }

}
