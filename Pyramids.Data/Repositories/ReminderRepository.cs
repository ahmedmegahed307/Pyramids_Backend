using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
  
    public class ReminderRepository : Repository<Reminder>, IReminderRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public ReminderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reminder>> GetAllAsync(int userId, int? companyId = null,bool? seen=false)
        {

            // shows reminders for the past 2 weeks and next 30 days
            DateTime fromDate = DateTime.Now.AddDays(-14);
            DateTime toDate = DateTime.Now.AddDays(30);

            var reminders = await AppDbContext!.Reminders.Where(a => a.Contract.Client.CompanyId == companyId 
            && a.ReminderDate >= fromDate && a.ReminderDate <= toDate
            && a.ReminderSeens.Where(rs=>rs.SeenByUserId == userId).Any()==seen)
            .OrderBy(a=>a.ReminderDate)
            .Include(a=>a.Contract.Client)
            .Include(a=>a.Job)
            .ToListAsync();


            
            return reminders;
        }

        public async Task<bool> GenerateExpiryReminder(Contract dbContract)
        {
            var rem = dbContract.Reminders.Where(x => x.ReminderType == "EXPIRY").FirstOrDefault();

            if (rem == null)
            {
                rem = new Reminder()
                {
                    ReminderType = "EXPIRY",
                    Contract = dbContract,
                    CreatedByUserId = dbContract.CreatedByUserId,

                };
             await AppDbContext!.Reminders.AddAsync(rem);
            }

            rem.ReminderDate = dbContract.ExpiryDate;
            rem.ReminderDetails = String.Format("Contract {0} will expire on {1:dd/MM/yyyy}", dbContract.ContractRef, dbContract.ExpiryDate);

            await AppDbContext!.SaveChangesAsync();

            return true;
        }
        public async Task<bool> generateVisitReminder(Visit dbVisit)
        {
            var rem = dbVisit.Reminders.Where(x => x.ReminderType == "GEN").FirstOrDefault();

            if (rem == null)
            {
                rem = new Reminder()
                {
                    ReminderType = "GEN",
                    Contract = dbVisit.Contract,
                    Visit = dbVisit,
                };
                await AppDbContext.Reminders.AddAsync(rem);
            }
            rem.ReminderDate = dbVisit.VisitDate;
            rem.ReminderDetails = String.Format("A visit for contract {0} will be generated on {1:dd/MM/yyyy}", dbVisit.Contract.ContractRef, dbVisit.VisitDate);

            return true;
        }

    }
}
