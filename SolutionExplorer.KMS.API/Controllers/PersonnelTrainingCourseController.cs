using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class PersonnelTrainingCourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<PersonnelTrainingCourseCreateDto> _createValidator;
        private readonly IValidator<PersonnelTrainingCourseSearchDto> _searchValidator;

        public PersonnelTrainingCourseController(IMediator mediator, IValidator<PersonnelTrainingCourseCreateDto> createValidator, IValidator<PersonnelTrainingCourseSearchDto> searchValidator)
        {
            this._mediator = mediator;
            this._createValidator = createValidator;
            this._searchValidator = searchValidator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<PersonnelTrainingCourseDisplayDto>>> Get()
        {
            var query = new GetAllPersonnelTrainingCoursesQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<PersonnelTrainingCourseDisplayDto>> Get(int id)
        {
            var query = new GetPersonnelTrainingCourseQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<PersonnelTrainingCourseDisplayDto>>> Post(PersonnelTrainingCourseSearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllPersonnelTrainingCoursesQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost]
        public async Task<ApiResult<PersonnelTrainingCourseDisplayDto>> Post(PersonnelTrainingCourseCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreatePersonnelTrainingCourseCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut]
        public async Task<ApiResult<PersonnelTrainingCourseDisplayDto>> Put(PersonnelTrainingCourseCreateDto model)
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdatePersonnelTrainingCourseCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            var command = new DeletePersonnelTrainingCourseCommand(id);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }
    }
}
