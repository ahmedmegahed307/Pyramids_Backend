using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IContractService : IService<Contract>
    {
        Task<Contract> CreateContract(Contract contract);
        Task<IEnumerable<Contract>> GetAllAsync(bool isActive, int companyId);
        Task<Contract> UpdateContract(Contract exisitingContract, Contract mappedContract);
    }

}
