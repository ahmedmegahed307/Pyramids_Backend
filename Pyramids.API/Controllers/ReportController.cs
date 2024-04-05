using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Pyramids.API.DTOs.Reports.JobQuery;
using Pyramids.API.DTOs.Response;
using Pyramids.Core.Models;
using Pyramids.Core.IServices;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ResponseController
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;

        }
        #region JobQueryStart
        [HttpGet("GetJobQueryData")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetJobQueryData([FromQuery] JobQueryFilterDto jobQueryFilterDto)
        {
            IEnumerable<Job> jobs = await _reportService.GetJobQueryReportData(
                jobQueryFilterDto.DateType, jobQueryFilterDto.DateFrom, jobQueryFilterDto.DateTo,
                jobQueryFilterDto.JobTypeId, jobQueryFilterDto.JobSubTypeId, jobQueryFilterDto.JobStatusId,
                jobQueryFilterDto.JobPriorityId, jobQueryFilterDto.ClientId, jobQueryFilterDto.SiteId, jobQueryFilterDto.CompanyId);

            var data = _mapper.Map<IEnumerable<JobQueryResultDto>>(jobs);

            var responseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Message = "Successful"
            };

            return Execute(responseDataDto);
        }
        #endregion JobQueryEnd

       
      

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
