using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Commands
{
    public class ChangeActivationStatusExperimentCommand : IRequest<HandlerResponse<ExperimentDisplayDto>>
    {
        public ExperimentChangeActivationStatusDto Experiment { get; }

        public ChangeActivationStatusExperimentCommand(ExperimentChangeActivationStatusDto Experiment)
        {
            this.Experiment = Experiment;
        }
    }
}