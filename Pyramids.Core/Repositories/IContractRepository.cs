using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IContractRepository : IGenericRepository<Contract>
    {
        Task<Contract> CreateContract(Contract contract);
        Task<IEnumerable<Contract>> GetAllAsync(bool isActive, int companyId);
        Task<Contract> UpdateContract( Contract exisitingContract, Contract mappedContract);
    }

}
