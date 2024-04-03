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

    public class ReminderService : Service<Reminder>, IReminderService
    {
        public ReminderService(IUnitOfWork unitOfWork, IGenericRepository<Reminder> repository) : base(unitOfWork, repository)
        {
        }



        public async Task<IEnumerable<Reminder>> GetAllAsync(int userId, int? companyId = null, bool? seen = false)
           => await _unitOfWork.ReminderRepository.GetAllAsync(userId, companyId, seen);


        public async Task<int> MarkReminderSeenAsync(List<int> remindersId, int currentUserId)
        {
            var seen = 0;

            IEnumerable<ReminderSeen> seenReminders = await _unitOfWork.ReminderSeenRepository.Where(x => remindersId.Contains(x.ReminderId!.Value));


            foreach (var reminderId in remindersId)
            {

              
                if (!seenReminders.Where(y => y.SeenByUserId == currentUserId && y.ReminderId == reminderId).Any())
                {
                    var rs = new ReminderSeen()
                    {
                        ReminderId = reminderId,
                        SeenByUserId = currentUserId,
                    };
                    
                    await _unitOfWork.ReminderSeenRepository.AddAsync(rs);
                    
                    seen++;
                }
                var deactivateReminder = await _unitOfWork.ReminderRepository.GetByIdAsync(reminderId);
                _unitOfWork.ReminderRepository.Remove(deactivateReminder);
                await _unitOfWork.CommitAsync();

            }
            return seen;
        }


        public async Task<bool> GenerateConflictReminder(Job dbJob, Visit dbVisit)
        {
            var rem = dbVisit.Reminders.Where(x => x.ReminderType == "CONF").FirstOrDefault();
            if (rem == null)
            {
                rem = new Reminder()
                {
                    ReminderType = "CONF",
                    Contract = dbVisit.Contract,
                    Visit = dbVisit,
                    JobId = dbJob.Id
                };

            }
            rem.ReminderDate = dbVisit.VisitDate;
            rem.ReminderDetails = String.Format("Job {0} for Contract {1} scheduled on {2:dd/MM/yyyy} for {3} has a conflict with other events",
                        dbJob.Id, dbVisit.Contract.ContractRef, dbVisit.VisitDate, dbJob.JobSessions.First().EngineerAssigned.FirstName);
            await _unitOfWork.ReminderRepository.AddAsync(rem);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> GenerateUnscheduledReminder(Job dbJob, Visit dbVisit)
        {
            var rem = dbJob.Reminders.Where(x => x.ReminderType == "UNSCHED").FirstOrDefault();
            if (rem == null)
            {
                rem = new Reminder()
                {
                    ReminderType = "UNSCHED",
                    Contract = dbVisit.Contract,
                    Visit = dbVisit,
                    JobId = dbJob.Id
                };

            }
            rem.ReminderDate = dbVisit.VisitDate;
            rem.ReminderDetails = String.Format("Job {0} for Contract {1} scheduled on {2:dd/MM/yyyy} has not been assigned", dbJob.Id, dbVisit.Contract.ContractRef, dbVisit.VisitDate);
            await _unitOfWork.ReminderRepository.AddAsync(rem);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
