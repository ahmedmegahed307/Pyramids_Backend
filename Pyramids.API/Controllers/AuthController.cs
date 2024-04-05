using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Pyramids.API.DTOs;
using Pyramids.API.DTOs.User;
using Pyramids.Core.Enums;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Shared.Helper;
using Pyramids.API.DTOs.Auth;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ResponseController
    {

        private readonly IConfiguration Configuration;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly ISampleDataService _sampleDataService;
        //   private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        // public AuthController(IService<User> service, IMapper mapper, IConfiguration configuration, IUserService userService, ICompanyService companyService, IEmailService emailService)
        public AuthController(IService<User> service, IMapper mapper, IConfiguration configuration, IUserService userService, ICompanyService companyService, ISampleDataService sampleDataService)
        {
            Configuration = configuration;
            _userService = userService;
            _companyService = companyService;
            _mapper = mapper;
            _sampleDataService = sampleDataService;
            //    _emailService = emailService;
        }

        [HttpPost("registerengineer")]
        public async Task<IActionResult> RegisterAsync(RegisterEngineerDto registerDto)
        {
            if (registerDto is null)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "Unexpected request."
                });

            }

            if (await _userService.IsExist(registerDto.Email))
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "Email is already exists"
                });

            var user = _mapper.Map<User>(registerDto);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            // Default user role is Engineer
            user.UserRoleId = ((int)UserRoleEnum.Engineer);



            User createdUser = _userService.AddAsync(user).Result;

          

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = createdUser,
                Message = "Successful"
            });
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminDto registerDto)
        {
            try
            {
                if (registerDto is null)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Unexpected request."
                    });
                }

                if (await _userService.IsExist(registerDto.Email))
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Email is already exists"
                    });


                if (await _companyService.IsNameExist(registerDto.CompanyName))
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Company name is already exists"
                    });

                Company company = new Company
                {
                    Name = registerDto.CompanyName,
                    IsActive = true,
                };

                var newCompany = _companyService.AddAsync(company).Result;

                var user = _mapper.Map<User>(registerDto);
                user.Company = newCompany;
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
                user.UserRoleId = ((int)UserRoleEnum.Admin);

                UserDto userDto = _mapper.Map<UserDto>(_userService.AddAsync(user).Result);


                if (userDto is not null)
                {
                    User createdUser = _userService.GetUserByEmail(registerDto.Email);

                    //await _sampleDataService.GenerateSampleData(createdUser);
                    //createdUser.IsFirstLogin = false;
                    await _userService.Update(createdUser.Id, createdUser);
                }

                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = userDto,
                    Message = "Success"
                });
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!await IsExists(loginDto.Email))
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "Invalid Email or Password. Please try again."
                });

            var user = _userService.GetUserByEmail(loginDto.Email);

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.Unauthorized,
                    Message = "Invalid Email or Password. Please try again."
                });

            //generate sample data for user if first login
            bool isFirstLogin = false;
            if (user.IsFirstLogin)
            {
                isFirstLogin = true;
                await _sampleDataService.GenerateSampleData(user);

                user.IsFirstLogin = false;
                await _userService.Update(user.Id, user);
            }

            var jwt = CreateToken(user);

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = jwt,
                Message = isFirstLogin ? "Success_First_Login" : "Success"
            });
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            bool success = _userService.ForgotPassword(email);

            if (!success)
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "User is not exists"
                });

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Message = "We have successfully sent a guard code. Please check your inbox.",
            });
        }

        [HttpPost("confirmcode")]
        public async Task<IActionResult> ConfirmCode(string email, string guardCode)
        {
            var user = _userService.Get(email);

            if (user is null)
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "User is not exists"
                });

            var manager = new PasswordHelper();
            bool match = manager.IsMatch(guardCode, user.ResetPasswordKey.Value);

            if (!match)
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "Invalid reset password code."
                });

            if (user.ResetPasswordKeyValidToDate < DateTime.Now)
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "Reset password code is expired."
                });

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Message = "Successful"
            });
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
                if (resetPasswordDto is null)
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Unexpected request."
                    });

            var user = _userService.Get(resetPasswordDto.Email);

            if (user is null)
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "User is not exists"
                });

            var manager = new PasswordHelper();
            bool match = manager.IsMatch(resetPasswordDto.ResetPasswordCode, user.ResetPasswordKey.Value);

            if (!match)
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "Invalid reset password code."
                });

            if (user.ResetPasswordKeyValidToDate < DateTime.Now)
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "Reset password code is expired."
                });

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(resetPasswordDto.Password);
            user.ResetPasswordKey = null;
            user.ResetPasswordKeyValidToDate = null;

            await _userService.Update(user.Id, user);

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Message = "Successful"
            });
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
               new Claim(ClaimTypes.Email, user.Email),
               new Claim("userId", user.Id.ToString()),
            };

            if (user.UserRole != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, user.UserRole.Role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private async Task<bool> IsExists(string email)
        {
            try
            {
                return await _userService.IsExist(email);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return false;
            }
        }

        protected IActionResult Execute(ResponseDataDto response)
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
