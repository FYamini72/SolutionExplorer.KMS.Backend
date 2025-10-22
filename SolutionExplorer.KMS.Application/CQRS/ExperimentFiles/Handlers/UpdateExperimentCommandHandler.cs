using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Handlers
{
    public class UpdateExperimentCommandHandler : IRequestHandler<UpdateExperimentCommand, HandlerResponse<ExperimentDisplayDto>>
    {
        private readonly IBaseService<Experiment> _service;

        public UpdateExperimentCommandHandler(IBaseService<Experiment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<ExperimentDisplayDto>> Handle(UpdateExperimentCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(x => x.Id == request.Experiment.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.Experiment.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            return result.Adapt<ExperimentDisplayDto>();
        }
    }
}
