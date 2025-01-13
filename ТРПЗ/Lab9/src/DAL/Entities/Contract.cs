using DAL.Enums;

namespace DAL.Entities;

public class Contract
{
    public int Id { get; set; }
    public int TenderId { get; set; }
    public decimal Amount { get; set; }
    public DateTime SignedDate { get; set; }
    public string SupplierName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; } 
    public CheckStatus Status { get; set; } = CheckStatus.Pending;
}
