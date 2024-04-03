using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Enums;
using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IJobActionService
    {

        Task<IEnumerable<JobAction>> GetAllAsync(int jobId);
        Task<JobAction> AddAsync(JobAction jobAction);

    }
}
