using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Queries;
using SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Commands;
using SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.API.Controllers.AAA
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<LoginDto> _loginValidator;
        private readonly IValidator<UserCreateDto> _userCreateValidator;
        private readonly IValidator<UserUpdateDto> _userUpdateValidator;
        private readonly IValidator<UserChangePasswordDto> _userChangePasswordValidator;
        private readonly IValidator<UserSearchDto> _searchValidator;

        public UserController(IMediator mediator
            , IValidator<LoginDto> loginValidator
            , IValidator<UserCreateDto> userCreateValidator
            , IValidator<UserUpdateDto> userUpdateValidator
            , IValidator<UserChangePasswordDto> userChangePasswordValidator
            , IValidator<UserSearchDto> searchValidator)
        {
            this._mediator = mediator;
            this._loginValidator = loginValidator;
            this._userCreateValidator = userCreateValidator;
            this._userUpdateValidator = userUpdateValidator;
            this._userChangePasswordValidator = userChangePasswordValidator;
            this._searchValidator = searchValidator;
        }

        [HttpGet]
        public async Task<ApiResult<BaseGridDto<UserDisplayDto>>> Get()
        {
            var query = new GetAllUsersQuery(null);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResult<UserDisplayDto>> Get(int id)
        {
            var query = new GetUserQuery(id);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPost("GetByFilter")]
        public async Task<ApiResult<BaseGridDto<UserDisplayDto>>> Post(UserSearchDto model)
        {
            var result = await _searchValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new GetAllUsersQuery(model);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }


        [HttpPost("[action]")]
        public async Task<ApiResult<UserAndTokenDisplayDto>> Login(LoginDto model)
        {
            var validationResult = await _loginValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var query = new LoginQuery(model.UserName, model.Password);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        /// <summary>
        /// درصورتی که درخواست کاربر به این متد برسد، معتبر بودن توکن تضمین می‌شود
        /// </summary>
        /// <returns>درصورتی که درخواست به این متد برسد وضعیت 200 و درغیراین صورت بصورت خودکار وضعیت 400 برگشت داده خواهد شد</returns>
        [HttpGet("[action]")]
        [Authorize]
        public ApiResult<string> CheckTokenValidation()
        {
            var username = User?.Identity?.Name ?? String.Empty;

            return Ok(username);
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<UserDisplayDto>> CreateUser([FromBody] UserCreateDto model)
        {
            var validationResult = await _userCreateValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new CreateUserCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpGet("[action]")]
        public async Task<ApiResult<UserDisplayDto>> GetUserByUsername(string Username)
        {
            var query = new GetUserByUsernameQuery(Username);
            var handlerResponse = await _mediator.Send(query);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut("[action]")]
        public async Task<ApiResult<UserDisplayDto>> UpdateUser([FromBody] UserUpdateDto model)
        {
            var result = await _userUpdateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new UpdateUserCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok(handlerResponse.Data);

            return BadRequest(handlerResponse.Message);
        }

        [HttpPut("[action]")]
        public async Task<ApiResult> ChangePassword(UserChangePasswordDto model)
        {
            var result = await _userChangePasswordValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var command = new ChangePasswordCommand(model);
            var handlerResponse = await _mediator.Send(command);

            if (handlerResponse.Status)
                return Ok();

            return BadRequest(handlerResponse.Message);
        }
    }
}