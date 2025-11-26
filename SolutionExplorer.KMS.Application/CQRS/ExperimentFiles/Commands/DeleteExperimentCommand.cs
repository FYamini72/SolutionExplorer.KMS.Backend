using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Commands
{
    public class DeleteExperimentCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteExperimentCommand(int id)
        {
            Id = id;
        }
    }
}