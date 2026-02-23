using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Handlers
{
    public class GetAllPersonnelColorBlindnessTestsQueryHandler : IRequestHandler<GetAllPersonnelColorBlindnessTestsQuery, HandlerResponse<BaseGridDto<PersonnelColorBlindnessTestDisplayDto>>>
    {
        private readonly IBaseService<PersonnelColorBlindnessTest> _service;

        public GetAllPersonnelColorBlindnessTestsQueryHandler(IBaseService<PersonnelColorBlindnessTest> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<PersonnelColorBlindnessTestDisplayDto>>> Handle(GetAllPersonnelColorBlindnessTestsQuery request, CancellationToken cancellationToken)
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

                    if (request.SearchDto.TestDate.HasValue)
                        items = items.Where(x => x.TestDate.Date == request.SearchDto.TestDate.Value.Date);

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

            var response = new BaseGridDto<PersonnelColorBlindnessTestDisplayDto>()
            {
                Data = items.Adapt<List<PersonnelColorBlindnessTestDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
