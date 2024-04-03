using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IVisitService : IService<Visit>
    {
        Task<bool> GenerateVisits(Contract contract);
        Task<int> GenerateJobVisitsAsync(List<int> visitsId,User currentUser);
        Task<IEnumerable<Visit>> GetAllAsync(bool isActive, int companyId);
        Task GenerateJobVisitsForTodayAsync();

    }


}
