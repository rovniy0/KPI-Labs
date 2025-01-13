using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl;

public class ContractRepository : BaseRepository<Contract>, IContractRepository
{
    public ContractRepository(TenderSupportContext context)
        : base(context)
    {
    }
   

}
