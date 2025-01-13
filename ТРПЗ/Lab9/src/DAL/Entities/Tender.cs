using DAL.Enums;

namespace DAL.Entities;

public class Tender
{
    public int Id { get; set; }
    public int ProcurementId { get; set; }
    public int ContractId { get; set; }
    public CheckStatus Status { get; set; } = CheckStatus.Pending; 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
}
