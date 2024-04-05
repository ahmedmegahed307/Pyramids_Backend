using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using Pyramids.API.DTOs.Asset;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    public class AssetController : BaseController<Asset, AssetDto, AssetCreateDto, AssetUpdateDto>
    {
        private readonly IAssetService _assetService;
        private readonly IAssetModelService _assetModelService;
        private readonly IAssetTypeService _assetTypeService;
        private readonly IAssetManufacturerService _assetManufacturerService;
        private readonly IMapper _mapper;
        public AssetController(IAssetService assetService, 
            IAssetModelService assetModelService, 
            IAssetTypeService assetTypeService, 
            IAssetManufacturerService assetManufacturerService, 
            IMapper mapper)
            : base(assetService, mapper)
        {
            _assetService = assetService;
            _assetModelService = assetModelService;
            _assetTypeService = assetTypeService;
            _assetManufacturerService = assetManufacturerService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<IActionResult> Create(AssetCreateDto assetCreateDto)
        {
            var asset = _mapper.Map<Asset>(assetCreateDto);

            if (assetCreateDto.AssetManufacturerId == 0) 
                asset.AssetManufacturerId = (await _assetManufacturerService.AddAsync(_mapper.Map<AssetManufacturer>(assetCreateDto.AssetManufacturerDto))).Id;
            
            if (assetCreateDto.AssetModelId == 0 )
                asset.AssetModelId = (await _assetModelService.AddAsync(_mapper.Map<AssetModel>(assetCreateDto.AssetModelDto))).Id;
            
            if (assetCreateDto.AssetTypeId == 0)
                asset.AssetTypeId = (await _assetTypeService.AddAsync(_mapper.Map<AssetType>(assetCreateDto.AssetTypeDto))).Id;

            asset.AssetManufacturer = null;
            asset.AssetModel = null;
            asset.AssetType = null;

            bool res = await _assetService.AddAssetAsync(asset);

            if (res)
                return Execute(new ResponseDataDto { Code = HttpStatusCode.OK, Data = true, Message = "Successful" });
            else
                return Execute(new ResponseDataDto { Code = HttpStatusCode.BadRequest, Data = false, Message = "Error" });
        }

        [HttpGet("GetAllAssetsByClientId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAssetsByClientId(int clientId)
        {
            try
            {
               

                IEnumerable<Asset> assets = await _assetService.GetAllAssetsByClientId(clientId);

                Log.Information("GetAllAssetsByClientId method called for clientId {ClientId}", clientId);

                var data = _mapper.Map<IEnumerable<AssetDto>>(assets);

                return Ok(new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = data,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while fetching assets by clientId");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [HttpGet("GetAllAssetsBySiteId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAssetsBySiteId(int siteId)
        {
            try
            {


                IEnumerable<Asset> assets = await _assetService.GetAllAssetsBySiteId(siteId);


                var data = _mapper.Map<IEnumerable<AssetDto>>(assets);

                return Ok(new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = data,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while fetching assets by clientId");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
