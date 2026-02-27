using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class PeriodicQualityControlController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<PeriodicQualityControlCreateDto> _createValidator;
        private readonly IValidator<PeriodicQualityControlSearchDto> _searchValidator;
        private readonly IBaseService<PeriodicQualityControl> _periodicQualityControlService;

        public PeriodicQualityControlController(IMediator mediator, IValidator<PeriodicQualityControlCreateDto> createValidator, IValidator<PeriodicQualityControlSearchDto> searchValidator)
        {
            this._mediator = mediator;
            this._createValidator = createValidator;
            this._searchValidator = searchValidator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<PeriodicQualityControlDisplayDto>>> Get()
        {
            var query = new GetAllPeriodicQualityControlsQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<PeriodicQualityControlDisplayDto>> Get(int id)
        {
            var query = new GetPeriodicQualityControlQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<PeriodicQualityControlDisplayDto>>> Post(PeriodicQualityControlSearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllPeriodicQualityControlsQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<PeriodicQualityControlDisplayDto>> Post(PeriodicQualityControlCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreatePeriodicQualityControlCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<PeriodicQualityControlDisplayDto>> Put(PeriodicQualityControlCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdatePeriodicQualityControlCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeletePeriodicQualityControlCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("[action]/{qualityControlBaseInfoId:int}")]
        public async Task<ApiResult<PeriodicQualityControlDisplayDto>> GetLatestConfirmedQCData(int qualityControlBaseInfoId)
        {
            var latest = await _periodicQualityControlService
                .GetAll(c => c.QualityControlBaseInfoId == qualityControlBaseInfoId)
                .Include(x => x.PhysicalSpecifications)
                    .ThenInclude(x => x.QCBaseInfoPhysicalSpecification)
                //.Include(x => x.QualityControlResults)
                //    .ThenInclude(x => x.QCBaseInfoExpectedResult)
                //.Include(x => x.StorageCondition)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (latest == null)
                return NotFound("رکوردی یافت نشد.");

            return latest.Adapt<PeriodicQualityControlDisplayDto>();
        }
    }
}
