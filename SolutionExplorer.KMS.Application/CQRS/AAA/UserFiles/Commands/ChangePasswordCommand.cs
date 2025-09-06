using SolutionExplorer.KMS.Application.Dtos.AAA;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Commands
{
    public class ChangePasswordCommand : IRequest<HandlerResponse<bool>>
    {
        public UserChangePasswordDto User { get; }

        public ChangePasswordCommand(UserChangePasswordDto user)
        {
            User = user;
        }
    }
}
