using BLL.DTO;

namespace BLL.Services.Interfaces;

public interface IContractService
{
    IEnumerable<ContractDto> GetContracts(int pageNumber, int pageSize);
}

