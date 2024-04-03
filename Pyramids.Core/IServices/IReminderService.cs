using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IReminderService : IService<Reminder>
    {
        Task<IEnumerable<Reminder>> GetAllAsync(int userId, int? companyId = null, bool? seen = true);
        Task<int> MarkReminderSeenAsync(List<int> remindersId,int currentUserId);
        Task<bool> GenerateUnscheduledReminder(Job dbJob, Visit dbVisit);
        Task<bool> GenerateConflictReminder(Job dbJob, Visit dbVisit);
    }

}
