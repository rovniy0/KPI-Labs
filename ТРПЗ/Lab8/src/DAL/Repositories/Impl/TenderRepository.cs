using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Impl;

public class TenderRepository : BaseRepository<Tender>, ITenderRepository
{
    internal TenderRepository(TenderSupportContext context)
        : base(context)
    {
    }

    public IEnumerable<Tender> GetByStatus(string status)
    {
        return context.Set<Tender>()
                      .Where(t => t.Status.ToString().Equals(status, StringComparison.OrdinalIgnoreCase))
                      .ToList();
    }

    public IEnumerable<Tender> GetByProcurementId(int procurementId)
    {
        return context.Set<Tender>()
                      .Where(t => t.ProcurementId == procurementId)
                      .ToList();
    }
}
