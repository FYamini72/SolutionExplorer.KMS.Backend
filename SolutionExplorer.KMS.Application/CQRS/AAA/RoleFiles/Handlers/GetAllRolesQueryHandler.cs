using Mapster;
using MediatR;
using SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Handlers
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, HandlerResponse<BaseGridDto<RoleDisplayDto>>>
    {
        private readonly IBaseService<Role> _service;

        public GetAllRolesQueryHandler(IBaseService<Role> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<RoleDisplayDto>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var items = _service.GetAll();
            var totalCount = await items.CountAsync();

            if (request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (!string.IsNullOrEmpty(request.SearchDto.Title))
                        items = items.Where(x => x.Title.ToLower().Contains(request.SearchDto.Title.ToLower()));

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items = items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<RoleDisplayDto>()
            {
                Data = items.Adapt<List<RoleDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
