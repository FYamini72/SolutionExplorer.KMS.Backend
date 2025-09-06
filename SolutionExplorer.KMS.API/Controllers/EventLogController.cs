using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.EventLogFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.EventLogFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class EventLogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventLogController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<EventLogDisplayDto>>> Get()
        {
            var query = new GetAllEventLogsQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<EventLogDisplayDto>> Get(int id)
        {
            var query = new GetEventLogQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<EventLogDisplayDto>>> Post(EventLogSearchDto model)
        {
            var query = new GetAllEventLogsQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<EventLogDisplayDto>> Post(EventLogCreateDto model)
        {
            var command = new CreateEventLogCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }
    }
}
