using SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using Mapster;
using MediatR;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.Utilities;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Handlers
{
    public class CreatePersonnelCommandHandler : IRequestHandler<CreatePersonnelCommand, HandlerResponse<PersonnelDisplayDto>>
    {
        private readonly IBaseService<Personnel> _service;
        private readonly IAttachmentFileService _attachmentFileService;
        private readonly IBaseService<Role> _roleService;
        private readonly IBaseService<UserRole> _userRoleService;

        public CreatePersonnelCommandHandler(IBaseService<Personnel> service, IAttachmentFileService attachmentFileService, IBaseService<Role> roleService, IBaseService<UserRole> userRoleService)
        {
            _service = service;
            _attachmentFileService = attachmentFileService;
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        public async Task<HandlerResponse<PersonnelDisplayDto>> Handle(CreatePersonnelCommand request, CancellationToken cancellationToken)
        {
            var personnel = request.Personnel.Adapt<Personnel>();
            personnel.UserRoles = new List<UserRole>();

            if (request.Personnel.ProfileSelectedFile != null)
                personnel.Profile = await _attachmentFileService.UploadFile(request.Personnel.ProfileSelectedFile, FileCategory.UserProfile, cancellationToken);

            if (request.Personnel.SignatureSelectedFile != null)
                personnel.Profile = await _attachmentFileService.UploadFile(request.Personnel.SignatureSelectedFile, FileCategory.UserSignature, cancellationToken);

            personnel.UserRoles = request.Personnel.RoleIds
                .Select(roleId => new UserRole()
                {
                    RoleId = roleId,
                })
                .ToList();

            personnel.PasswordHash = request.Personnel.Password.GetSha256Hash();
            personnel.SecurityStamp = Guid.NewGuid();

            var result = await _service.AddAsync(personnel, cancellationToken);

            var userRoles = await _userRoleService
                .GetAll(x => x.UserId == result.Id)
                .Include(x => x.Role)
                .ToListAsync();

            if (userRoles.Any())
                result.UserRoles = userRoles;

            if (result.ProfileId.HasValue && result.Profile == null)
                result.Profile = await _attachmentFileService.GetByIdAsync(cancellationToken, result.ProfileId);

            if (result.SignatureId.HasValue && result.Signature == null)
                result.Signature = await _attachmentFileService.GetByIdAsync(cancellationToken, result.SignatureId);

            return result.Adapt<PersonnelDisplayDto>();
        }
    }
}
