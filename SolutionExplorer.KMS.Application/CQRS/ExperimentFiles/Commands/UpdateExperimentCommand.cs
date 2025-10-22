using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Commands
{
    public class UpdateExperimentCommand : IRequest<HandlerResponse<ExperimentDisplayDto>>
    {
        public ExperimentCreateDto Experiment { get; }

        public UpdateExperimentCommand(ExperimentCreateDto Experiment)
        {
            this.Experiment = Experiment;
        }
    }
}