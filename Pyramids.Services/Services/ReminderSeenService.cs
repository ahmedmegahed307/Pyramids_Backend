using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
   
    public class ReminderSeenService : Service<ReminderSeen>, IReminderSeenService
    {
        public ReminderSeenService(IUnitOfWork unitOfWork, IGenericRepository<ReminderSeen> repository) : base(unitOfWork, repository)
        {
        }
       
    }
}
