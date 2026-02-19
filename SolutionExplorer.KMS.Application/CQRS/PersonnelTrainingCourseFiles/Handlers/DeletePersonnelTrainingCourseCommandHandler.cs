using SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Handlers
{
    public class DeletePersonnelTrainingCourseCommandHandler : IRequestHandler<DeletePersonnelTrainingCourseCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<PersonnelTrainingCourse> _service;

        public DeletePersonnelTrainingCourseCommandHandler(IBaseService<PersonnelTrainingCourse> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeletePersonnelTrainingCourseCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
