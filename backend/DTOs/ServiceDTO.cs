namespace backend.DTOs
{
    public class ServiceDTO
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int DurationMinutes { get; set; }

    public List<int> AllowedDurations { get; set; } = new List<int>();
}

}
