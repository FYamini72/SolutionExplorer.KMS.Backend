using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Handlers
{
    public class GetPersonnelTrainingCourseQueryHandler : IRequestHandler<GetPersonnelTrainingCourseQuery, HandlerResponse<PersonnelTrainingCourseDisplayDto>>
    {
        private readonly IBaseService<PersonnelTrainingCourse> _service;

        public GetPersonnelTrainingCourseQueryHandler(IBaseService<PersonnelTrainingCourse> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PersonnelTrainingCourseDisplayDto>> Handle(GetPersonnelTrainingCourseQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll(x => x.Id == request.Id)
                .Include(x => x.Personnel)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(cancellationToken);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<PersonnelTrainingCourseDisplayDto>();
        }
    }
}