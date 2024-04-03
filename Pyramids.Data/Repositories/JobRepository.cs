using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.Enums;

namespace Pyramids.Data.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;
      

        public JobRepository(AppDbContext context) : base(context)
        {
           
        }
        public async Task<IEnumerable<Job>> GetLastFiveJobsForSiteId(int siteId)
        {
          return await AppDbContext!.Jobs.Where(x => x.SiteId == siteId)
                .Include(a=>a.JobType)
                .Include(a=>a.JobSubType)
                .Include(a=>a.JobStatus)
                .OrderByDescending(x => x.JobDate).Take(5).ToListAsync();
        }

        public async Task<Job> LogJobFromVisitAsync(User currentUser, Job logJob, JobActionSourceEnum source)
        {
            if (validateJob(currentUser, logJob))
            {

                //todo: use Transaction while creating a job from visit
            //    using (var transaction = await AppDbContext!.Database.BeginTransactionAsync())
                {
                    try
                    {
                        Job dbJob = (AppDbContext!.Jobs.Add(logJob)).Entity;
                        await AppDbContext.SaveChangesAsync();

                        addJobIssue(dbJob);
                        addJobAction(currentUser, dbJob, source);
                        addJobAssignedActionIfEngineerAssigned(currentUser, dbJob, source);
                        addJobSession(currentUser, dbJob);

                        await AppDbContext.SaveChangesAsync();

                      //  transaction.Commit(); 
                        return dbJob;
                    }
                    catch (Exception)
                    {
                         //     transaction.Rollback(); 
                        throw; 
                    }
                }
            }
            else
            {
                throw new Exception("Invalid job");
            }
        }


        private bool validateJob(User currentUser, Job job)
        {
            //to do -> validate user role and engineer to create a job
            return job != null
                && !String.IsNullOrEmpty(job.Description);
            // && IsUserAllowedToLogJobForClient(userInfo, job.ClientID)
            //  && (!job.EngineerId.HasValue || userAdminRepository.ValidateEngineerId(userInfo, job.EngineerID.Value))
        }

        private async void addJobIssue(Job dbJob)
        {
            JobIssue jobIssue = new JobIssue()
            {
                Description = dbJob.Description,
                Job = dbJob,
            };
           await AppDbContext!.JobIssues.AddAsync(jobIssue);
        }


        private async void addJobAction(User currentUser, Job dbJob, JobActionSourceEnum source)
        {
            JobAction jobAction = new JobAction()
            {
                JobActionTypeId = (int?)JobActionTypeEnum.Created,
                Job = dbJob,
                Source = source.ToString(),
                CreatedByUserId = currentUser.Id,
                Comments = "Job Created",
                ActionDate = DateTime.Now,
                ClientId = dbJob.ClientId,

            };
            await AppDbContext!.JobActions.AddAsync(jobAction);
        }
        private async void addJobAssignedActionIfEngineerAssigned(User currentUser, Job dbJob, JobActionSourceEnum source)
        {
            if (dbJob.EngineerId.HasValue && dbJob.EngineerId > 0)
            {
                JobAction jobAction = new JobAction()
                {
                    JobActionTypeId = source == JobActionSourceEnum.Mobile ? (int?)JobActionTypeEnum.AssignedMobile : (int?)JobActionTypeEnum.Assigned,
                    Job = dbJob,
                    Source = source.ToString(),
                    CreatedByUserId = currentUser.Id,
                    Comments = "Job Assigned",
                    ActionDate = DateTime.Now,
                    ClientId = dbJob.ClientId,

                };
               await AppDbContext!.JobActions.AddAsync(jobAction);
            }

        }
        private async void addJobSession(User currentUser, Job dbJob)
        {
            JobSession jobSession = new JobSession();
            if (!dbJob.EngineerId.HasValue || dbJob.EngineerId < 0)
            {
                jobSession = new JobSession()
                {
                    EngineerAssignedId = null,
                    Job = dbJob,
                    ScheduleDate = dbJob.JobDate,
                    CreatedByUserId=currentUser.Id,
                };

            }
            else
            {
                jobSession = new JobSession()
                {
                    EngineerAssignedId = dbJob.EngineerId == 0 ? currentUser.Id : dbJob.EngineerId,
                    Job = dbJob,
                    ScheduleDate = dbJob.JobDate,
                };
            }
            await AppDbContext!.JobSessions.AddAsync(jobSession);
        }

        public async Task<IEnumerable<Job>> GetAllJobsByClientIdAsync(int clientId, int? jobStatusId)
        {
            return await AppDbContext!.Jobs
                .Where(x => x.ClientId == clientId &&
                            (!jobStatusId.HasValue || x.JobStatusId == jobStatusId))
                .Include(a => a.Client)
                .Include(a => a.Site)
                .Include(a => a.JobType)
                .Include(a => a.Priority)
                .Include(a => a.JobSubType)
                .Include(a => a.JobStatus)
                .Include(a => a.Engineer)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

    }
}
