using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;
        private readonly IReminderRepository _reminderRepository;

        public VisitRepository(AppDbContext context, IReminderRepository reminderRepository) : base(context)
        {
            _reminderRepository = reminderRepository;
        }


        public async Task<IEnumerable<Visit>> GetAllAsync(bool isActive, int companyId)
        {

            //get visits  for the past 2 weeks and next 2 weeks
            DateTime fromDate = DateTime.Now.AddDays(-15);
            DateTime toDate = DateTime.Now.AddDays(15);
         
            var visits = await AppDbContext!.Visits.Where(a => a.Contract.Client.CompanyId == companyId 
            && ((a.VisitDate >= fromDate && a.VisitDate <= toDate) || (a.GeneratedDate >= fromDate && a.GeneratedDate <= toDate))
            //&&a.IsGenerated==false || a.IsGenerated==null
            && a.IsActive == isActive)
            .Include(a => a.Contract.Client)
            .Include(a => a.Job.JobSessions)
            .Include(a => a.Job.JobStatus)
            .Include(a => a.Job.JobIssues)
            .OrderBy(a => a.VisitDate)
            .ToListAsync();

            return visits;
        }


        /// <summary>
        /// used in two cases: 
        ///1. creating new contract
        ///2. updating existing contract by changing start/expiry date so it causes recalculating the visits.
        /// </summary>
        /// <param name="dbContract">The contract for which visits need to be generated.</param>
        /// <returns></returns>

        public async Task<bool> GenerateVisits(Contract dbContract)
        {
            DateTime? visitDate = dbContract.StartDate;

            if (dbContract.IsActive && visitDate < dbContract.ExpiryDate)
            {
                if (dbContract.Visits.Any())
                {
                    var generated = dbContract.Visits.Where(x => x.IsGenerated == true).OrderByDescending(x => x.VisitDate).FirstOrDefault();
                    while (generated != null && visitDate < generated.VisitDate)
                    {
                        visitDate = getNextDate(visitDate.Value, dbContract.FrequencyType, dbContract.FrequencyCount);
                    }

                    var visitReminders = AppDbContext!.Visits.Where(x => x.IsGenerated == false && x.ContractId == dbContract.Id && x.VisitDate > visitDate).ToList();
                    foreach (var reminder in visitReminders)
                    {
                        _reminderRepository.RemoveWhere(x => x.VisitId == reminder.Id);
                        AppDbContext.Visits.Remove(reminder);
                    }
                    await AppDbContext.SaveChangesAsync();
                }

                while (visitDate < dbContract.ExpiryDate)
                {
                    var visit = new Visit()
                    {
                        VisitDate = visitDate,
                        Contract = dbContract,
                        CreatedByUserId = dbContract.CreatedByUserId,
                        IsGenerated=false,
                    };
                    AppDbContext!.Visits.Add(visit);
                    await _reminderRepository.generateVisitReminder(visit);
                    visitDate = getNextDate(visitDate.Value, dbContract.FrequencyType, dbContract.FrequencyCount);
                }
            }

            return true;
        }




        private DateTime getNextDate(DateTime lastDate, int? frequencyType, int? frequencyCount)
        {
            if (frequencyType.HasValue && frequencyCount.HasValue)
            {
                if (frequencyType <= 7)
                    return lastDate.AddDays(frequencyCount.Value * frequencyType.Value);
                else
                    return lastDate.AddMonths(frequencyType.Value / 30 * frequencyCount.Value);
            }
            
            throw new ArgumentException("FrequencyType or FrequencyCount is null");
        }

       
    }
}