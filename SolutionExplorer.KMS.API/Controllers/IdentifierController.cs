using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Queries;
using Microsoft.AspNetCore.Authorization;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    [Authorize]
    public class IdentifierController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<IdentifierCreateDto> _createValidator;
        private readonly IValidator<IdentifierSearchDto> _searchValidator;
        private readonly IValidator<IdentifierChangeFileAndDescriptionDto> _changeFileAndDescriptionValidator;

        public IdentifierController(IMediator mediator, IValidator<IdentifierCreateDto> createValidator, IValidator<IdentifierSearchDto> searchValidator, IValidator<IdentifierChangeFileAndDescriptionDto> changeFileAndDescriptionValidator)
        {
            this._mediator = mediator;
            this._createValidator = createValidator;
            this._searchValidator = searchValidator;
            this._changeFileAndDescriptionValidator = changeFileAndDescriptionValidator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<IdentifierDisplayDto>>> Get()
        {
            var query = new GetAllIdentifiersQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<IdentifierDisplayDto>> Get(int id)
        {
            var query = new GetIdentifierQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<IdentifierDisplayDto>>> Post(IdentifierSearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllIdentifiersQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<IdentifierDisplayDto>> Post(IdentifierCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateIdentifierCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<IdentifierDisplayDto>> Put(IdentifierCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdateIdentifierCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut("[action]")]
        public async Task<ApiResult<IdentifierDisplayDto>> ChangeFileAndDescription(IdentifierChangeFileAndDescriptionDto model)
        {
            var result = await _changeFileAndDescriptionValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdateIdentifierFileAndDescriptionCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeleteIdentifierCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }
    }
}
