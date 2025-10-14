using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Handlers
{
    public class GetEquipmentQueryHandler : IRequestHandler<GetEquipmentQuery, HandlerResponse<EquipmentDisplayDto>>
    {
        private readonly IBaseService<Equipment> _service;

        public GetEquipmentQueryHandler(IBaseService<Equipment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<EquipmentDisplayDto>> Handle(GetEquipmentQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<EquipmentDisplayDto>();
        }
    }
}