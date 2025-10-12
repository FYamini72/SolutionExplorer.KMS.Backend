using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands
{
    public class DeleteIdentifierCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteIdentifierCommand(int id)
        {
            Id = id;
        }
    }
}