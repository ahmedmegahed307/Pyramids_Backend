using Microsoft.AspNetCore.Mvc;
using System.Net;
using Pyramids.API.DTOs.Response;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.API.DTOs.Reports.JobQuery;
using AutoMapper;
using Pyramids.Core.Models.AI;
using Pyramids.Core.Enums;
using Pyramids.API.DTOs;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ResponseController
    {

        private readonly IAIService _aiService;
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly IJobIssueService _issueService;



        public OpenAIController(IMapper mapper, IAIService aIService, IJobService jobService, IJobIssueService issueService)
        {
            _mapper = mapper;
            _aiService = aIService;
            _jobService = jobService;
            _issueService = issueService;
        }


        [HttpPost]
        [Route("ProcessText")]
        public async Task<IActionResult> ProcessText([FromBody] TextProcessingRequest request)
        {
            int intent = await _aiService.ClassifyTextAsync(request);

            switch (intent)
            {
                case (int)TextClassificationEnum.CREATEJOB:
                    return await CheckCreateJobInfoByAI(request);
                case (int)TextClassificationEnum.JOBQUERYREPORT:
                    return await JobQueryReportByAI(request);

                default:
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.NotFound,
                        Data = null,
                        Message = AIChatMessages.ClassifyMessageOnFail
                    });
            }
        }


        #region CreateJobByAI

        [HttpPost]
        [Route("CreateJobByAI")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateJobByAI(JobCreateDto jobCreateDto)
        {
            var createdJob = await _jobService.AddAsync(_mapper.Map<Job>(jobCreateDto));
            var issues = _mapper.Map<ICollection<JobIssue>>(jobCreateDto.JobIssueCreateDto);
            if (issues != null)
            {
                foreach (var item in issues)
                {
                    item.JobId = createdJob.Id;
                    item.IsActive = true;
                    await _issueService.AddAsync(item);
                }
            }
            var responseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.Created,
                Data = createdJob,
                Message = "Success"
            };

            return Execute(responseDataDto);
        }


        private async Task<IActionResult> CheckCreateJobInfoByAI(TextProcessingRequest request)
        {
            var jobInfoByAI = await _aiService.GetJobInfoByAI(request.Text,request.CompanyId);
            if (string.IsNullOrEmpty(jobInfoByAI.ClientName))
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NotFound,
                    Data = null,
                    Message = AIChatMessages.CheckCreateJobInfoByAIFail
                });
            }

            var responseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = jobInfoByAI,
                Message = "CreateJobInfoCheck"
            };
            return Execute(responseDataDto);

        }



        #endregion CreateJobByAI




        private async Task<IActionResult> JobQueryReportByAI(TextProcessingRequest jobRequest)
        {

            IEnumerable<Job> jobs = await _aiService.JobQueryReportByAI(jobRequest.Text, jobRequest.UserId, jobRequest.CompanyId);
            var data = _mapper.Map<IEnumerable<JobQueryResultDto>>(jobs);

            var responseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Message = "JobQueryReport"
            };
            return Execute(responseDataDto);
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
