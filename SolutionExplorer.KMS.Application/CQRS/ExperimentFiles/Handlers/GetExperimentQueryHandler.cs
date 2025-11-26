using SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Handlers
{
    public class GetExperimentQueryHandler : IRequestHandler<GetExperimentQuery, HandlerResponse<ExperimentDisplayDto>>
    {
        private readonly IBaseService<Experiment> _service;

        public GetExperimentQueryHandler(IBaseService<Experiment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<ExperimentDisplayDto>> Handle(GetExperimentQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<ExperimentDisplayDto>();
        }
    }
}