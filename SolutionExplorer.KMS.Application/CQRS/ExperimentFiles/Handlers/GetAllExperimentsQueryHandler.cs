using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Handlers
{
    public class GetAllExperimentsQueryHandler : IRequestHandler<GetAllExperimentsQuery, HandlerResponse<BaseGridDto<ExperimentDisplayDto>>>
    {
        private readonly IBaseService<Experiment> _service;

        public GetAllExperimentsQueryHandler(IBaseService<Experiment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<ExperimentDisplayDto>>> Handle(GetAllExperimentsQuery request, CancellationToken cancellationToken)
        {
            var items = _service
                .GetAll()
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .AsQueryable();
            var totalCount = await items.CountAsync();

            if(request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (request.SearchDto.IdentifierId.HasValue)
                        items = items.Where(x => x.IdentifierId == request.SearchDto.IdentifierId.Value);

                    if (request.SearchDto.FirstConfirmerUserId.HasValue)
                        items = items.Where(x => x.FirstConfirmerUserId == request.SearchDto.FirstConfirmerUserId.Value);

                    if (request.SearchDto.SecondConfirmerUserId.HasValue)
                        items = items.Where(x => x.SecondConfirmerUserId == request.SearchDto.SecondConfirmerUserId.Value);

                    if (request.SearchDto.IsActive.HasValue && request.SearchDto.IsActive > 0)
                        items = items.Where(x => x.IsActive == (request.SearchDto.IsActive.Value == 1));

                    if (!string.IsNullOrEmpty(request.SearchDto.Title))
                        items = items.Where(x => x.Title.Contains(request.SearchDto.Title));

                    if (!string.IsNullOrEmpty(request.SearchDto.Code))
                        items = items.Where(x => x.Code.Contains(request.SearchDto.Code));

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items = items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<ExperimentDisplayDto>()
            {
                Data = items.Adapt<List<ExperimentDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
