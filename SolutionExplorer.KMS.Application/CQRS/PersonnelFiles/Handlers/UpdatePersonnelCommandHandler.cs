using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Application.Services.Implementations;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Handlers
{
    public class UpdatePersonnelCommandHandler : IRequestHandler<UpdatePersonnelCommand, HandlerResponse<PersonnelDisplayDto>>
    {
        private readonly IBaseService<Personnel> _service;
        private readonly IAttachmentFileService _attachmentFileService;
        private readonly IBaseService<UserRole> _userRoleService;

        public UpdatePersonnelCommandHandler(IBaseService<Personnel> service, IAttachmentFileService attachmentFileService, IBaseService<UserRole> userRoleService = null)
        {
            _service = service;
            _attachmentFileService = attachmentFileService;
            _userRoleService = userRoleService;
        }

        public async Task<HandlerResponse<PersonnelDisplayDto>> Handle(UpdatePersonnelCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetAll(x => x.Id == request.Personnel.Id)
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Profile)
                .Include(x => x.Signature)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .Include(x => x.SuccessorUser)
                .FirstOrDefaultAsync(cancellationToken);

            if (obj == null)
                return new(false, ";کاربر مورد نظر یافت نشد", null);

            if (obj.ProfileId.HasValue && request.Personnel.ProfileSelectedFile != null && request.Personnel.ProfileSelectedFile.Length > 0)
                await _attachmentFileService.DeleteAsync(obj.ProfileId.Value, cancellationToken);

            if (obj.SignatureId.HasValue && request.Personnel.SignatureSelectedFile != null && request.Personnel.SignatureSelectedFile.Length > 0)
                await _attachmentFileService.DeleteAsync(obj.SignatureId.Value, cancellationToken);

            request.Personnel.Adapt(obj);

            if (!String.IsNullOrEmpty(request.Personnel.Password))
            {
                obj.PasswordHash = request.Personnel.Password.GetSha256Hash();
            }

            if(request.Personnel.RoleIds?.Any() ?? false)
            {
                await _userRoleService.DeleteRangeAsync(obj.UserRoles, cancellationToken, false);
                obj.UserRoles = new List<UserRole>();
                obj.UserRoles = request.Personnel.RoleIds.Select(roleId => new UserRole()
                {
                    RoleId = roleId
                })
                .ToList();
            }

            obj.SecurityStamp = Guid.NewGuid();

            obj.Profile = await _attachmentFileService.UploadFile(request.Personnel.ProfileSelectedFile, FileCategory.UserProfile, cancellationToken);
            obj.Signature = await _attachmentFileService.UploadFile(request.Personnel.SignatureSelectedFile, FileCategory.UserSignature, cancellationToken);

            await _service.UpdateAsync(obj, cancellationToken);

            return obj.Adapt<PersonnelDisplayDto>();
        }
    }
}
