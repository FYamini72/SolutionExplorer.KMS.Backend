using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class ExperimentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<ExperimentCreateDto> _createValidator;
        private readonly IValidator<ExperimentSearchDto> _searchValidator;

        public ExperimentController(IMediator mediator, IValidator<ExperimentCreateDto> createValidator, IValidator<ExperimentSearchDto> searchValidator)
        {
            this._mediator = mediator;
            this._createValidator = createValidator;
            this._searchValidator = searchValidator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<ExperimentDisplayDto>>> Get()
        {
            var query = new GetAllExperimentsQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<ExperimentDisplayDto>> Get(int id)
        {
            var query = new GetExperimentQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<ExperimentDisplayDto>>> Post(ExperimentSearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllExperimentsQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<ExperimentDisplayDto>> Post(ExperimentCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateExperimentCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<ExperimentDisplayDto>> Put(ExperimentCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdateExperimentCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut("[action]")]
        public async Task<ApiResult<ExperimentDisplayDto>> ChangeActivationStatus(ExperimentChangeActivationStatusDto model)
        {
            var command = new ChangeActivationStatusExperimentCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeleteExperimentCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }
    }
}
