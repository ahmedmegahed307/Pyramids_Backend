using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Pyramids.API.DTOs.Product;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{

    public class ProductController : BaseController<Product, ProductDto, ProductCreateDto, ProductUpdateDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
            : base(productService, mapper)
        {
            _productService = productService;
          
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<IActionResult> Create(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            bool res = await _productService.AddProduct(product, productCreateDto.Quantity);

            if (res)
                return Execute(new ResponseDataDto { Code = HttpStatusCode.OK, Data = true, Message = "Successful" });
            else
                return Execute(new ResponseDataDto { Code = HttpStatusCode.BadRequest, Data = false, Message = "Error" });
        }
    }
}
