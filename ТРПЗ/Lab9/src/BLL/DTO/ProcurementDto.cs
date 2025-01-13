namespace BLL.DTO;

public class ProcurementDto
{
    public int Id { get; set; }
    public int TenderId { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
