using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class JobAttachmentService : Service<JobAttachment>, IJobAttachmentService
    {
        public JobAttachmentService(IUnitOfWork unitOfWork, IGenericRepository<JobAttachment> repository) : base(unitOfWork, repository)
        {
        }
    }
}
