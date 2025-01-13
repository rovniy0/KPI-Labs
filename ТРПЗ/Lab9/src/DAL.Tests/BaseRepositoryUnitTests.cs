using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputEntityInstance_CalledAddMethodOfDBSetWithEntityInstance()
        {
           
            DbContextOptions opt = new DbContextOptionsBuilder<TenderSupportContext>()
                .Options;
            var mockContext = new Mock<TenderSupportContext>(opt);
            var mockDbSet = new Mock<DbSet<Contract>>();
            mockContext
                .Setup(context => context.Set<Contract>())
                .Returns(mockDbSet.Object);
            var repository = new ContractRepository(mockContext.Object);

            var expectedContract = new Mock<Contract>().Object;

            
            repository.Create(expectedContract);

         
            mockDbSet.Verify(
                dbSet => dbSet.Add(expectedContract),
                Times.Once);
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
       
            DbContextOptions opt = new DbContextOptionsBuilder<TenderSupportContext>()
                .Options;
            var mockContext = new Mock<TenderSupportContext>(opt);
            var mockDbSet = new Mock<DbSet<Contract>>();
            mockContext
                .Setup(context => context.Set<Contract>())
                .Returns(mockDbSet.Object);

            var expectedContract = new Contract { Id = 1 };
            mockDbSet.Setup(dbSet => dbSet.Find(expectedContract.Id))
                .Returns(expectedContract);

            var repository = new ContractRepository(mockContext.Object);

            
            var actualContract = repository.Get(expectedContract.Id);

            mockDbSet.Verify(
                dbSet => dbSet.Find(expectedContract.Id),
                Times.Once());
            Assert.Equal(expectedContract, actualContract);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
         
            DbContextOptions opt = new DbContextOptionsBuilder<TenderSupportContext>()
                .Options;
            var mockContext = new Mock<TenderSupportContext>(opt);
            var mockDbSet = new Mock<DbSet<Contract>>();
            mockContext
                .Setup(context => context.Set<Contract>())
                .Returns(mockDbSet.Object);

            var expectedContract = new Contract { Id = 1 };
            mockDbSet.Setup(dbSet => dbSet.Find(expectedContract.Id))
                .Returns(expectedContract);

            var repository = new ContractRepository(mockContext.Object);

           
            repository.Delete(expectedContract.Id);

            
            mockDbSet.Verify(
                dbSet => dbSet.Remove(expectedContract),
                Times.Once);
        }
    }
}