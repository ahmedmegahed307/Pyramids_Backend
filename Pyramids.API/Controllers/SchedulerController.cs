using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using Pyramids.API.DTOs.Response;
using Pyramids.API.DTOs.Scheduler;
using Pyramids.Core.Enums;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;


namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ResponseController
    {
        private readonly IMapper _mapper;
        private readonly ISchedulerEventService _eventService;
        private readonly IJobService _jobService;
        private readonly IUserService _userService;

        public SchedulerController(IMapper mapper, IJobService jobService,  ISchedulerEventService eventService, IUserService userService)
        {
            _mapper = mapper;
            _jobService = jobService;
            _eventService = eventService;
            _userService = userService;
        }


        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetScheduler")]
        public async Task<IActionResult> GetScheduler(int companyId)
        {
            try
            {

            IEnumerable<SchedulerEvent> events = await _eventService.GetAllAsync(true,companyId);
            IEnumerable<User> users = await _userService.GetAllAsync(true,companyId);
            IEnumerable<User> engineers = await _userService.GetEngineers(true,companyId);

            IEnumerable<Job> jobs = await _jobService.WhereIncluding(
                j=>j.CompanyId==companyId&&j.IsActive 
                &&( j.JobStatusId == (int)JobStatusEnum.OPEN || j.JobStatusId == (int)JobStatusEnum.ASSIGNED)
               ,j=>j.Engineer,jobs=>jobs.JobType,jobs=>jobs.JobSubType,jobs=>jobs.JobStatus,jobs=>jobs.Client,jobs=>jobs.Site,jobs=>jobs.Contact
            );
            var scheduler = new List<SchedulerDto>();

            foreach (var e in events)
            {
                List<EmployeeDto>? employees = new List<EmployeeDto>();

                int[]? employeeIds = e.EmployeesId?.Split(',').Select(x => Convert.ToInt32(x)).ToArray();

                if (employeeIds != null)
                    employees = users.Where(x => employeeIds.Contains(x.Id))
                        .Select(x => new EmployeeDto() { Id = x.Id, Name = x.FirstName + " " + x.LastName }).ToList();

                scheduler.Add(new SchedulerDto()
                {
                    
                    Event = new SchedulerEventDto()
                    {
                        Id = e.Id,
                        CompanyId = e.CompanyId,
                        Title = e.Title,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                        Description = e.Description,
                        EventType = e.EventType,
                        Employees = employees,
                    }
                });
            }


            foreach (var j in jobs)
            {

                    scheduler.Add(new SchedulerDto()
                    {
                     
                        Job = new SchedulerJobDto()
                        {
                            Id = j.Id,
                            Title = "Job Id:" + j.Id,
                            StartDate = j.ScheduleDateEnd,
                            EndDate = j.ScheduleDateEnd.HasValue ? j.ScheduleDateEnd.Value.AddHours(1) : (DateTime?)null,
                            ScheduleDateEnd = j.ScheduleDateEnd,
                            Description = j.Description,
                            ClientId = j.ClientId,
                            ClientName = j.Client?.Name,
                            SiteId = j.SiteId,
                            SiteName = j.Site?.Name,
                            ContactId = j.ContactId,
                            ContactName = j.Contact?.Name  ?? "N/A",
                            JobTypeId = j.JobTypeId.Value,
                            JobTypeName = j.JobType?.Name ??"N/A",
                            JobSubTypeId = j.JobSubTypeId.Value,
                            JobSubTypeName = j.JobSubType?.Name ??"N/A",
                            JobStatusId = j.JobStatusId.Value,
                            JobStatusName = j.JobStatus?.Name ??"N/A",
                            EngineerId = j.EngineerId,
                            EngineerName = j.Engineer?.FirstName +" " +j.Engineer?.LastName ?? "N/A",
                        }
                    });
            }
            return Execute(new ResponseDataDto { Code = HttpStatusCode.OK, Data = scheduler, Message = "Successful" });

            }
            catch (Exception ex)
            {
                return Execute(new ResponseDataDto { Code = HttpStatusCode.BadRequest, Message = "Failure" });
            }
        }



        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost(("CreateEvent"))]
        public async Task<IActionResult> CreateEvent(SchedulerEventCreateDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation Error");
            }
            try
            {
                    await _eventService.AddAsync(_mapper.Map<SchedulerEvent>(eventDto));

                return Execute(new ResponseDataDto { Code = HttpStatusCode.Created, Data = null, Message = "Successful" });
            }
            catch (Exception ex)
            {
                return Execute(new ResponseDataDto { Code = HttpStatusCode.BadRequest, Data = ex.Message, Message = "Failure" });

            }
        }

        [HttpPut("UpdateEvent/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public virtual async Task<IActionResult> UpdateEvent(int id, SchedulerEventUpdateDto eventDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Invalid Model"
                    });
                }

                var existingEvent = await _eventService.GetByIdAsync(id);
                if (existingEvent == null)
                {
                    return NotFound("Entity not found");
                }

                _mapper.Map(eventDto, existingEvent);

                await _eventService.Update(id, existingEvent);

                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NoContent,
                    Message="Success"

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

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("DeleteEvent/{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var existingEvent = await _eventService.GetByIdAsync(id);

                if (existingEvent == null)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.NotFound
                    });
                }

                _eventService.Remove(existingEvent);

                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NoContent
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

        protected IActionResult Execute(ResponseDataDto response)
        {
            try
            {
                return ResultRequest(response.Code, response.Data, (string?)response.Message);
            }
            catch (Exception ex)
            {
                return ResultRequest(HttpStatusCode.Forbidden, ex.Data, ex.Message);
            }
        }
    }

}