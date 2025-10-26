using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Queries;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class LabReportHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<LabReportHistoryCreateDto> _createValidator;
        private readonly IValidator<LabReportHistorySearchDto> _searchValidator;

        public LabReportHistoryController(IMediator mediator, IValidator<LabReportHistoryCreateDto> createValidator, IValidator<LabReportHistorySearchDto> searchValidator)
        {
            this._mediator = mediator;
            this._createValidator = createValidator;
            this._searchValidator = searchValidator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<LabReportHistoryDisplayDto>>> Get()
        {
            var query = new GetAllLabReportHistoriesQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<LabReportHistoryDisplayDto>> Get(int id)
        {
            var query = new GetLabReportHistoryQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<LabReportHistoryDisplayDto>>> Post([FromBody] LabReportHistorySearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllLabReportHistoriesQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<LabReportHistoryDisplayDto>> Post(LabReportHistoryCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateLabReportHistoryCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<LabReportHistoryDisplayDto>> Put(LabReportHistoryCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdateLabReportHistoryCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeleteLabReportHistoryCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }
    }
}
