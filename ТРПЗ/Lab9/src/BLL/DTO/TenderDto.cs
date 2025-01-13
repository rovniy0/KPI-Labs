namespace BLL.DTO;

public class TenderDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Budget { get; set; }
    public DateTime Deadline { get; set; }
    public string Status { get; set; }
}
