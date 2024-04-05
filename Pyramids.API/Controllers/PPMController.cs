using AutoMapper;
using Pyramids.Core.Models;
using Pyramids.Core.IServices;
using Pyramids.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Pyramids.API.DTOs.PPM.Contract;
using Pyramids.API.DTOs.PPM.Visit;
using Pyramids.API.DTOs.PPM.Reminder;
using Contract = Pyramids.Core.Models.Contract;
using System.Security.Claims;
using Pyramids.API.DTOs.Auth;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PPMController : ResponseController
    {
        private readonly IMapper _mapper;
        private readonly IContractService _contractService;
        private readonly IVisitService _visitService;
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IReminderService _reminderService;
        public PPMController(IMapper mapper, IContractService contractService, IVisitService visitService,
            IReminderService reminderService,IUserService userService, IClientService clientService)

        {
            _mapper = mapper;
            _contractService = contractService;
            _visitService = visitService;
            _reminderService = reminderService;
            _userService = userService;
            _clientService = clientService;
        }

        #region Contract

        [HttpGet("GetContractList")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContractList(bool IsActive,int companyId)
        {

            try
            {
        
                IEnumerable<Contract> contracts = await _contractService.GetAllAsync(IsActive, companyId);

                var data = contracts?.Select(contract => new ContractDto
                {
                    Id = contract.Id,
                    JobTypeName = contract.JobType?.Name,
                    JobSubTypeName = contract.JobSubType?.Name,
                    ClientName = contract.Client?.Name,
                    ContractRef = contract.ContractRef,
                    Status = contract.Status,
                    BillingType = contract.BillingType,
                    StartDate = contract.StartDate,
                    ExpiryDate = contract.ExpiryDate,
                    IsActive = contract.IsActive,
                    NextVisitDate = contract.NextVisitDate.HasValue ? contract.NextVisitDate.Value : (DateTime?)null
                });


                var responseDataDto = new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = data,
                    Message = "Successful"
                };

                return Execute(responseDataDto);
            }

            catch (Exception ex)
            {
                return ResultRequest(HttpStatusCode.Forbidden, ex.Data, ex.Message);
            }

        }


        [HttpGet("GetContractById/{contractId}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetContractById(int contractId)
        {
            try
            {
                var contract = await _contractService.GetByIdAsync(contractId, "Client,JobType.JobSubTypes,Visits,Reminders");

                var responseDataDto = new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = _mapper.Map<ContractDto>(contract),
                    Message = "Successful"
                };

                return Execute(responseDataDto);
            }
            catch (Exception ex)
            {
                return ResultRequest(HttpStatusCode.Forbidden, ex.Data, ex.Message);
            }
         
        }



        [HttpPost("CreateContract")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateContract(ContractCreateDto contractCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return ResultRequest(HttpStatusCode.BadRequest, null, "Invalid data");
            }

            try
            {
                var client = await _clientService.GetByIdAsync(contractCreateDto.ClientId);
                var contract = _mapper.Map<Contract>(contractCreateDto);
                contract.Client = client;
                var createdContract = await _contractService.CreateContract(contract);

                var responseDataDto = new ResponseDataDto
                {
                    Code = HttpStatusCode.Created,
                    Data = createdContract,
                    Message = "Successful"
                };

                return Execute(responseDataDto);
            }
            catch (Exception ex)
            {
                return ResultRequest(HttpStatusCode.Forbidden, ex.Data, ex.Message);
            }
        }

        [HttpPut("UpdateContract/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> UpdateContract(int id, ContractUpdateDto contractUpdateDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Invalid Model"
                    });
                }

                var existingContract = await _contractService.GetByIdAsync(id);
                if (existingContract == null)
                {
                    return NotFound("Entity not found");
                }
                var mappedContract = _mapper.Map<Contract>(contractUpdateDto);

               await _contractService.UpdateContract(existingContract, mappedContract);

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


        [HttpDelete("DeleteContract/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteContract(int id)
        {
            try
            {
                var contract = await _contractService.GetByIdAsync(id);

                if (contract == null)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.NotFound
                    });
                }

                _contractService.Remove(contract);

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
        #endregion Contract


        #region Visit

        [HttpGet("GetVisitList")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVisitList(bool IsActive, int companyId)
        {

            try
            {
                IEnumerable<Visit> visits = await _visitService.GetAllAsync(IsActive, companyId);


                var responseDataDto = new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = _mapper.Map<IEnumerable<VisitDto>>(visits),
                    Message = "Successful"
                };

                return Execute(responseDataDto);

            }
            catch (Exception ex)
            {
                return ResultRequest(HttpStatusCode.Forbidden, ex.Data, ex.Message);
            }
        }

        [HttpPost("GenerateVisits")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateVisits(List<int> visitsId)
        {
            if (visitsId.Count == 0)
            {
                return ResultRequest(HttpStatusCode.BadRequest, null, "Invalid data");
            }

            try
            {
                var currentUser = GetCurrentUser();
                var user = await _userService.GetByIdAsync(currentUser.UserId); 

                await _visitService.GenerateJobVisitsAsync(visitsId, user); 

                var responseDataDto = new ResponseDataDto
                {
                    Code = HttpStatusCode.Created,
                    Data = null,
                    Message = "Successful"
                };

                return Execute(responseDataDto);
            }
            catch (Exception ex)
            {
                return ResultRequest(HttpStatusCode.Forbidden, ex.Data, ex.Message);
            }
        }

       

        #endregion



        #region Reminder

        [HttpGet("GetReminderList")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReminderList(int companyId, bool? seen=false)
        {

            try
            {
                var currentUser = GetCurrentUser();

                IEnumerable<Reminder> reminders = await _reminderService.GetAllAsync(currentUser.UserId, companyId, seen);

                var responseDataDto = new ResponseDataDto
                {
                    Code = HttpStatusCode.OK,
                    Data = _mapper.Map<IEnumerable<ReminderDto>>(reminders),
                    Message = "Successful"
                };

                return Execute(responseDataDto);

            }
            catch (Exception ex)
            {
                return ResultRequest(HttpStatusCode.Forbidden, ex.Data, ex.Message);
            }
        }

        [HttpPost("ReminderMarkSeen")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReminderMarkSeen(List<int> remindersId)
        {
            if (remindersId.Count == 0)
            {
                return ResultRequest(HttpStatusCode.BadRequest, null, "Invalid data");
            }

            try
            {
                var currentUser = GetCurrentUser();

                await _reminderService.MarkReminderSeenAsync(remindersId, currentUser.UserId);

                var responseDataDto = new ResponseDataDto
                {
                    Code = HttpStatusCode.Created,
                    Data = null,
                    Message = "Successful"
                };

                return Execute(responseDataDto);
            }
            catch (Exception ex)
            {
                return ResultRequest(HttpStatusCode.Forbidden, ex.Data, ex.Message);
            }
        }

        #endregion


        private CurrentUser GetCurrentUser()
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
