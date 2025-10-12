using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Handlers
{
    public class GetIdentifierQueryHandler : IRequestHandler<GetIdentifierQuery, HandlerResponse<IdentifierDisplayDto>>
    {
        private readonly IBaseService<Identifier> _service;

        public GetIdentifierQueryHandler(IBaseService<Identifier> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<IdentifierDisplayDto>> Handle(GetIdentifierQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.ProducerUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<IdentifierDisplayDto>();
        }
    }
}