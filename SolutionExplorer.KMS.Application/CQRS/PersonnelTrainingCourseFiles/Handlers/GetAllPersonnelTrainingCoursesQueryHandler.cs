using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Handlers
{
    public class GetAllPersonnelTrainingCoursesQueryHandler : IRequestHandler<GetAllPersonnelTrainingCoursesQuery, HandlerResponse<BaseGridDto<PersonnelTrainingCourseDisplayDto>>>
    {
        private readonly IBaseService<PersonnelTrainingCourse> _service;

        public GetAllPersonnelTrainingCoursesQueryHandler(IBaseService<PersonnelTrainingCourse> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<PersonnelTrainingCourseDisplayDto>>> Handle(GetAllPersonnelTrainingCoursesQuery request, CancellationToken cancellationToken)
        {
            var items = _service
                .GetAll()
                .Include(x => x.Personnel)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .AsQueryable();
            var totalCount = await items.CountAsync();

            if(request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (request.SearchDto.PersonnelId.HasValue)
                        items = items.Where(x => x.PersonnelId == request.SearchDto.PersonnelId);

                    if (request.SearchDto.IsConfirmed.HasValue && request.SearchDto.IsConfirmed > 0)
                        items = items.Where(x => x.IsConfirmed == (request.SearchDto.IsConfirmed.Value == 1));

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<PersonnelTrainingCourseDisplayDto>()
            {
                Data = items.Adapt<List<PersonnelTrainingCourseDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
