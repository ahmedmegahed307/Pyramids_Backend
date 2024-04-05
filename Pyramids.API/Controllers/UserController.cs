﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Pyramids.API.DTOs.Response;
using Pyramids.API.DTOs.Company;
using Pyramids.API.DTOs.User;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Service.Services;
using Pyramids.API.DTOs.Auth;

namespace Pyramids.API.Controllers
{
    public class UserController : BaseController<User, UserDto,UserCreateDto,UserUpdateDto>
    {
        private readonly IUserService _userService;
        private readonly IBlobService _blobService;
        public UserController(IUserService userService, IMapper mapper, IBlobService blobService)
            : base(userService, mapper)
        {
            _userService = userService;
            _blobService = blobService;
        }


        [HttpGet("GetEngineers")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEngineers(bool isActive, int companyId)
        {
            var engineers = await _userService.GetEngineers(isActive,companyId);
            if(engineers == null)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NotFound,
                    Message = "No Engineers Found"
                });

            }
            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = engineers,
                Message = "Successful"
            });
        }

        [HttpGet("GetCurrentUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCurrent()
        {
            var currentUser = GetCurrentUser();
            if (currentUser == null)
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "User does not exists"
                });
            var user = _userService.GetById(currentUser.UserId);

            if (user == null)
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "User does not exists"
                });

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = user,
                Message = "Successful"
            });
        }

       
        [HttpGet("GetUserByEmail")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            if (! await _userService.IsExist(email))
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "User does not exists"
                });

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = _userService.GetUserByEmail(email),
                Message = "Successful"
            });
        }


        [HttpPut("{userId}/UploadPhoto")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadPhoto(int userId, [FromForm] UserPhotoDto photoDto)
        {

            if (photoDto != null)
            {
                string blobName = await _blobService.UploadFileAsync(photoDto.UserPhoto);

                if (!string.IsNullOrEmpty(blobName))
                {

                    var userPhoto = await _userService.UpdatePhoto(userId, blobName);
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.OK,
                        Message = "Successful",
                        Data = userPhoto,
                    });

                }
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.Created,
                    Message = "Successful"
                });
            }

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.BadRequest,
                Message = "Failed"
            });
        }
        private CurrentUser GetCurrentUser()
        {
            try
            {
                ClaimsPrincipal user = HttpContext.User;
                int userId = Convert.ToInt32(HttpContext.User.FindFirst("userId").Value);
                string userEmail = user.FindFirst(ClaimTypes.Email).Value;

                return new CurrentUser
                {
                    UserId = userId,
                    UserEmail = userEmail
                };
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;
            }
        }



    }
}
