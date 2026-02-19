using MediatR;
using SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Commands;
using SolutionExplorer.KMS.Application.Services.Implementations;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Handlers
{
    public class DeletePersonnelCommandHandler : IRequestHandler<DeletePersonnelCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<Personnel> _service;
        private readonly IAttachmentFileService _attachmentFileService;

        public DeletePersonnelCommandHandler(IBaseService<Personnel> service, IAttachmentFileService attachmentFileService)
        {
            _service = service;
            _attachmentFileService = attachmentFileService;
        }

        public async Task<HandlerResponse<bool>> Handle(DeletePersonnelCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            if (obj.ProfileId.HasValue)
                await _attachmentFileService.DeleteAsync(obj.ProfileId.Value, cancellationToken);

            if (obj.ProfileId.HasValue)
                await _attachmentFileService.DeleteAsync(obj.ProfileId.Value, cancellationToken);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
