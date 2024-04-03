using Pyramids.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.Repositories
{
    public interface IJobTypeRepository : IGenericRepository<JobType>
    {
        Task<JobType> GetJobTypeByName(string name, int companyId);
    }
}
