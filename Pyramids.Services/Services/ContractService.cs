using Pyramids.Core.IServices;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;
using Contract = Pyramids.Core.Models.Contract;

namespace Pyramids.Service.Services
{

    public class ContractService : Service<Contract>, IContractService
    {

        public ContractService(IUnitOfWork unitOfWork, IGenericRepository<Contract> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Contract> CreateContract(Contract contract)
        {
            return await _unitOfWork.ContractRepository.CreateContract(contract);
        }

        public async Task<IEnumerable<Contract>> GetAllAsync(bool isActive, int companyId)
            => await _unitOfWork.ContractRepository.GetAllAsync(isActive, companyId);

        public async Task<Contract> UpdateContract(Contract existingContract,Contract mappedContract)
        {
           return await _unitOfWork.ContractRepository.UpdateContract(existingContract, mappedContract);
        }
      
       
    }
}
