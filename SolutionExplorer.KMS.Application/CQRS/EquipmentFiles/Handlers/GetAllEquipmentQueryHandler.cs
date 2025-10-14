using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Handlers
{
    public class GetAllEquipmentQueryHandler : IRequestHandler<GetAllEquipmentQuery, HandlerResponse<BaseGridDto<EquipmentDisplayDto>>>
    {
        private readonly IBaseService<Equipment> _service;

        public GetAllEquipmentQueryHandler(IBaseService<Equipment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<EquipmentDisplayDto>>> Handle(GetAllEquipmentQuery request, CancellationToken cancellationToken)
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

                    if (request.SearchDto.FirstConfirmerUserId.HasValue)
                        items = items.Where(x => x.FirstConfirmerUserId == request.SearchDto.FirstConfirmerUserId.Value);

                    if (request.SearchDto.SecondConfirmerUserId.HasValue)
                        items = items.Where(x => x.SecondConfirmerUserId == request.SearchDto.SecondConfirmerUserId.Value);

                    if (request.SearchDto.IdentifierId.HasValue)
                        items = items.Where(x => x.IdentifierId == request.SearchDto.IdentifierId.Value);

                    if (!string.IsNullOrEmpty(request.SearchDto.Title))
                        items = items.Where(x => x.Title.Contains(request.SearchDto.Title));

                    if (!string.IsNullOrEmpty(request.SearchDto.Manufacturer))
                        items = items.Where(x => x.Manufacturer.Contains(request.SearchDto.Manufacturer));

                    if (!string.IsNullOrEmpty(request.SearchDto.ManufactureCountry))
                        items = items.Where(x => x.ManufactureCountry.Contains(request.SearchDto.ManufactureCountry));

                    if (!string.IsNullOrEmpty(request.SearchDto.EquipmentModel))
                        items = items.Where(x => x.EquipmentModel.Contains(request.SearchDto.EquipmentModel));

                    if (!string.IsNullOrEmpty(request.SearchDto.Code))
                        items = items.Where(x => x.Code.Contains(request.SearchDto.Code));

                    if (!string.IsNullOrEmpty(request.SearchDto.SerialNo))
                        items = items.Where(x => x.SerialNo.Contains(request.SearchDto.SerialNo));

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<EquipmentDisplayDto>()
            {
                Data = items.Adapt<List<EquipmentDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
