using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Repositories;
using Contract = Pyramids.Core.Models.Contract;

namespace Pyramids.Data.Repositories
{

    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public AppDbContext? AppDbContext => _context as AppDbContext;
        private readonly IReminderRepository _reminderRepository;
        private readonly IVisitRepository _visitRepository;

        public ContractRepository(AppDbContext context, IReminderRepository reminderRepository, IVisitRepository visitRepository) : base(context)
        {
            _reminderRepository = reminderRepository;
            _visitRepository = visitRepository;
        }

        public async Task<IEnumerable<Contract>> GetAllAsync(bool isActive, int companyId)
        {


            var contracts = await AppDbContext!.Contracts.Where(a => a.Client.CompanyId == companyId && a.IsActive == isActive)
                .Include(a => a.Client)
                .Include(a => a.JobType)
                .Include(a => a.JobSubType)
                .OrderByDescending(a => a.Id)
                .ToListAsync();

            return contracts;
        }
        public async Task<Contract> CreateContract(Contract contract)
        {
            string contractRef = await generateContractRef(contract.ClientId, contract.Client.CompanyId, contract.ContractRef!);
            contract.ContractRef = contractRef;

            contract.Status = getStatus(contract.StartDate, contract.ExpiryDate, contract.IsActive);

            var dbContract = (await AppDbContext!.Contracts.AddAsync(contract)).Entity;

            await _visitRepository.GenerateVisits(dbContract);

            dbContract.NextVisitDate = getNextDate(dbContract.Status!, dbContract.StartDate, null);

            await AppDbContext.SaveChangesAsync();
            await _reminderRepository.GenerateExpiryReminder(dbContract);

            return dbContract;
        }

        public async Task<Contract> UpdateContract(Contract exisitingContract, Contract mappedContract)
        {

            exisitingContract.Status = getStatus(mappedContract.StartDate, mappedContract.ExpiryDate, mappedContract.IsActive);
            bool recalculateVisits = shouldRecalculateVisits(exisitingContract, mappedContract);

            // todo: dto mapping?

            exisitingContract.ContractRef = mappedContract.ContractRef;
            exisitingContract.IsActive = mappedContract.IsActive;
            exisitingContract.BillingType = mappedContract.BillingType;
            exisitingContract.Description = mappedContract.Description;
            exisitingContract.ClientId = mappedContract.ClientId;
            exisitingContract.DefaultEngineerId = mappedContract.DefaultEngineerId;
            exisitingContract.StartDate = mappedContract.StartDate;
            exisitingContract.ExpiryDate = mappedContract.ExpiryDate;
            exisitingContract.FrequencyCount = mappedContract.FrequencyCount;
            exisitingContract.FrequencyType = mappedContract.FrequencyType;
            exisitingContract.JobSubTypeId = mappedContract.JobSubTypeId;
            exisitingContract.JobTypeId = mappedContract.JobTypeId;
            exisitingContract.EstimatedDurationMinutes = mappedContract.EstimatedDurationMinutes;
            exisitingContract.ContractCharge = mappedContract.ContractCharge;
            exisitingContract.ModifiedDate = DateTime.Now;

            if (recalculateVisits)
            {
                await _visitRepository.GenerateVisits(exisitingContract);
                await _reminderRepository.GenerateExpiryReminder(exisitingContract);
            }

            exisitingContract.NextVisitDate = getNextDate(exisitingContract.Status!, exisitingContract.StartDate, exisitingContract);
            await AppDbContext!.SaveChangesAsync();
            return exisitingContract;

        }
        private async Task<string> generateContractRef(int? ClientId, int CompanyId, string cRef)
        {
            var contractRef = cRef;
            int i = 1;
            if (String.IsNullOrEmpty(cRef))
            {
                var client = AppDbContext!.Clients.Where(x => x.Id == ClientId).FirstOrDefault();


                cRef = client!.Code!;

                contractRef = cRef + i.ToString("D5");

                var existingRefs = await AppDbContext.Contracts.Where(x => x.Client.CompanyId == CompanyId).ToListAsync();


                while (existingRefs.Where(x => x.ContractRef == contractRef).Any())
                {
                    i++;
                    contractRef = cRef + i.ToString("D5");
                }
            }

            return contractRef;
        }
        private String getStatus(DateTime? startDate, DateTime? expiryDate, bool IsActive)
        {
            string status = "ACTIVE";
            if (startDate > DateTime.Now.Date)
            {
                status = "PENDING";
            }
            else if (expiryDate < DateTime.Now.Date)
            {
                status = "EXPIRED";
            }
            else if (IsActive == false)
            {
                status = "INACTIVE";
            }
            return status;
        }
        private DateTime? getNextDate(string Status, DateTime? startDate, Contract? dbContract)
        {
            if (Status == "EXPIRED" || Status == "INACTIVE")
                return null;

            if (dbContract == null)
                return startDate;

            return dbContract.Visits.Where(x => x.IsGenerated == false).OrderBy(x => x.VisitDate).Select(x => x.VisitDate).FirstOrDefault();
        }
        private bool shouldRecalculateVisits(Contract exisitingContract, Contract mappedContract)
        {
            return (exisitingContract.StartDate != mappedContract.StartDate
                    || exisitingContract.ExpiryDate != mappedContract.ExpiryDate
                    || exisitingContract.FrequencyType != mappedContract.FrequencyType);
        }

    }
}
