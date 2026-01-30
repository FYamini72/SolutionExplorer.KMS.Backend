using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Handlers
{
    public class GetAllQualityControlsQueryHandler : IRequestHandler<GetAllQualityControlsQuery, HandlerResponse<BaseGridDto<QualityControlDisplayDto>>>
    {
        private readonly IBaseService<QualityControl> _service;

        public GetAllQualityControlsQueryHandler(IBaseService<QualityControl> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<QualityControlDisplayDto>>> Handle(GetAllQualityControlsQuery request, CancellationToken cancellationToken)
        {
            var items = _service
                .GetAll(x => !x.IsDefaultValue)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .Include(x => x.PerformedByUser)
                .Include(x => x.StorageCondition)
                .Include(x => x.PhysicalSpecifications)
                    .ThenInclude(x => x.QCBaseInfoPhysicalSpecification)
                .AsQueryable();
            var totalCount = await items.CountAsync();

            if(request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (request.SearchDto.QualityControlBaseInfoId.HasValue)
                        items = items.Where(x => x.QualityControlBaseInfoId == request.SearchDto.QualityControlBaseInfoId);

                    if (request.SearchDto.PerformedByUserId.HasValue)
                        items = items.Where(x => x.PerformedByUserId == request.SearchDto.PerformedByUserId);

                    //if (!string.IsNullOrEmpty(request.SearchDto.PhysicalSpecification))
                    //    items = items.Where(x => x.PhysicalSpecification.Contains(request.SearchDto.PhysicalSpecification));

                    if (request.SearchDto.FirstConfirmerUserId.HasValue)
                        items = items.Where(x => x.FirstConfirmerUserId == request.SearchDto.FirstConfirmerUserId);

                    if (request.SearchDto.SecondConfirmerUserId.HasValue)
                        items = items.Where(x => x.SecondConfirmerUserId == request.SearchDto.SecondConfirmerUserId);

                    if (request.SearchDto.IsConfirmed.HasValue && request.SearchDto.IsConfirmed > 0)
                        items = items.Where(x => x.IsConfirmed == (request.SearchDto.IsConfirmed.Value == 1));

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<QualityControlDisplayDto>()
            {
                Data = items.Adapt<List<QualityControlDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
