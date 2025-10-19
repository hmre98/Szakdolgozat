namespace backend.DTOs;

public class MaterialCreateDTO
{
    public string Name { get; set; } = string.Empty;
    public bool InInventory { get; set; } = true;
}
