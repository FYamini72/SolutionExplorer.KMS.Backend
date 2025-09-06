using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Queries
{
    public class LoginQuery : IRequest<HandlerResponse<UserAndTokenDisplayDto>>
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
