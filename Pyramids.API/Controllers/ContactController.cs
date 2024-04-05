using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using Pyramids.API.DTOs;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.API.DTOs.Client.Contact;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    public class ContactController : BaseController<Contact,ContactDto,ContactCreateDto,ContactUpdateDto>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService,IMapper mapper) : base(contactService, mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }


        [HttpGet("GetAllContactsByClientId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllContactsByClientId(int clientId)
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

                IEnumerable<Contact> contacts = await _contactService.GetAllContactsByClientId(clientId);

                Log.Information("GetAllContactsByClientId method called for clientId {ClientId}", clientId);

                var data = _mapper.Map<IEnumerable<ContactDto>>(contacts);

                return Ok(new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = data,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while fetching contacts by clientId");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

    }
}
