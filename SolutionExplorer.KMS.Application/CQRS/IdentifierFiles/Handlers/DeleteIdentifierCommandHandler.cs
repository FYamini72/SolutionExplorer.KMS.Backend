using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Handlers
{
    public class DeleteIdentifierCommandHandler : IRequestHandler<DeleteIdentifierCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<Identifier> _service;

        public DeleteIdentifierCommandHandler(IBaseService<Identifier> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteIdentifierCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
