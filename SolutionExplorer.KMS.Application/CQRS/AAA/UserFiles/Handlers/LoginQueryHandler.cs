using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;
using SolutionExplorer.KMS.Application.Utilities;
using Microsoft.EntityFrameworkCore;
using Mapster;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Queries;
using SolutionExplorer.KMS.Application.Services.Interfaces.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Handlers
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, HandlerResponse<UserAndTokenDisplayDto>>
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public LoginQueryHandler(IUserService userService
            , IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        public async Task<HandlerResponse<UserAndTokenDisplayDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var passwordHash = SecurityHelper.GetSha256Hash(request.Password);

            var user = await _userService
                .GetAll(x => x.UserName == request.UserName && 
                    x.PasswordHash == passwordHash)
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
                return new(false, "کاربر موردنظر یافت نشد", null);

            var jwt = await _jwtService.Generate(user);

            var result = user.Adapt<UserAndTokenDisplayDto>();
            result.Token = jwt;

            return result;
        }
    }
}
