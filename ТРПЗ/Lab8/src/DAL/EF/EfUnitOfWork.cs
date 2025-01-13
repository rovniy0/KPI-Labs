using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly TenderSupportContext _dbContext;
    private ContractRepository? _contractRepository;
    private ProcurementRepository? _procurementRepository;
    private TenderRepository? _tenderRepository;

    public EfUnitOfWork(DbContextOptions options)
    {
        _dbContext = new TenderSupportContext(options);
    }

    public IContractRepository Contracts
    {
        get
        {
            if (_contractRepository is null)
                _contractRepository = new ContractRepository(_dbContext);
            return _contractRepository;
        }
    }

    public IProcurementRepository Procurements
    {
        get
        {
            if (_procurementRepository is null)
                _procurementRepository = new ProcurementRepository(_dbContext);
            return _procurementRepository;
        }
    }

    public ITenderRepository Tenders
    {
        get
        {
            if (_tenderRepository is null)
                _tenderRepository = new TenderRepository(_dbContext);
            return _tenderRepository;
        }
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    private bool _disposed = false;
    public virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _dbContext.Dispose();
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
