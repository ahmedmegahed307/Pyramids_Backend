using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using Pyramids.API.DTOs.Response;
using Pyramids.API.DTOs.JobSubType;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;

namespace Pyramids.API.Controllers
{
    public class JobSubTypeController : BaseController<JobSubType, JobSubTypeDto, JobSubTypeCreateDto, JobSubTypeUpdateDto>
    {
        private readonly IJobSubTypeService _jobSubTypeService;
        private readonly IMapper _mapper;
        public JobSubTypeController(IJobSubTypeService jobSubTypeService, IMapper mapper) : base(jobSubTypeService, mapper)
        {
            _jobSubTypeService = jobSubTypeService;
            _mapper = mapper;
        }




        [HttpGet("GetAllJobSubTypes")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllJobSubTypes(bool? isActive = null, int? companyId = null)
        {
            IEnumerable<JobSubType> jobSubTypeList = await _jobSubTypeService.GetAllAsync(isActive, companyId, "JobType");
            Log.Information("GetAll method called for => {@entities}", jobSubTypeList);
            var data = _mapper.Map<IEnumerable<JobSubTypeDto>>(jobSubTypeList);

            var ResponseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Message = "Successful"
            };

            return Execute(ResponseDataDto);
        }

        [HttpGet("GetAllSubTypesByTypeId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSubTypesByTypeId(int typeId)
        {
            try
            {


                IEnumerable<JobSubType> subTypes = await _jobSubTypeService.GetAllSubTypesByTypeId(typeId);

                Log.Information("GetAllSubTypesByTypeId method called for typeId {TypeId}", typeId);

                var data = _mapper.Map<IEnumerable<JobSubTypeDto>>(subTypes);

                return Ok(new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = data,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while fetching subtypes by typeId");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }



    } 
    }

