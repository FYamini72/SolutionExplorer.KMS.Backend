using SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Handlers
{
    public class DeleteReferenceCommandHandler : IRequestHandler<DeleteReferenceCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<Reference> _service;

        public DeleteReferenceCommandHandler(IBaseService<Reference> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteReferenceCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
