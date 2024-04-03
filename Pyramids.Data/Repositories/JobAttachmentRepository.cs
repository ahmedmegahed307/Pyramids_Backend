using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class JobAttachmentRepository : Repository<JobAttachment>, IJobAttachmentRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;
        public JobAttachmentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
