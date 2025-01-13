using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL;
using CCL.Identity;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Impl;

public class ContractService : IContractService
{
    private readonly IUnitOfWork _unitOfWork;

    public ContractService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public IEnumerable<ContractDto> GetContracts(int pageNumber, int pageSize)
    {
        var user = SecurityContext.GetCurrentUser();
        if (user == null || !user.Roles.Contains(Role.Admin))
        {
            throw new MethodAccessException("User is not authorized to perform this action.");
        }


        var contracts = _unitOfWork.Contracts.Find(c => true, pageNumber, pageSize);
        return contracts.Select(c => new ContractDto
        {
            Id = c.Id,
            TenderId = c.TenderId,
            Amount = c.Amount,
            SignedDate = c.SignedDate,
            SupplierName = c.SupplierName
        });
    }

}

