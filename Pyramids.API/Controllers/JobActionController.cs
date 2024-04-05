using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Pyramids.API.DTOs;
using Pyramids.API.DTOs.JobAction;
using Pyramids.API.DTOs.Reports.JobQuery;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Service.Services;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobActionController : ResponseController
    {
        private readonly IJobActionService _jobActionService;
        private readonly IMapper _mapper;

        public JobActionController(IJobActionService jobActionService, IMapper mapper)
        {
            _jobActionService = jobActionService;
            _mapper = mapper;

        }

        [HttpGet("GetJobActions")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetJobActions(int jobId)
        { 
          IEnumerable<JobAction> jobActions =  await  _jobActionService.GetAllAsync(jobId);

            var data = _mapper.Map<IEnumerable<JobActionDto>>(jobActions);
            var responseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,    
                Message = "Successful"
            };

            return Execute(responseDataDto);
        }


        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
     
        public async Task<IActionResult> Create(JobActionCreateDto jobActionCreateDto)
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
                var jobAction = await _jobActionService.AddAsync(_mapper.Map<JobAction>(jobActionCreateDto));



                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.Created,
                    Data = _mapper.Map<JobActionCreateDto>(jobAction),
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.InnerException?.Message
                });
            }

        }




        private IActionResult Execute(ResponseDataDto response)
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
