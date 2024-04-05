using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Pyramids.API.DTOs;
using Pyramids.API.DTOs.JobAttachment;
using Pyramids.Core.Enums;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Service.Services;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ResponseController
    {

        private readonly IJobAttachmentService _jobAttachmentService;
        private readonly IBlobService _blobService;
        private readonly IMapper _mapper;

        public AttachmentController(IJobAttachmentService jobAttachmentService, IMapper mapper, IBlobService blobService)
        {
            _jobAttachmentService = jobAttachmentService;
            _mapper = mapper;
            _blobService = blobService;
        }

        [HttpPost("CreateJobAttachment")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateJobAttachment([FromForm] JobAttachmentCreateDto jobAttachmentCreateDto)
        {

            if (jobAttachmentCreateDto.FileToUpload ==null)
            {
                return Execute(new ResponseDataDto { Code = HttpStatusCode.BadRequest, Data = true, Message = "Failed" });

            }
            string blobName = await _blobService.UploadFileAsync(jobAttachmentCreateDto.FileToUpload);

            if (!string.IsNullOrEmpty(blobName))
            {
               await  _jobAttachmentService.AddAsync(new JobAttachment
                {
                    JobId = jobAttachmentCreateDto.JobId,
                    CreatedAt = DateTime.Now,
                    FileName = blobName,
                    FileType = "",
                    FileURL = "",
                    CreatedByUserId = jobAttachmentCreateDto.CreatedByUserId,
                    IsActive = true,
                    IsDeleted = false
                });
                
            }
            return Execute(new ResponseDataDto { Code = HttpStatusCode.OK, Data = true, Message = "Successful" });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteJobAttacment(int id)
        {
            try
            {
                var entity = await _jobAttachmentService.GetByIdAsync(id);

                if (entity == null)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.NotFound
                    });
                }

                _jobAttachmentService.Remove(entity);

                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NoContent
                });
            }
            catch (Exception ex)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message
                });
            }
        }



        private IActionResult Execute(ResponseDataDto response)
        {
            try
            {
                return ResultRequest(response.Code, response.Data, (string?)response.Message);
            }
            catch (Exception ex)
            {
                return ResultRequest(HttpStatusCode.Forbidden, ex.Data, ex.Message);
            }
        }

    }
}
