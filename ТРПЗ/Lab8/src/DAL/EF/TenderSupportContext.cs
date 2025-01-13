using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class TenderSupportContext : DbContext
{
    public DbSet<Contract> Contracts { get; set; } 
    public DbSet<Procurement> Procurements { get; set; } 
    public DbSet<Tender> Tenders { get; set; } 

    public TenderSupportContext(DbContextOptions options)
        : base(options)
    {
    }
}
