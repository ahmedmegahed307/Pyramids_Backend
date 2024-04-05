using AutoMapper;
using Pyramids.API.DTOs.AssetModel;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;

namespace Pyramids.API.Controllers
{
    public class AssetModelController : BaseController<AssetModel, AssetModelDto, AssetModelCreateDto, AssetModelUpdateDto>
    {
        private readonly IAssetModelService _assetModelService;
        private readonly IMapper _mapper;
        public AssetModelController(IAssetModelService assetModelService, IMapper mapper)
            : base(assetModelService, mapper)
        {
            _assetModelService = assetModelService;
            _mapper = mapper;
        }
    }
}
