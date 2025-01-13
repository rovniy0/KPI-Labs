using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IContractRepository Contracts { get; }
    IProcurementRepository Procurements { get; } 
    ITenderRepository Tenders { get; } 
    void Save();
}
