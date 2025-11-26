using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Commands
{
    public class DeleteReferenceCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteReferenceCommand(int id)
        {
            Id = id;
        }
    }
}