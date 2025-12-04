using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class QualityControlBaseInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<QualityControlBaseInfoCreateDto> _createValidator;
        private readonly IValidator<QualityControlBaseInfoSearchDto> _searchValidator;
        private readonly IBaseService<QualityControlBaseInfo> _qualityControlBaseInfoService;
        private readonly IValidator<QualityControlCreateDto> _createQualityControlValidator;

        public QualityControlBaseInfoController(IMediator mediator, IValidator<QualityControlBaseInfoCreateDto> createValidator, IValidator<QualityControlBaseInfoSearchDto> searchValidator, IBaseService<QualityControlBaseInfo> qualityControlBaseInfoService, IValidator<QualityControlCreateDto> createQualityControlValidator)
        {
            this._mediator = mediator;
            this._createValidator = createValidator;
            this._searchValidator = searchValidator;
            _qualityControlBaseInfoService = qualityControlBaseInfoService;
            _createQualityControlValidator = createQualityControlValidator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<QualityControlBaseInfoDisplayDto>>> Get()
        {
            var query = new GetAllQualityControlBaseInfosQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<QualityControlBaseInfoDisplayDto>> Get(int id)
        {
            var query = new GetQualityControlBaseInfoQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<QualityControlBaseInfoDisplayDto>>> Post(QualityControlBaseInfoSearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllQualityControlBaseInfosQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<QualityControlBaseInfoDisplayDto>> Post(QualityControlBaseInfoCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateQualityControlBaseInfoCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<QualityControlBaseInfoDisplayDto>> Put(QualityControlBaseInfoCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdateQualityControlBaseInfoCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        //[HttpPut("[action]")]
        //public async Task<ApiResult<QualityControlBaseInfoDisplayDto>> SetDefaultValue(QualityControlCreateDto model, CancellationToken cancellationToken)
        //{
        //    var validationResult = await _createQualityControlValidator.ValidateAsync(model);

        //    if (!validationResult.IsValid)
        //    {
        //        validationResult.AddToModelState(ModelState);
        //        return BadRequest(ModelState);
        //    }

        //    var qualityControlBaseInfo = await _qualityControlBaseInfoService.GetByIdAsync(cancellationToken, model.QualityControlBaseInfoId);

        //    if (qualityControlBaseInfo == null)
        //        return NotFound();

        //    qualityControlBaseInfo.DefaultValue = JsonConvert.SerializeObject(model);
        //    var obj = await _qualityControlBaseInfoService.UpdateAsync(qualityControlBaseInfo, cancellationToken);
        //    var result = obj.Adapt<QualityControlBaseInfoDisplayDto>();

        //    return Ok(result);
        //}

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeleteQualityControlBaseInfoCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }
    }
}
