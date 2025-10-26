namespace backend.DTOs;

public class AppointmentCreateDTO
{
    public int UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime ExpectedEndTime { get; set; }
    public int PriceExpected { get; set; }
    public List<ServiceBookedDTO> ServicesBooked { get; set; } = new();
}
