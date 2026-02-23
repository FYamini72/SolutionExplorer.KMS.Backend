using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Handlers
{
    public class CreatePersonnelTrainingCourseCommandHandler : IRequestHandler<CreatePersonnelTrainingCourseCommand, HandlerResponse<PersonnelTrainingCourseDisplayDto>>
    {
        private readonly IBaseService<PersonnelTrainingCourse> _service;

        public CreatePersonnelTrainingCourseCommandHandler(IBaseService<PersonnelTrainingCourse> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PersonnelTrainingCourseDisplayDto>> Handle(CreatePersonnelTrainingCourseCommand request, CancellationToken cancellationToken)
        {
            var PersonnelTrainingCourse = request.PersonnelTrainingCourse.Adapt<PersonnelTrainingCourse>();

            var result = await _service.AddAsync(PersonnelTrainingCourse, cancellationToken);

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
