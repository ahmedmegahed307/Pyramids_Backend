using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Pyramids.API.DTOs.Job;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientPortalController : ResponseController
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;


        public ClientPortalController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;

        }

        [HttpGet("GetAllJobsByClientId")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllJobsByClientId(int clientId,int? jobStatusId)
        {
            IEnumerable<Job> JobsList = await _jobService.GetAllJobsByClientIdAsync(clientId, jobStatusId);

            var data = _mapper.Map<IEnumerable<JobDto>>(JobsList);

            var ResponseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Message = "Successful"
            };

            return Execute(ResponseDataDto);
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
