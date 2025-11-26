using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Handlers
{
    public class GetReferenceQueryHandler : IRequestHandler<GetReferenceQuery, HandlerResponse<ReferenceDisplayDto>>
    {
        private readonly IBaseService<Reference> _service;

        public GetReferenceQueryHandler(IBaseService<Reference> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<ReferenceDisplayDto>> Handle(GetReferenceQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.AttachmentFile)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<ReferenceDisplayDto>();
        }
    }
}