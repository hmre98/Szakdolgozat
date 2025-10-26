namespace backend.Models;

public class Material
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public bool IsSelectable { get; set; } = true;

    public bool InInventory { get; set; } = true;

    public ICollection<ServiceMaterial>? Services { get; set; } = new List<ServiceMaterial>();
}
