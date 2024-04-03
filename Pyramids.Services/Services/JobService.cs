using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.IServices;
using Pyramids.Core.UnitOfWork;
using Pyramids.Core.Enums;

namespace Pyramids.Service.Services
{
    public class JobService : Service<Job>, IJobService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Job> _repository;
      
        public JobService(IUnitOfWork unitOfWork, IGenericRepository<Job> repository) : base(unitOfWork, repository)
        {

            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        



       



        public async Task<Job> LogJobFromVisitAsync(User currentUser, Job logJob, JobActionSourceEnum source)
        {

            return await _unitOfWork.JobRepository.LogJobFromVisitAsync(currentUser, logJob, source);
         
        }

        public async Task<Job> UpdateJobStatusAsync(int jobId, int jobStatusId, string? cancelReason, int? engineerId)
        {
            var job = await _repository.GetByIdAsync(jobId);

            if (job == null)
            {
                return null;
            }

            switch (jobStatusId)
            {
                case (int)JobStatusEnum.OPEN:
                    job.EngineerId = null;
                    break;
                case (int)JobStatusEnum.CANCELLED:
                    job.CancelReason = cancelReason;
                    break;
                case (int)JobStatusEnum.ASSIGNED:
                    job.EngineerId = engineerId;
                    break;
                default:
                    break;
            }

            job.JobStatusId = jobStatusId;
            await _unitOfWork.CommitAsync();

            return job;
        }


        public async Task<Job> UpdateJobScheduleDate(int jobId, DateTime? scheduleDateEnd, int? ModifiedByUserId)
        {
            var job = await _repository.GetByIdAsync(jobId);
            if (job == null)
            {
                return null;
            }
            job.ScheduleDateEnd = scheduleDateEnd;
            job.ModifiedDate = DateTime.Now;
            await _unitOfWork.CommitAsync();
            return job;
        }

        public async Task<IEnumerable<Job>> GetLastFiveJobsForSiteId(int siteId)
            => await _unitOfWork.JobRepository.GetLastFiveJobsForSiteId(siteId);

        public async Task<IEnumerable<Job>> GetAllJobsByClientIdAsync(int clientId, int? jobStatusId)
          => await _unitOfWork.JobRepository.GetAllJobsByClientIdAsync(clientId, jobStatusId);

    }   
}
