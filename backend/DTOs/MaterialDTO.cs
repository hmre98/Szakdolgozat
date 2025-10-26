namespace backend.DTOs;
public class MaterialDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsSelectable { get; set; }

    public bool InInventory { get; set; }

}
