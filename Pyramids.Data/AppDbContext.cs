using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pyramids.Core.Models;
using Pyramids.Data.Configurations;
using Pyramids.Data.Seeds;

namespace Pyramids.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbConnection"), sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); });
            
        }

        // to search a record by soundex for AI
        [DbFunction("SOUNDEX", IsBuiltIn =true)]
        public static string SoundsLike(string query)
        {
            throw new NotImplementedException();
        }
        public DbSet<AIUserInputAccuracyTracking> AIUserInputAccuracyTrackings { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<AssetModel> AssetModels { get; set; }
        public DbSet<AssetManufacturer> AssetManufacturers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Notification> Notifications { get; set; }
      
        public DbSet<JobAttachment> JobAttachments { get; set; }
        public DbSet<JobAction> JobActions { get; set; }
        public DbSet<JobActionStatus> JobActionStatuses { get; set; }
        public DbSet<JobSession> JobSessions { get; set; }
        public DbSet<JobSessionStatus> JobSessionStatuses { get; set; }
        public DbSet<JobFile> JobFiles { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<JobSubType> JobSubTypes { get; set; }
        public DbSet<JobStatus> JobStatuses { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobActionType> JobActionTypes { get; set; }
      
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<JobIssue> JobIssues { get; set; }
        public DbSet<WorkDocket> WorkDockets { get; set; }
        public DbSet<JobSurvey> JobSurveys { get; set; }
       
        public DbSet<Visit> Visits { get; set; }
      
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<ReminderSeen> ReminderSeens { get; set; }
        public DbSet<Contract> Contracts { get; set; }
      
        public DbSet<Product> Products { get; set; }
        public DbSet<JobPart> JobParts { get; set; }
        public DbSet<SchedulerEvent> SchedulerEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // apply configurations
            modelBuilder.ApplyConfiguration(new AddressConfiguration());


            // apply seeds


            modelBuilder.ApplyConfiguration(new CompanySeed());
            modelBuilder.ApplyConfiguration(new JobActionStatusSeed());
            modelBuilder.ApplyConfiguration(new JobPrioritySeed());
            modelBuilder.ApplyConfiguration(new JobSessionStatusSeed());
            modelBuilder.ApplyConfiguration(new JobStatusSeed());
            modelBuilder.ApplyConfiguration(new JobTypeSeed());
            modelBuilder.ApplyConfiguration(new UserRoleSeed());
        }

    }
}
