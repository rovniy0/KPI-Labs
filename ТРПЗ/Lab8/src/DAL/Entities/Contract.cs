using DAL.Enums;

namespace DAL.Entities;

public class Contract
{
    public int Id { get; set; }
    public string ContractNumber { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; } 
    public CheckStatus Status { get; set; } = CheckStatus.Pending;
}
