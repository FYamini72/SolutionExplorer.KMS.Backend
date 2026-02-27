using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Handlers
{
    public class GetAllPeriodicQualityControlsQueryHandler : IRequestHandler<GetAllPeriodicQualityControlsQuery, HandlerResponse<BaseGridDto<PeriodicQualityControlDisplayDto>>>
    {
        private readonly IBaseService<PeriodicQualityControl> _service;

        public GetAllPeriodicQualityControlsQueryHandler(IBaseService<PeriodicQualityControl> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<PeriodicQualityControlDisplayDto>>> Handle(GetAllPeriodicQualityControlsQuery request, CancellationToken cancellationToken)
        {
            var items = _service
                .GetAll()
                .Include(x => x.PerformedByUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .AsQueryable()
                ;
            var totalCount = await items.CountAsync();

            if (request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (request.SearchDto.QualityControlBaseInfoId.HasValue)
                        items = items.Where(x => x.QualityControlBaseInfoId == request.SearchDto.QualityControlBaseInfoId.Value);

                    if (request.SearchDto.ManufactureDate.HasValue)
                        items = items.Where(x => x.ManufactureDate.Date == request.SearchDto.ManufactureDate.Value.Date);

                    if (request.SearchDto.PerformedByUserId.HasValue)
                        items = items.Where(x => x.PerformedByUserId == request.SearchDto.PerformedByUserId.Value);

                    if (request.SearchDto.ProductionDate.HasValue)
                        items = items.Where(x => x.ProductionDate.Date == request.SearchDto.ProductionDate.Value.Date);

                    if (request.SearchDto.ExpirationDate.HasValue)
                        items = items.Where(x => x.ExpirationDate.Date == request.SearchDto.ExpirationDate.Value.Date);

                    if (request.SearchDto.MediumType.HasValue)
                        items = items.Where(x => x.MediumType == request.SearchDto.MediumType.Value);

                    if (request.SearchDto.QualityControlPeriod.HasValue)
                        items = items.Where(x => x.QualityControlPeriod.HasFlag(request.SearchDto.QualityControlPeriod.Value));

                    if (request.SearchDto.QualityControlDate.HasValue)
                        items = items.Where(x => x.QualityControlDate.Date == request.SearchDto.QualityControlDate.Value.Date);

                    if (request.SearchDto.FirstConfirmerUserId.HasValue)
                        items = items.Where(x => x.FirstConfirmerUserId == request.SearchDto.FirstConfirmerUserId.Value);

                    if (request.SearchDto.SecondConfirmerUserId.HasValue)
                        items = items.Where(x => x.SecondConfirmerUserId == request.SearchDto.SecondConfirmerUserId.Value);

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<PeriodicQualityControlDisplayDto>()
            {
                Data = items.Adapt<List<PeriodicQualityControlDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
