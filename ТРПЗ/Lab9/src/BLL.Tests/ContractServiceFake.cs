using BLL.DTO;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using System.Linq.Expressions;

namespace BLL.Tests;

public class ContractServiceFake
{
    private readonly ContractDto _contractDto;

    public ContractServiceFake(ContractDto contractDto)
    {
        _contractDto = contractDto;
    }

    internal IContractService Get()
    {
        var mockContext = new Mock<IUnitOfWork>();

        var expectedContract = new Contract
        {
            Id = _contractDto.Id,
            TenderId = _contractDto.TenderId,
            SupplierName = _contractDto.SupplierName,
            Amount = _contractDto.Amount,
            SignedDate = _contractDto.SignedDate
        };

        var mockRepository = new Mock<IContractRepository>();
        mockRepository
            .Setup(repo =>
                repo.Find(
                It.IsAny<Expression<Func<Contract, bool>>>(),
                It.IsAny<int>(),
                It.IsAny<int>()))
                .Returns(new List<Contract> { expectedContract });

        mockContext
            .Setup(context =>
                context.Contracts)
            .Returns(mockRepository.Object);

        IContractService contractService = new ContractService(mockContext.Object);
        return contractService;
    }
}
