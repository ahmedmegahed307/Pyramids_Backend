using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pyramids.API.DTOs.Address;
using Pyramids.API.DTOs.JobPart;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;

namespace Pyramids.API.Controllers
{
   
    public class JobPartController : BaseController<JobPart, JobPartDto, JobPartCreateDto, JobPartUpdateDto>
    {
        public JobPartController(IJobPartService partService, IMapper mapper)
            : base(partService, mapper)
        {
        }
    }
}
