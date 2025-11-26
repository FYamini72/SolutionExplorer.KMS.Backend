using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Handlers
{
    public class CreateReferenceCommandHandler : IRequestHandler<CreateReferenceCommand, HandlerResponse<ReferenceDisplayDto>>
    {
        private readonly IBaseService<Reference> _service;
        private readonly IAttachmentFileService _attachmentFileService;
        private readonly IBaseService<Identifier> _identifierService;

        public CreateReferenceCommandHandler(IBaseService<Reference> service, IAttachmentFileService attachmentFileService, IBaseService<Identifier> identifierService)
        {
            _service = service;
            _attachmentFileService = attachmentFileService;
            _identifierService = identifierService;
        }

        public async Task<HandlerResponse<ReferenceDisplayDto>> Handle(CreateReferenceCommand request, CancellationToken cancellationToken)
        {
            var reference = request.Reference.Adapt<Reference>();

            reference.IdentifierId = await _identifierService
                .GetAll(x => x.IdentifierType == IdentifierType.References)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            if (request.Reference.SelectedFile == null || request.Reference.SelectedFile.Length <= 0)
                return new(false, "انتخاب فایل پیوست الزامی می‌باشد.", null);

            reference.AttachmentFile = await _attachmentFileService.UploadFile(request.Reference.SelectedFile, FileCategory.References, cancellationToken);

            var result = await _service.AddAsync(reference, cancellationToken);
            result.AttachmentFile = await _attachmentFileService.GetByIdAsync(cancellationToken, result.AttachmentFileId);
            return result.Adapt<ReferenceDisplayDto>();
        }
    }
}
