using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pyramids.Core.Models;
using Pyramids.Core.IServices;
using Pyramids.API.DTOs.Company;
using Pyramids.API.DTOs;
using System.Net;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{

    public class CompanyController : BaseController<Company, CompanyDto,CompanyCreateDto,CompanyUpdateDto>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService,IMapper mapper)
        : base(companyService, mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<IActionResult> GetById(int id)
        {
            Company company = await _companyService.GetByIdAsync(id,"Address");

            if (company == null)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NotFound,
                    Data = null,

                });
            }

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = _mapper.Map<CompanyDto>(company),
                Message = "Successful"
            });
        }


    }
}
