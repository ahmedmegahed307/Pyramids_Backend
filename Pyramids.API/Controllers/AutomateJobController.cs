using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;
using Pyramids.API.DTOs;
using Pyramids.API.DTOs.Job;
using Pyramids.API.DTOs.JobAction;
using Pyramids.API.DTOs.JobIssue;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    public class AutomateJobController : BaseController<Job, JobDto, JobCreateDto, JobUpdateDto>
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly IJobIssueService _issueService;
        private readonly IJobActionService _jobActionService;
        private readonly ICompanyService _companyService;
        private readonly ISiteService _siteService;
        private readonly IJobSubTypeService _jobSubTypeService;
        private readonly IContactService _contactService;
        private readonly IAssetService _assetService;
        private readonly IJobPartService _partService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        public AutomateJobController(IJobService jobService, IMapper mapper,
            IJobIssueService issueService,
            IJobActionService jobActionService,
            ICompanyService companyService,
            ISiteService siteService,
            IJobSubTypeService jobSubTypeService,
            IContactService contactService,
            IAssetService assetService,
            IJobPartService partService,
            IUserService userService,
            IProductService productService)
            : base(jobService, mapper)
        {
            _jobService = jobService;
            _issueService = issueService;
            _companyService = companyService;
            _siteService = siteService;
            _jobSubTypeService = jobSubTypeService;
            _contactService = contactService;
            _assetService = assetService;
            _partService = partService;
            _productService = productService;
            _userService = userService;
            _mapper = mapper;
            _jobActionService = jobActionService;
        }

        [HttpPost("CloseAllOpenJobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CloseAllOpenJobs()
        {
            try
            {
                var openJobs = await _jobService.GetAllAsync(); 
                foreach (var job in openJobs)
                {
                    if (job.JobStatusId == 1 || job.JobStatusId == 2 || job.JobStatusId == 3) 
                    {
                        await _jobService.UpdateJobStatusAsync(job.Id, 4, "", 0);
                        await _jobActionService.AddAsync(_mapper.Map<JobAction>(new JobActionCreateDto {
                            ActionDate = DateTime.Now,
                            ClientId = job.ClientId,
                            Comments = "Job Resolved Automatically",
                            CreatedByUserId = 2,
                            JobActionTypeId = 4,
                            JobId = job.Id,
                        }));
                    }
                }

                return Ok(new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Message = "All open jobs are closed successfully."
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

        [HttpPost("CreateMultipleJobs")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMultipleJobs(List<JobCreateDto> jobCreateDtos)
        {
            try
            {
                List<JobCreateDto> jobDtos = await GenerateNewJobs();

                foreach (var dto in jobDtos)
                {
                    var createdJob = await _jobService.AddAsync(_mapper.Map<Job>(dto));

                    if (dto.JobIssueCreateDto != null && dto.JobIssueCreateDto.Count > 0)
                    {
                        var issues = _mapper.Map<ICollection<JobIssue>>(dto.JobIssueCreateDto);

                        foreach (var issueDto in issues)
                        {
                            issueDto.JobId = createdJob.Id;
                            issueDto.IsActive = true;
                            await _issueService.AddAsync(_mapper.Map<JobIssue>(issueDto));
                        }
                    }
                }

                return Ok();
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

        private async Task<List<JobCreateDto>> GenerateNewJobs()
        {
            List<JobCreateDto> generatedJobs = new List<JobCreateDto>();

            var companies = await _companyService.GetAllAsync();
            List<int> jobPriorities = new List<int> { 1,2,3 };
            List<int> jobStatuses = new List<int> { 1,2 };
            List<string> jobIssuePriorities = new List<string> { "Low","Medium","High" };
            List<string> jobDescriptions = new List<string> { 
                "Urgent: The alarm system in the Acme London Office is experiencing malfunctions. The alarm triggers randomly,requires immediate attention.",
                "Smart Home Integration at Globex Corp - We need assistance with the installation of smart home devices and integration into our main office infrastructure.",
                "Fire Safety Planning Consultation - We require expert consultation to design and implement effective fire safety measures at Nova HQ.",
                "Critical System Malfunctions - We are facing issues with our critical systems at the main office. Immediate troubleshooting is needed.",
                "Camera System Monitoring Setup - Set up monitoring for our camera system at the NovaTech Center.",
                "Fire Alarm Maintenance - Maintenance required for our fire alarm system at the GlobalTech Office.",
                "Alarm System Installation - Install a new alarm system at our main headquarters.",
                "Energy Efficiency Consulting - We need consultation to improve energy efficiency at Silverline House.",
                "CCTV Image Troubleshooting - Resolve issues with CCTV image quality at Sunrise HQ.",
                "Electrical Wiring Maintenance - Maintenance required for electrical wiring at the main office.",
                "Fire System Upgrade - Upgrade the fire system at Eco House.",
                "Emergency Exit Routes Design - Design effective emergency exit routes for the main office.",
                "Electrical Outage Troubleshooting - Resolve issues with electrical outages at TechWave HQ.",
                "Energy Consumption Monitoring - Set up monitoring for energy consumption at Pacific HQ.",
                "Generator Maintenance - Maintenance required for the generator at Vista Center."
            };
            List<string> techComments = new List<string> { 
                "Random triggers in Acme London alarm. Urgent software check needed.",
                "Globex Corp seeks help for smart home device integration.",
                "Nova HQ needs expert fire safety plan consultation.",
                "Critical systems malfunction at main office. Immediate troubleshooting.",
                "Set up camera system monitoring at NovaTech Center.",
                "Fire alarm maintenance needed at GlobalTech Office.",
                "Install new alarm system at main headquarters.",
                "Consultation needed for energy efficiency at Silverline House.",
                "Resolve CCTV image issues at Sunrise HQ.",
                "Emergency exit route design for main office safety."
            };
            List<string> jobIssueDescriptions = new List<string> {
                "Acme London Office alarm triggers randomly - urgent attention required.",
                "Globex Corp seeks assistance with smart home device integration.",
                "Expert consultation needed for fire safety at Nova HQ.",
                "Critical systems malfunction at main office - immediate troubleshooting.",
                "Set up camera system monitoring at NovaTech Center.",
                "Fire alarm maintenance required at GlobalTech Office.",
                "Install new alarm system at main headquarters.",
                "Consultation needed for energy efficiency at Silverline House.",
                "Resolve CCTV image issues at Sunrise HQ.",
                "Emergency exit route design for main office safety."
            };
            List<int> estimationDurations = new List<int> { 0, 60, 120 };

            foreach (var company in companies)
            {
                var sites = await _siteService.GetAllAsync(CompanyId: company.Id);
                int jobsPerSite = sites.Count() < 10 ? 4 : 1;


                for (int i = 0; i < jobsPerSite; i++) 
                {
                    if (sites.Any())
                    {
                        var jobSubTypes = await _jobSubTypeService.GetAllAsync(CompanyId: company.Id);
                        var contacts = await _contactService.GetAllAsync(CompanyId: company.Id);
                        var products = await _productService.GetAllAsync(CompanyId: company.Id);
                        var engineers = await _userService.GetEngineers(true, company.Id);

                        foreach (var site in sites)
                        {
                            var assets = await _assetService.GetAllAssetsBySiteId(site.Id);

                            int tempContactId = 0;
                            int tempJobStatusId = 1;
                            int? tempEngineerId = null;
                            int tempSubTypeId = 0;
                            int? tempJobTypeId = 0;
                            int tempJobPriority = 1;
                            string tempJobIssuePriority = "Low";
                            int tempEstimationDuration = 0;
                            int tempAssetId = 0;
                            int tempProductId = 0;
                            string tempDescription = "";
                            string tempComment = "";
                            string tempJobIssueDesc = "";

                            if (contacts.Any())
                            {
                                var randomContact = contacts.ElementAt(new Random().Next(contacts.Count()));
                                tempContactId = randomContact.Id;
                            }

                            if (engineers.Any())
                            {
                                var randomJobStatus = jobStatuses.ElementAt(new Random().Next(jobStatuses.Count()));
                                tempJobStatusId = randomJobStatus;

                                if (tempJobStatusId == 2)
                                {
                                    var randomEng = engineers.ElementAt(new Random().Next(engineers.Count()));
                                    tempEngineerId = randomEng.Id;
                                }
                            }

                            var randomJobSubType = jobSubTypes.ElementAt(new Random().Next(jobSubTypes.Count()));
                            tempSubTypeId = randomJobSubType.Id;
                            tempJobTypeId = randomJobSubType.JobTypeId;

                            tempJobPriority = jobPriorities.ElementAt(new Random().Next(jobPriorities.Count()));

                            if (assets.Any())
                            {
                                var randomAsset = assets.ElementAt(new Random().Next(assets.Count()));
                                tempAssetId = randomAsset.Id;
                            }

                            if (products.Any())
                            {
                                var randomPart = products.ElementAt(new Random().Next(products.Count()));
                                tempProductId = randomPart.Id;
                            }
                            tempJobIssuePriority = jobIssuePriorities.ElementAt(new Random().Next(jobIssuePriorities.Count()));
                            tempJobIssueDesc = jobIssueDescriptions.ElementAt(new Random().Next(jobIssueDescriptions.Count()));

                            tempEstimationDuration = estimationDurations.ElementAt(new Random().Next(estimationDurations.Count()));

                            tempDescription = jobDescriptions.ElementAt(new Random().Next(jobDescriptions.Count()));
                            tempComment = techComments.ElementAt(new Random().Next(techComments.Count()));

                            List<JobIssueCreateDto> generatedJobIssue = new List<JobIssueCreateDto>();
                            List<JobCreateJobPart> generatedJobPart = new List<JobCreateJobPart>();

                            var jobIssueCreateDto = new JobIssueCreateDto
                            {
                                IsActive = true,
                                Description = tempJobIssueDesc,
                                AssetId = tempAssetId,
                                ModifiedDate = DateTime.Now,
                                Resolved = false,
                                CreatedOn = "autoTask",
                                JobIssuePriority = tempJobIssuePriority

                            };
                            generatedJobIssue.Add(jobIssueCreateDto);

                            if (tempProductId > 0)
                            {
                                var jobPartCreateDto = new JobCreateJobPart
                                {
                                    Id = 0,
                                    ProductId = tempProductId,
                                    Quantity = 1
                                };

                                generatedJobPart.Add(jobPartCreateDto);
                            }

                            var newJob = new JobCreateDto
                            {
                                IsActive = true,
                                CompanyId = company.Id,
                                SiteId = site.Id,
                                ClientId = (int)site.ClientId,
                                ContactId = tempContactId,
                                CreatedByUserId = 2,
                                JobSubTypeId = tempSubTypeId,
                                JobTypeId = (int)tempJobTypeId,
                                Description = tempDescription,
                                EngineerId = tempEngineerId,
                                TechComments = tempComment,
                                JobStatusId = tempJobStatusId,
                                JobPriorityId = tempJobPriority,
                                ScheduleDateEnd = DateTime.Now,
                                EstimatedDuration = tempEstimationDuration,
                                JobIssueCreateDto = generatedJobIssue,
                                JobParts = generatedJobPart
                            };

                            generatedJobs.Add(newJob);
                        }
                    }
                }                                                                                                                                                                                                           
            }
            return generatedJobs;
        }
    }

}

