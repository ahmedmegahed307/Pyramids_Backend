using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using Pyramids.API.DTOs;
using Pyramids.Core.IServices;
using Pyramids.Shared.Entity;
using Pyramids.API.DTOs.Response;

namespace Pyramids.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity,TDto, TCreateDto, TUpdateDto> : ResponseController
    where TEntity : EntityBase
    where TDto : EntityBaseDto
    where TCreateDto : EntityBaseDto
    where TUpdateDto : EntityBaseDto
    {
        private readonly IService<TEntity> _service;
        private readonly IMapper _mapper;

        protected BaseController(IService<TEntity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetAll(bool? isActive =null, int? companyId = null)
        {
            
            var entities = await _service.GetAllAsync(isActive, companyId);
            Log.Information("GetAll method called for => {@entities}", entities);
            var data = _mapper.Map<IEnumerable<TDto>>(entities);

            var ResponseDataDto = new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = data,
                Message = "Successful"
            };

            return Execute(ResponseDataDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);

            if (entity == null)
            {
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.NotFound,
                    Data = null,
                  
                });
            }

            return Execute(new ResponseDataDto
            {
                Code = HttpStatusCode.OK,
                Data = _mapper.Map<TDto>(entity),
                Message = "Successful"
            });
        }

        [HttpPost]
      //  [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> Create(TCreateDto dto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Invalid Model"
                    });
                }
                var newEntity = await _service.AddAsync(_mapper.Map<TEntity>(dto));

                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.Created,
                    Data = _mapper.Map<TCreateDto>(newEntity),
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {

                var innerException = ex.InnerException;
                return Execute(new ResponseDataDto
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = "failed"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Update(int id,  TUpdateDto dto)
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

                var existingEntity = await _service.GetByIdAsync(id);
                if (existingEntity == null)
                {
                    return NotFound("Entity not found");
                }

                _mapper.Map(dto, existingEntity);

                await _service.Update(id, existingEntity);

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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);

                if (entity == null)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.NotFound
                    });
                }

                _service.Remove(entity);

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


        [HttpPost("restore/{id}")]
        public async Task<IActionResult> Restore(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);

                if (entity == null)
                {
                    return Execute(new ResponseDataDto
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = "Entity not found"
                    });
                }

                _service.Restore(entity);

                return Execute(new ResponseDataDto
                {
                    Message = "Entity has been Restored",
                    Code = HttpStatusCode.OK,
                    Data = _mapper.Map<TDto>(entity)
                    
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
    }



}
