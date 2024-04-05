using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Pyramids.API.DTOs;
using Pyramids.API.DTOs.Client;
using Pyramids.API.DTOs.Data;
using Pyramids.API.DTOs.JobType;
using Pyramids.API.DTOs.User;
using Pyramids.Core.IServices;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly ISiteService _siteService;
        private readonly IContactService _contactService;
        private readonly IPriorityService _jobPriorityService;
        private readonly IJobTypeService _jobTypeService;
        private readonly IJobSubTypeService _jobSubTypeService;
        private readonly IAssetModelService _assetModelService;
        private readonly IAssetTypeService _assetTypeService;
        private readonly IAssetManufacturerService _assetManufacturerService;
        private readonly IMapper _mapper;

        public DataController(
            IUserService userService,
            IClientService clientService,
            ISiteService siteService,
            IContactService contactService,
            IPriorityService jobPriorityService,
            IJobTypeService jobTypeService,
            IJobSubTypeService jobSubTypeService,
            IAssetModelService assetModelService,
            IAssetTypeService assetTypeService,
            IAssetManufacturerService assetManufacturerService

            , IMapper mapper)
        {
            _userService = userService;
            _clientService = clientService;
            _siteService = siteService;
            _contactService = contactService;
            _jobPriorityService = jobPriorityService;
            _jobTypeService = jobTypeService;
            _jobSubTypeService = jobSubTypeService;
            _assetModelService = assetModelService;
            _assetTypeService = assetTypeService;
            _assetManufacturerService = assetManufacturerService;
            _mapper = mapper;
        }

        [HttpGet("GetJobCreationData")]
        public async Task<IActionResult> GetJobCreationData(int companyId)
        {
            var engineers = _mapper.Map<IEnumerable<UserDataDto>>(await _userService.GetEngineers(isActive: true, companyId));
            var clients = _mapper.Map<IEnumerable<ClientDataDto>>(await _clientService.GetAllAsync(isActive: true, companyId));
            var sites = _mapper.Map<IEnumerable<SiteDataDto>>(await _siteService.GetAllAsync(isActive: true, companyId));
            //var priorities = _mapper.Map<IEnumerable<JobPriorityDataDto>>(await _jobPriorityService.GetAllAsync(isActive:true, companyId));
            var jobTypes = _mapper.Map<IEnumerable<JobTypeDataDto>>(await _jobTypeService.GetAllAsync(isActive: true, companyId));
            var jobSubTypes = _mapper.Map<IEnumerable<JobSubTypeDataDto>>(await _jobSubTypeService.GetAllAsync(isActive: true, companyId));
            var contacts = _mapper.Map<IEnumerable<ContactDataDto>>(await _contactService.GetAllAsync(isActive: true, companyId));

            var responseData = new
            {
                Code = HttpStatusCode.OK,
                Message = "Successful",
                Data = new
                {
                    Engineers = engineers,
                    Clients = clients,
                   // Priorities = priorities,
                    JobTypes = jobTypes,
                    JobSubTypes = jobSubTypes,
                    Sites = sites,
                    Contacts = contacts
                }
            };

            return Ok(responseData);
        }

        [HttpGet("GetAssetCreationData")]
        public async Task<IActionResult> GetAssetCreationData(int companyId)
        {
            var assetModels = _mapper.Map<IEnumerable<AssetModelDataDto>>(await _assetModelService.GetAllAsync(isActive: true, companyId));
            var assetTypes = _mapper.Map<IEnumerable<AssetTypeDataDto>>(await _assetTypeService.GetAllAsync(isActive: true, companyId));
            var assetManufacturers = _mapper.Map<IEnumerable<AssetManufacturerDataDto>>(await _assetManufacturerService.GetAllAsync(isActive: true, companyId));
            var clients = _mapper.Map<IEnumerable<ClientDataDto>>(await _clientService.GetAllAsync(isActive: true, companyId));



            var responseData = new
            {
                Code = HttpStatusCode.OK,
                Message = "Successful",
                Data = new
                {
                    AssetModels = assetModels,
                    AssetTypes = assetTypes,
                    AssetManufacturers = assetManufacturers,
                    Clients = clients,

                }
            };

            return Ok(responseData);
        }

    }
}
