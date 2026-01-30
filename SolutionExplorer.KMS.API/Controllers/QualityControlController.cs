using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class QualityControlController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<QualityControlCreateDto> _createValidator;
        private readonly IValidator<QualityControlSearchDto> _searchValidator;
        private readonly IBaseService<QualityControl> _qualityControlService;

        public QualityControlController(IMediator mediator, IValidator<QualityControlCreateDto> createValidator, IValidator<QualityControlSearchDto> searchValidator, IBaseService<QualityControl> qualityControlService)
        {
            this._mediator = mediator;
            this._createValidator = createValidator;
            this._searchValidator = searchValidator;
            _qualityControlService = qualityControlService;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<QualityControlDisplayDto>>> Get()
        {
            var query = new GetAllQualityControlsQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<QualityControlDisplayDto>> Get(int id)
        {
            var query = new GetQualityControlQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<QualityControlDisplayDto>>> Post(QualityControlSearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllQualityControlsQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<QualityControlDisplayDto>> Post(QualityControlCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateQualityControlCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<QualityControlDisplayDto>> Put(QualityControlCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdateQualityControlCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeleteQualityControlCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("[action]/{QualityControlBaseInfoId:int}")]
        public async Task<ApiResult<QualityControlDisplayDto>> GetLatestConfirmedQCData(int QualityControlBaseInfoId)
        {
            var latest = await _qualityControlService
                .GetAll(c => c.QualityControlBaseInfoId == QualityControlBaseInfoId)
                .Include(x => x.PhysicalSpecifications)
                    .ThenInclude(x=>x.QCBaseInfoPhysicalSpecification)
                .Include(x=>x.QualityControlResults)
                    .ThenInclude(x=>x.QCBaseInfoExpectedResult)
                .Include(x=>x.StorageCondition)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (latest == null)
                return NotFound("رکوردی یافت نشد.");

            return latest.Adapt<QualityControlDisplayDto>();
        }
    }
}
