using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Handlers
{
    public class UpdateIdentifierCommandHandler : IRequestHandler<UpdateIdentifierCommand, HandlerResponse<IdentifierDisplayDto>>
    {
        private readonly IBaseService<Identifier> _service;

        public UpdateIdentifierCommandHandler(IBaseService<Identifier> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<IdentifierDisplayDto>> Handle(UpdateIdentifierCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.ProducerUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(x => x.Id == request.Identifier.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.Identifier.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            return result.Adapt<IdentifierDisplayDto>();
        }
    }
}
