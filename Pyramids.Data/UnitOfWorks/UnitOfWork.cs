using Microsoft.EntityFrameworkCore.Storage;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;
using Pyramids.Data.Repositories;

namespace Pyramids.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction _transaction;

        private IAssetRepository _assetRepository;
        private IAssetTypeRepository _assetTypeRepository;
        private IAssetModelRepository _assetModelRepository;
        private IAssetManufacturerRepository _assetManufacturerRepository;
        private IAddressRepository _addressRepository;
        private IProductRepository _productRepository;
       
        private IUserRoleRepository _userRoleRepository;
        private IUserRepository _userRepository;
        private IClientRepository _clientRepository;
        private ISiteRepository _siteRepository;
        private IContactRepository _contactRepository;
        private ICompanyRepository _companyRepository;
        private IJobAttachmentRepository _jobAttachmentRepository;
        private IJobTypeRepository _jobTypeRepository;
        private IJobSubTypeRepository _jobSubTypeRepository;
        private IJobStatusRepository _jobStatusRepository;
        private IPriorityRepository _priorityRepository;
        private IJobRepository _jobRepository;
        private IJobIssueRepository _jobIssueRepository;
        private IJobFileRepository _jobFileRepository;
        private IJobSessionStatusRepository _jobSessionStatusRepository;
        private IJobSessionRepository _jobSessionRepository;
        private IJobActionStatusRepository _jobActionStatusRepository;
        private IJobActionRepository _jobActionRepository;
        
        private INotificationRepository _notificationRepository;
        private IJobPartRepository _jobPartRepository;
        //reports
        private IReportRepository _reportRepository;
        //ppm
        private IContractRepository _contractRepository;
        private IReminderRepository _reminderRepository;
        private IReminderSeenRepository _reminderSeenRepository;
        private IVisitRepository _visitRepository;
        private IAIRepository aIRepository;
        //Scheduler
        private ISchedulerEventRepository _schedulerEventRepository;


        public UnitOfWork(AppDbContext context) => _context = context;

        public IAssetRepository AssetRepository => _assetRepository ??= new AssetRepository(_context);
        public IAssetModelRepository AssetModelRepository => _assetModelRepository ??= new AssetModelRepository(_context);
        public IAssetTypeRepository AssetTypeRepository => _assetTypeRepository ??= new AssetTypeRepository(_context);
        public IAssetManufacturerRepository AssetManufacturerRepository => _assetManufacturerRepository ??= new AssetManufacturerRepository(_context);
        public IAddressRepository AddressRepository => _addressRepository ??= new AddressRepository(_context);
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
        public IUserRoleRepository UserRoleRepository => _userRoleRepository ??= new UserRoleRepository(_context);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public IClientRepository ClientRepository => _clientRepository ??= new ClientRepository(_context);
        public ISiteRepository SiteRepository => _siteRepository ??= new SiteRepository(_context);
        public IContactRepository ContactRepository => _contactRepository ??= new ContactRepository(_context);
        public ICompanyRepository CompanyRepository => _companyRepository ??= new CompanyRepository(_context);
        public IJobAttachmentRepository JobAttachmentRepository => _jobAttachmentRepository ??= new JobAttachmentRepository(_context);
        public IJobTypeRepository JobTypeRepository => _jobTypeRepository ??= new JobTypeRepository(_context);
        public IJobSubTypeRepository JobSubTypeRepository => _jobSubTypeRepository ??= new JobSubTypeRepository(_context);
        public IJobStatusRepository JobStatusRepository => _jobStatusRepository ??= new JobStatusRepository(_context);
        public IPriorityRepository PriorityRepository => _priorityRepository ??= new PriorityRepository(_context);
        public IJobRepository JobRepository => _jobRepository ??= new JobRepository(_context);
        public IJobIssueRepository JobIssueRepository => _jobIssueRepository ??= new JobIssueRepository(_context);
      

        public IJobFileRepository JobFileRepository
            => _jobFileRepository ??= new JobFileRepository(_context);

        public IJobSessionStatusRepository JobSessionStatusRepository
            => _jobSessionStatusRepository ??= new JobSessionStatusRepository(_context);

        public IJobSessionRepository JobSessionRepository
            => _jobSessionRepository ??= new JobSessionRepository(_context);

        public IJobActionStatusRepository JobActionStatusRepository
            => _jobActionStatusRepository ??= new JobActionStatusRepository(_context);

        public IJobActionRepository JobActionRepository
            => _jobActionRepository ??= new JobActionRepository(_context);

      
        public INotificationRepository NotificationRepository
            => _notificationRepository ??= new NotificationRepository(_context);
        public IJobPartRepository JobPartRepository
         => _jobPartRepository ??= new JobPartRepository(_context);

        public IReportRepository ReportRepository
         => _reportRepository ??= new ReportRepository(_context);


        public IContractRepository ContractRepository
            => _contractRepository ??= new ContractRepository(_context,ReminderRepository,VisitRepository);

        public IReminderRepository ReminderRepository
    => _reminderRepository ??= new ReminderRepository(_context);

        public IReminderSeenRepository ReminderSeenRepository
    => _reminderSeenRepository ??= new ReminderSeenRepository(_context);
        public IVisitRepository VisitRepository
 => _visitRepository ??= new VisitRepository(_context, ReminderRepository );
        public IAIRepository AIRepository
            => aIRepository ??= new AIRepository(_context);

        public ISchedulerEventRepository SchedulerEventRepository
        => _schedulerEventRepository ??= new SchedulerEventRepository(_context);



        public IDbContextTransaction BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = _context.Database.BeginTransaction();
            }
            return _transaction;
        }

        public async Task CommitAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                    _transaction = null;
                }
                else
                {
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction = null;
                }
                throw;
            }
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Commit();
                    _transaction = null;
                }
                else
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction = null;
                }
                throw;
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
            _context.Dispose();
        }
    }
}
