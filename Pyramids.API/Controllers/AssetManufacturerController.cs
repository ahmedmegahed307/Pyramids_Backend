using AutoMapper;
using Pyramids.API.DTOs.AssetManufacturer;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;

namespace Pyramids.API.Controllers
{
    public class AssetManufacturerController : BaseController<AssetManufacturer, AssetManufacturerDto, AssetManufacturerCreateDto, AssetManufacturerUpdateDto>
    {
        private readonly IAssetManufacturerService _assetManufacturerService;
        private readonly IMapper _mapper;
        public AssetManufacturerController(IAssetManufacturerService assetManufacturerService, IMapper mapper)
            : base(assetManufacturerService, mapper)
        {
            _assetManufacturerService = assetManufacturerService;
            _mapper = mapper;
        }
    }
}
