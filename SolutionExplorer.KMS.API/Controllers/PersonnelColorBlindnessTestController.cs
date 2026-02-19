using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class PersonnelColorBlindnessTestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<PersonnelColorBlindnessTestCreateDto> _createValidator;
        private readonly IValidator<PersonnelColorBlindnessTestSearchDto> _searchValidator;

        public PersonnelColorBlindnessTestController(IMediator mediator, IValidator<PersonnelColorBlindnessTestCreateDto> createValidator, IValidator<PersonnelColorBlindnessTestSearchDto> searchValidator)
        {
            this._mediator = mediator;
            this._createValidator = createValidator;
            this._searchValidator = searchValidator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<PersonnelColorBlindnessTestDisplayDto>>> Get()
        {
            var query = new GetAllPersonnelColorBlindnessTestsQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<PersonnelColorBlindnessTestDisplayDto>> Get(int id)
        {
            var query = new GetPersonnelColorBlindnessTestQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<PersonnelColorBlindnessTestDisplayDto>>> Post(PersonnelColorBlindnessTestSearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllPersonnelColorBlindnessTestsQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<PersonnelColorBlindnessTestDisplayDto>> Post(PersonnelColorBlindnessTestCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreatePersonnelColorBlindnessTestCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<PersonnelColorBlindnessTestDisplayDto>> Put(PersonnelColorBlindnessTestCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdatePersonnelColorBlindnessTestCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeletePersonnelColorBlindnessTestCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }
    }
}
