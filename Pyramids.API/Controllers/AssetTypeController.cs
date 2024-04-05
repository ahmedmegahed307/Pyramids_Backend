using AutoMapper;
using Pyramids.API.DTOs.AssetType;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;

namespace Pyramids.API.Controllers
{
    public class AssetTypeController : BaseController<AssetType, AssetTypeDto, AssetTypeCreateDto, AssetTypeUpdateDto>
    {
        private readonly IAssetTypeService _assetTypeService;
        private readonly IMapper _mapper;
        public AssetTypeController(IAssetTypeService assetTypeService, IMapper mapper)
            : base(assetTypeService, mapper)
        {
            _assetTypeService = assetTypeService;
            _mapper = mapper;
        }
    }
}
