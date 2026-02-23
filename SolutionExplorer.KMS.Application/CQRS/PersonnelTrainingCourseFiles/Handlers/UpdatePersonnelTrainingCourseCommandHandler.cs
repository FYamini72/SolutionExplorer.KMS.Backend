using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Handlers
{
    public class UpdatePersonnelTrainingCourseCommandHandler : IRequestHandler<UpdatePersonnelTrainingCourseCommand, HandlerResponse<PersonnelTrainingCourseDisplayDto>>
    {
        private readonly IBaseService<PersonnelTrainingCourse> _service;

        public UpdatePersonnelTrainingCourseCommandHandler(IBaseService<PersonnelTrainingCourse> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PersonnelTrainingCourseDisplayDto>> Handle(UpdatePersonnelTrainingCourseCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.PersonnelTrainingCourse.Id);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.PersonnelTrainingCourse.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);

            var returnObject = _service
                .GetAll(x => x.Id == result.Id)
                .Include(x => x.Personnel)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(cancellationToken);
            return returnObject.Adapt<PersonnelTrainingCourseDisplayDto>();
        }
    }
}
