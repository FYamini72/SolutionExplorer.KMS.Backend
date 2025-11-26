using MediatR;
using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Handlers
{
    public class DeleteIdentifierCommandHandler : IRequestHandler<DeleteIdentifierCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<Identifier> _service;
        private readonly IAttachmentFileService _attachmentFileService;

        public DeleteIdentifierCommandHandler(IBaseService<Identifier> service, IAttachmentFileService attachmentFileService)
        {
            _service = service;
            _attachmentFileService = attachmentFileService;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteIdentifierCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            if (obj.AttachmentFileId.HasValue)
                await _attachmentFileService.DeleteAsync(obj.AttachmentFileId.Value, cancellationToken);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
