using Microsoft.EntityFrameworkCore.Storage;
using Pyramids.Core.Repositories;

namespace Pyramids.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepository { get; }
        IAssetRepository AssetRepository { get; }
        IAssetTypeRepository AssetTypeRepository { get; }
        IAssetModelRepository AssetModelRepository { get; }
        IAssetManufacturerRepository AssetManufacturerRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IUserRepository UserRepository { get; }
        IClientRepository ClientRepository { get; }
        ISiteRepository SiteRepository { get; }
        IContactRepository ContactRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IJobAttachmentRepository JobAttachmentRepository { get; }
        IJobTypeRepository JobTypeRepository { get; }
        IJobSubTypeRepository JobSubTypeRepository { get; }
        IJobStatusRepository JobStatusRepository { get; }
        IPriorityRepository PriorityRepository { get; }
        IJobIssueRepository JobIssueRepository { get; }
        IJobRepository JobRepository { get; }
      
        IProductRepository ProductRepository { get; }
        IJobFileRepository JobFileRepository { get; }
        IJobSessionStatusRepository JobSessionStatusRepository { get; }
        IJobSessionRepository JobSessionRepository { get; }
        IJobActionStatusRepository JobActionStatusRepository { get; }
        IJobActionRepository JobActionRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IJobPartRepository JobPartRepository { get; }

        //reports
        IReportRepository ReportRepository { get; }
      
        IContractRepository ContractRepository { get; }
        IReminderRepository ReminderRepository { get; }
        IReminderSeenRepository ReminderSeenRepository { get; }
        IVisitRepository VisitRepository { get; }

        //AI
        IAIRepository AIRepository { get; }

        //Scheduler
        ISchedulerEventRepository SchedulerEventRepository { get; }


        Task CommitAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
    }
}
