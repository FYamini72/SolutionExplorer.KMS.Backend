using SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Handlers
{
    public class CreateExperimentCommandHandler : IRequestHandler<CreateExperimentCommand, HandlerResponse<ExperimentDisplayDto>>
    {
        private readonly IBaseService<Experiment> _service;

        public CreateExperimentCommandHandler(IBaseService<Experiment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<ExperimentDisplayDto>> Handle(CreateExperimentCommand request, CancellationToken cancellationToken)
        {
            var Experiment = request.Experiment.Adapt<Experiment>();

            var result = await _service.AddAsync(Experiment, cancellationToken);
            return result.Adapt<ExperimentDisplayDto>();
        }
    }
}
