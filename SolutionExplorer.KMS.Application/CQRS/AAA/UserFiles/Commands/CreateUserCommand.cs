using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Commands
{
    public class CreateUserCommand : IRequest<HandlerResponse<UserDisplayDto>>
    {
        public UserCreateDto User { get; }

        public CreateUserCommand(UserCreateDto user)
        {
            User = user;
        }
    }
}