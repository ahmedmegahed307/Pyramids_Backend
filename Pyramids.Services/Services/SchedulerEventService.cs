using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;
using Pyramids.Service.Services;

namespace Pyramids.Service.Services
{
    public class SchedulerEventService : Service<SchedulerEvent>, ISchedulerEventService
    {
        public SchedulerEventService(IUnitOfWork unitOfWork, IGenericRepository<SchedulerEvent> repository) : base(unitOfWork, repository)
        {
        }
    }
}
