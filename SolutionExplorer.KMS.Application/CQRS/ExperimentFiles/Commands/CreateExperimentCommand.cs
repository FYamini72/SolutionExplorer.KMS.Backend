using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Commands
{
    public class CreateExperimentCommand : IRequest<HandlerResponse<ExperimentDisplayDto>>
    {
        public ExperimentCreateDto Experiment { get; }

        public CreateExperimentCommand(ExperimentCreateDto Experiment)
        {
            this.Experiment = Experiment;
        }
    }
}