using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using Pyramids.API.DTOs.Client.Site;
using Pyramids.API.DTOs.Job;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{

    public class SiteController : BaseController<Site, SiteDto, SiteCreateDto, SiteUpdateDto>
    {
        private readonly ISiteService _siteService;
        private readonly IMapper _mapper;
        public SiteController(ISiteService siteService, IMapper mapper)
            : base(siteService, mapper)
        {
            _siteService = siteService;
            _mapper = mapper;
        }

        [HttpGet("GetAllSitesByClientId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSitesByClientId(int clientId)
        {
            try
            {
                if (clientId <= 0)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = "Invalid Client Id"
                    });
                }

                IEnumerable<Site> sites = await _siteService.GetAllSitesByClientId(clientId);

                Log.Information("GetAllSitesByClientId method called for clientId {ClientId}", clientId);

                var data = _mapper.Map<IEnumerable<SiteDto>>(sites);
                
                return Ok(new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = data,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while fetching sites by clientId");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }



    }
}
