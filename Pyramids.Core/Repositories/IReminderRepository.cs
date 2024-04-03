using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IReminderRepository : IGenericRepository<Reminder>
    {
        Task<IEnumerable<Reminder>> GetAllAsync(int userId, int? companyId = null,bool? seen=false);

        Task<bool> GenerateExpiryReminder(Contract dbContract);
        Task<bool> generateVisitReminder(Visit dbVisit);
    }

}
