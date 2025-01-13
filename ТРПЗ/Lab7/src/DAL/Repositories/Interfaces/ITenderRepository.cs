using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface ITenderRepository : IRepository<Tender>
{
    IEnumerable<Tender> GetByStatus(string status);
    IEnumerable<Tender> GetByProcurementId(int procurementId);
}
