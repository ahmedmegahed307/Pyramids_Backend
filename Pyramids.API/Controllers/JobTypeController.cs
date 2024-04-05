using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using Pyramids.API.DTOs.Response;
using Pyramids.API.DTOs.JobType;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
namespace Pyramids.API.Controllers
{
    public class JobTypeController : BaseController<JobType, JobTypeDto, JobTypeCreateDto, JobTypeUpdateDto>
    {
        private readonly IJobTypeService _jobTypeService;
        private readonly IMapper _mapper;
        public JobTypeController(IJobTypeService jobTypeService, IMapper mapper) : base(jobTypeService, mapper)
        {
            _jobTypeService = jobTypeService;
            _mapper = mapper;

        }


        [HttpGet("GetAllJobTypesWithSubTypes")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllWithSubTypes(bool? isActive = null, int? companyId = null)
        {
            IEnumerable<JobType> jobTypeList = await _jobTypeService.GetAllAsync(isActive, companyId, "JobSubTypes");
            Log.Information("GetAll method called for => {@entities}", jobTypeList);
            var data = _mapper.Map<IEnumerable<JobTypeDto>>(jobTypeList);

            var ResponseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Message = "Successful"
            };

            return Execute(ResponseDataDto);
        }

        // todo create subtype

        //[HttpPost("CreateJobTypeWithSubTypes")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> CreateJobTypeWithSubTypes(JobTypeCreateDto dto)
        //{
        //    try
        //    {

        //        var newJobType = _mapper.Map<JobType>(dto);


        //        //newJobType.JobSubTypes = dto.JobSubTypes
        //        //    .Select(subType => new JobSubType { Name = subType.Name, CreatedByUserId = dto.CreatedByUserId })
        //        //    .ToList();

        //        var createdJobType = await _jobTypeService.AddAsync(newJobType);
        //        return Execute(new ResponseDataDto
        //        {
        //            Code = HttpStatusCode.Created,
        //            Data = _mapper.Map<JobTypeDto>(createdJobType),
        //            Message = "Successful"
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        var innerException = ex.InnerException;
        //        return Execute(new ResponseDataDto
        //        {
        //            Code = HttpStatusCode.BadRequest,
        //            Message = "Failed"
        //        });
        //    }
    } 
    }

