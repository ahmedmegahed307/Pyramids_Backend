using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Pyramids.API.DTOs.Notification;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.API.DTOs.Response;
using System.Diagnostics.Contracts;
using Pyramids.API.DTOs.PPM.Contract;

namespace Pyramids.API.Controllers
{
    
    public class NotificationController : BaseController<Notification, NotificationDto, NotificationCreateDto, NotificationUpdateDto>
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
            : base(notificationService, mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<IActionResult> GetAll(bool? isActive = null, int? companyId = null)
        {

            IEnumerable<Notification> notifications = await _notificationService.GetAllAsync(isActive, companyId,"CreatedByUser");
             var data = notifications?.Select(notification => new NotificationDto
             {
                 Id = notification.Id,
                 Message = notification.Message,
                 UserFullName = notification.CreatedByUser.FirstName +" "+ notification.CreatedByUser.LastName,
                 CompanyId = notification.CompanyId,
                 CreatedAt = notification.CreatedAt,
               
             }).OrderByDescending(a=>a.Id);

            var ResponseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Message = "Successful"
            };

            return Execute(ResponseDataDto);
        }
    }
}
