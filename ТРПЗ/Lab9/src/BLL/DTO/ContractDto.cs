namespace BLL.DTO;

public class ContractDto
{
    public int Id { get; set; }
    public int TenderId { get; set; }
    public decimal Amount { get; set; }
    public DateTime SignedDate { get; set; }
    public string SupplierName { get; set; }
    public string PurchaserName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
