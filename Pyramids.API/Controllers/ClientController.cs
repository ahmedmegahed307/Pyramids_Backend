using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using Pyramids.API.DTOs.Response;
using Pyramids.API.DTOs.Client;
using Pyramids.API.DTOs.Job;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Service.Services;

namespace Pyramids.API.Controllers
{

    public class ClientController : BaseController<Client, ClientDto, ClientCreateDto, ClientUpdateDto>
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientController(IClientService clientService, IMapper mapper)
            : base(clientService, mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }


        [HttpGet("GetAllClientsWithSites")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllClientsWithSites(bool? isActive = null, int? companyId = null)
        {
            IEnumerable<Client> ClientList = await _clientService.GetAllAsync(isActive, companyId, "Sites");
            Log.Information("GetAll method called for => {@entities}", ClientList);
            var data = _mapper.Map<IEnumerable<ClientDto>>(ClientList);

            var ResponseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Message = "Successful"
            };

            return Execute(ResponseDataDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<IActionResult> GetById(int id)
        {
            Client client = await _clientService.GetByIdAsync(id, "Sites,Contacts,Assets");

            if (client == null)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NotFound,
                    Data = null,
                });
            }

            client.Contacts = client.Contacts.Where(contact => contact.IsActive == true).ToList();
            client.Sites = client.Sites.Where(site => site.IsActive == true).ToList();
            client.Assets = client.Assets.Where(asset => asset.IsActive == true).ToList();

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = _mapper.Map<ClientDto>(client),
                Message = "Successful"
            });
        }

    }
}
