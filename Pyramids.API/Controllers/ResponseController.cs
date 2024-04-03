using Microsoft.AspNetCore.Mvc;
using Pyramids.API.DTOs;
using Pyramids.API.DTOs.Response;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Pyramids.API.Controllers
{
    public abstract class ResponseController : ControllerBase
    {
        protected IActionResult ResultRequest(HttpStatusCode code, object? result = null, string? message = null)
        {
            var statusCode = code;
            var responseData = new ResponseDataDto
            {
                Code = code,
                Status = statusCode.ToString(),
                Data = result,
                Message = message
            };

            return new ObjectResult(responseData) { StatusCode = (int)statusCode };
        }
    }
}
