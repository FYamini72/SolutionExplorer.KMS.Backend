using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Handlers
{
    public class GetAllQualityControlBaseInfosQueryHandler : IRequestHandler<GetAllQualityControlBaseInfosQuery, HandlerResponse<BaseGridDto<QualityControlBaseInfoDisplayDto>>>
    {
        private readonly IBaseService<QualityControlBaseInfo> _service;

        public GetAllQualityControlBaseInfosQueryHandler(IBaseService<QualityControlBaseInfo> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<QualityControlBaseInfoDisplayDto>>> Handle(GetAllQualityControlBaseInfosQuery request, CancellationToken cancellationToken)
        {
            var items = _service.GetAll();
            var totalCount = await items.CountAsync();

            if (request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (!string.IsNullOrEmpty(request.SearchDto.Title))
                        items = items.Where(x => x.Title.Contains(request.SearchDto.Title));

                    //if (!string.IsNullOrEmpty(request.SearchDto.Manufacturer))
                    //    items = items.Where(x => x.Manufacturer.Contains(request.SearchDto.Manufacturer));

                    //if (!string.IsNullOrEmpty(request.SearchDto.Series))
                    //    items = items.Where(x => x.Series.Contains(request.SearchDto.Series));

                    //if (request.SearchDto.ProductionDate.HasValue)
                    //    items = items.Where(x => x.ProductionDate == request.SearchDto.ProductionDate.Value);

                    //if (request.SearchDto.ExpirationDate.HasValue)
                    //    items = items.Where(x => x.ExpirationDate == request.SearchDto.ExpirationDate.Value);

                    if (request.SearchDto.FromNextQualityControlTime.HasValue)
                        items = items.Where(x => x.NextQualityControlTime >= request.SearchDto.FromNextQualityControlTime.Value);

                    if (request.SearchDto.ToNextQualityControlTime.HasValue)
                        items = items.Where(x => x.NextQualityControlTime <= request.SearchDto.ToNextQualityControlTime.Value);

                    if (request.SearchDto.QualityControlPeriod.HasValue)
                        items = items.Where(x => x.QualityControlPeriod == request.SearchDto.QualityControlPeriod.Value);

                    if (request.SearchDto.Category.HasValue)
                        items = items.Where(x => x.Category == request.SearchDto.Category.Value);

                    if (request.SearchDto.DayIntervalCount.HasValue)
                        items = items.Where(x => x.DayIntervalCount == request.SearchDto.DayIntervalCount.Value);

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<QualityControlBaseInfoDisplayDto>()
            {
                Data = items.Adapt<List<QualityControlBaseInfoDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
