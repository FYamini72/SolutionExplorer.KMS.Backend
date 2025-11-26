using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Queries;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class EquipmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<EquipmentCreateDto> _createValidator;
        private readonly IValidator<EquipmentSearchDto> _searchValidator;

        public EquipmentController(IMediator mediator, IValidator<EquipmentCreateDto> createValidator, IValidator<EquipmentSearchDto> searchValidator)
        {
            this._mediator = mediator;
            this._createValidator = createValidator;
            this._searchValidator = searchValidator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<EquipmentDisplayDto>>> Get()
        {
            var query = new GetAllEquipmentQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<EquipmentDisplayDto>> Get(int id)
        {
            var query = new GetEquipmentQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<EquipmentDisplayDto>>> Post(EquipmentSearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllEquipmentQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<EquipmentDisplayDto>> Post(EquipmentCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateEquipmentCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<EquipmentDisplayDto>> Put(EquipmentCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdateEquipmentCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeleteEquipmentCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }
    }
}
