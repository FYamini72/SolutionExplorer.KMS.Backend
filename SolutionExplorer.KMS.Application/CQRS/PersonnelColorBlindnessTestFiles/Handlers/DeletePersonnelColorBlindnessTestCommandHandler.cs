using SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Handlers
{
    public class DeletePersonnelColorBlindnessTestCommandHandler : IRequestHandler<DeletePersonnelColorBlindnessTestCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<PersonnelColorBlindnessTest> _service;

        public DeletePersonnelColorBlindnessTestCommandHandler(IBaseService<PersonnelColorBlindnessTest> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeletePersonnelColorBlindnessTestCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
