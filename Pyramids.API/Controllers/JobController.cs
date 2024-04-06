using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensions.Msal;
using Serilog;
using System.Net;
using Pyramids.API.DTOs;
using Pyramids.API.DTOs.Client.Site;
using Pyramids.API.DTOs.Job;
using Pyramids.API.DTOs.JobStatus;
using Pyramids.API.DTOs.JobType;
using Pyramids.Core.Enums;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Service.Services;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    public class JobController : BaseController<Job, JobDto, JobCreateDto, JobUpdateDto>
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly IJobIssueService _issueService;
        private readonly IJobPartService _partService;
        private readonly IJobSessionService _jobSessionService;
        private readonly IJobAttachmentService _jobAttachmentService;
        public JobController(IJobService jobService, IMapper mapper,
            IJobIssueService issueService,
            IJobPartService partService,
            IJobSessionService jobSessionService,
          
            IJobAttachmentService jobAttachmentService)
            : base(jobService, mapper)
        {
            _jobService = jobService;
            _issueService = issueService;
            _partService = partService;
            _jobSessionService = jobSessionService;
            _jobAttachmentService = jobAttachmentService;
            _mapper = mapper;
        }

        [HttpPost("CreateJob")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public override async Task<IActionResult> Create([FromForm] JobCreateDto jobCreateDto)
        {
            var createdJob = await _jobService.AddAsync(_mapper.Map<Job>(jobCreateDto));
            var issues = _mapper.Map<ICollection<JobIssue>>(jobCreateDto.JobIssueCreateDto);

            foreach (var item in issues)
            {
                item.JobId = createdJob.Id;
                item.IsActive = true;
                await _issueService.AddAsync(item);
            }

            //foreach (var item in jobCreateDto.JobParts)
            //{
            //    await _partService.AddAsync(new JobPart
            //    {
            //        CreatedAt = DateTime.UtcNow,
            //        CreatedByUserId = 3,
            //        IsActive = true,
            //        IsDeleted = false,
            //        JobId = createdJob.Id,
            //        Quantity = item.Quantity,
            //        ProductId = item.ProductId,
            //    });
            //}

            var js = new JobSession
            {
                ClientId = jobCreateDto.ClientId,
                CreatedAt = DateTime.Now,
                CreatedByUserId = 3,
                IsActive = true,
                IsDeleted = false,
                JobId = createdJob.Id,
                IsTraveling = false,
                IsWorking = false,
                ScheduleDate = jobCreateDto.ScheduleDateEnd,
                SessionStatusId = (int)JobSessionStatusEnum.NotStarted,
                SiteId = jobCreateDto.SiteId
            };

            if (jobCreateDto.EngineerId.HasValue)
                js.EngineerAssignedId = jobCreateDto.EngineerId.Value;

            await _jobSessionService.AddAsync(js);



           

            var responseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.Created,
                Data = createdJob,
                Message = "Successful"
            };

            return CreatedAtAction(nameof(GetById), new { id = createdJob.Id }, responseDataDto);
        }

        [HttpGet("GetAllJobs")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(bool? isActive = null, int? companyId = null)
        {
            IEnumerable<Job> JobsList = await _jobService.GetAllAsync(isActive, companyId, "JobStatus,Site,Priority,Client,Engineer,JobType,JobSubType");

            var data = _mapper.Map<IEnumerable<JobDto>>(JobsList);

            var ResponseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Message = "Successful"
            };

            return Execute(ResponseDataDto);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<IActionResult> GetById(int id)
        {
            Job job = await _jobService.GetByIdAsync(id, "JobStatus,Priority,Client,Contact,Site,Engineer,JobType,JobSubType,JobParts.Product,JobActions.JobActionType,JobActions.CreatedByUser,JobIssues.Asset,JobAttachments");

            if (job == null)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NotFound,
                    Data = null,

                });
            }

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = _mapper.Map<JobDto>(job),
                Message = "Successful"
            });
        }

        [HttpPut("{jobId}/JobStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> JobStatus(int jobId, [FromBody] JobStatusUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                });

            }

            try
            {
                var updatedJob = await _jobService.UpdateJobStatusAsync(jobId, dto.JobStatusId, dto.CancelReason, dto.EngineerId);

                if (updatedJob == null)
                {
                    return NotFound("Job not found");
                }

                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NoContent,
                    Data = null,
                });
            }
            catch (Exception ex)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{jobId}/UpdateJobScheduleDate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateJobScheduleDate(int jobId, [FromBody] JobUpdateDto jobdto)
        {

            try
            {
                var updatedJob = await _jobService.UpdateJobScheduleDate(jobId, jobdto.ScheduleDateEnd,jobdto.ModifiedByUserId);

                if (updatedJob == null)
                {
                    return NotFound("Job not found");
                }

                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NoContent,
                    Data = null,
                });
            }
            catch (Exception ex)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message
                });
            }
        }


        [HttpGet("GetLastFiveJobsForSiteId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLastFiveJobsForSiteId(int siteId)
        {
            if (siteId <= 0)
            {
                return BadRequest(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Data = null,
                    Message = "Invalid Site Id"
                });
            }

            try
            {
                IEnumerable<Job> jobs = await _jobService.GetLastFiveJobsForSiteId(siteId);

                if (jobs == null || !jobs.Any())
                {
                    return NotFound(new ResponseDataDto
                    {
                        Code = HttpStatusCode.NotFound,
                        Data = null,
                        Message = "No jobs found for the specified site"
                    });
                }

                var jobDtos = jobs.Select(MapJobToDto).ToList();

                return Ok(new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = jobDtos,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message
                });
            }
        }

        private JobDto MapJobToDto(Job job)
        {
            return new JobDto
            {
                Id = job.Id,
                CompanyId = job.CompanyId,
                Description = job.Description,
                JobDate = job.JobDate,
                JobStatus = new JobStatusDto
                {
                    Name = job.JobStatus.Name,
                    Code = job.JobStatus.Code
                },
                JobType = new JobJobTypeDto
                {
                    Id = job.JobType.Id,
                    Name = job.JobType.Name
                },
                JobSubType = new JobJobSubTypeDto
                {
                    Id = job.JobSubType.Id,
                    Name = job.JobSubType.Name
                }
            };
        }




    }
}
