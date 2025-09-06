using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Commands;
using SolutionExplorer.KMS.Application.Services.Interfaces.AAA;
using SolutionExplorer.KMS.Application.Utilities;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Handlers
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, HandlerResponse<bool>>
    {
        private readonly IUserService _userService;

        public ChangePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<HandlerResponse<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var obj = await _userService
                .GetAll(x => x.UserName == request.User.UserName && 
                             x.PasswordHash == request.User.OldPassword.GetSha256Hash())
                .FirstOrDefaultAsync();

            if (obj == null)
                return new(false, ";کاربر مورد نظر یافت نشد", false);
            
            request.User.Id = obj.Id;
            request.User.Adapt(obj);

            obj.PasswordHash = request.User.NewPassword.GetSha256Hash();
            obj.SecurityStamp = Guid.NewGuid();

            await _userService.UpdateAsync(obj, cancellationToken);

            return true;
        }
    }
}
