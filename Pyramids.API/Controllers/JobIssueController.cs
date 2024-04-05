using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pyramids.API.DTOs.JobIssue;
using Pyramids.API.DTOs.JobPart;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;

namespace Pyramids.API.Controllers
{
   
    public class JobIssueController : BaseController<JobIssue, JobIssueDto, JobIssueCreateDto, JobIssueUpdateDto>
    {
        public JobIssueController(IJobIssueService issueService, IMapper mapper)
            : base(issueService, mapper)
        {
        }
    }
}
