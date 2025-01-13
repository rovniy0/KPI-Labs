using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl;

public class ProcurementRepository : BaseRepository<Procurement>, IProcurementRepository
{
    internal ProcurementRepository(TenderSupportContext context)
        : base(context)
    {
    }

    public IEnumerable<Procurement> GetByTitle(string title)
    {
        return context.Set<Procurement>()
                      .Where(p => p.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                      .ToList();
    }

    public IEnumerable<Procurement> GetByClientId(int clientId)
    {
        return context.Set<Procurement>()
                      .Where(p => p.Id == clientId)
                      .ToList();
    }
}

