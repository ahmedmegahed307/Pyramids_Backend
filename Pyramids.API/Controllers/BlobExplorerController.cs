using Microsoft.AspNetCore.Mvc;
using Pyramids.Core.IServices;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobExplorerController : ControllerBase
    {
        private readonly IBlobService _blobService;
        //public IAsyncEnumerable<StorageContainerModel> Containers { get; set; }
        //public string SelectedContainer { get; set; }
        //public IAsyncEnumerable<BlobInfoModel> BlobsInContainer { get; set; }
        public BlobExplorerController(IBlobService blobService)
        {
            _blobService = blobService;
        }
    }
}
