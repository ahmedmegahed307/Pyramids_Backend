using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Pyramids.Core.Models;
using Pyramids.Core.IServices;
using Pyramids.API.DTOs.Address;

namespace Pyramids.API.Controllers
{
    public class AddressController : BaseController<Address, AddressDto,AddressCreateDto,AddressUpdateDto>
    {
        public AddressController(IAddressService addressService, IMapper mapper)
            : base(addressService, mapper)
        {
        }
    }
}
