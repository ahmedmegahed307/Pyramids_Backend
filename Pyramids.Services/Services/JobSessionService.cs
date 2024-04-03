using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class JobSessionService : Service<JobSession>, IJobSessionService
    {
        public JobSessionService(IUnitOfWork unitOfWork, IGenericRepository<JobSession> repository) : base(unitOfWork, repository)
        {
        }
    }
}
