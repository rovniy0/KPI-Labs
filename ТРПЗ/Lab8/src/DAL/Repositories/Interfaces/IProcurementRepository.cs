using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IProcurementRepository : IRepository<Procurement>
{
    IEnumerable<Procurement> GetByTitle(string title);
    IEnumerable<Procurement> GetByClientId(int clientId);
}
