using BLL.DTO;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL;
using CCL.Identity;
using DAL.UnitOfWork;
using Moq;

namespace BLL.Tests;

public class ContractServiceTests
{
    [Fact]
    public void Ctor_InputNull_ThrowArgumentNullException()
    {
        // Arrange
        IUnitOfWork? nullUnitOfWork = null;

        // Act
        var actualServiceFunc = () => new ContractService(nullUnitOfWork);

        // Assert
        Assert.Throws<ArgumentNullException>(actualServiceFunc);
    }

    [Fact]
    public void GetContracts_UserIsNotAuthorized_ThrowMethodAccessException()
    {
        // Arrange
        var user = new User(1, Role.Purchaser); // У користувача немає ролі Admin
        SecurityContext.SetUser(user);

        var mockUnitOfWork = new Mock<IUnitOfWork>();
        IContractService contractService = new ContractService(mockUnitOfWork.Object);

        // Act & Assert
        Assert.Throws<MethodAccessException>(() => contractService.GetContracts(1, 10));
    }


    [Fact]
    public void GetContracts_WithPageNumber_ReturnsCorrectContracts()
    {

        // Arrange
        var user = new User(1, Role.Admin); // Користувач має роль Admin
        SecurityContext.SetUser(user);

        // Arrange
        var expectedContractDto = new ContractDto
        {
            Id = 1,
            TenderId = 123,
            Amount = 1000.50m,
            SignedDate = new DateTime(2025, 1, 1),
            SupplierName = "Test Supplier"
        };

        var contractServiceFake = new ContractServiceFake(expectedContractDto);
        var actualService = contractServiceFake.Get();

   
        var actualContracts = actualService.GetContracts(2, 10).ToList();

        // Assert
        Assert.Single(actualContracts);
        Assert.Equal(expectedContractDto.Id, actualContracts[0].Id);
        Assert.Equal(expectedContractDto.TenderId, actualContracts[0].TenderId);
        Assert.Equal(expectedContractDto.Amount, actualContracts[0].Amount);
        Assert.Equal(expectedContractDto.SignedDate, actualContracts[0].SignedDate);
        Assert.Equal(expectedContractDto.SupplierName, actualContracts[0].SupplierName);
    }



}
