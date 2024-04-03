using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class JobSubTypeService : Service<JobSubType>, IJobSubTypeService
    {
        public JobSubTypeService(IUnitOfWork unitOfWork, IGenericRepository<JobSubType> repository) : base(unitOfWork, repository)
        {

        }

        public async Task<IEnumerable<JobSubType>> GetAllSubTypesByTypeId(int typeId)
        {
            return await _unitOfWork.JobSubTypeRepository.GetAllSubTypesByTypeId(typeId);

        }

        public Task<JobSubType> GetJobSubTypeByName(string name, int companyId)
        {
            return _unitOfWork.JobSubTypeRepository.GetJobSubTypeByName(name, companyId);
        }
    }
}
