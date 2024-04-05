using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Pyramids.Core.Models;
using Pyramids.Core.IServices;
using Pyramids.API.DTOs.UserRole;
using Pyramids.API.DTOs;

namespace Pyramids.API.Controllers
{
    [Authorize(Roles = "Admin,Engineer")]
    public class UserRoleController : BaseController<UserRole, UserRoleDto,UserRoleCreateDto,UserRoleUpdateDto>
    {
        public UserRoleController(IUserRoleService userRoleService, IMapper mapper)
            : base(userRoleService, mapper)
        {
        }
    }
}
