using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Handlers
{
    public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, HandlerResponse<BaseGridDto<UserRoleDisplayDto>>>
    {
        private readonly IBaseService<UserRole> _service;

        public GetAllUserRolesQueryHandler(IBaseService<UserRole> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<UserRoleDisplayDto>>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
        {
            var items = _service
                .GetAll()
                .Include(x => x.Role)
                .AsQueryable();
            var totalCount = await items.CountAsync();

            if (request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (request.SearchDto.UserId.HasValue)
                        items = items.Where(x => x.UserId == request.SearchDto.UserId);

                    if (!string.IsNullOrEmpty(request.SearchDto.RoleTitle))
                        items = items.Where(x => x.Role.Title.Contains(request.SearchDto.RoleTitle));

                    if (request.SearchDto.RoleId.HasValue)
                        items = items.Where(x => x.RoleId == request.SearchDto.RoleId);

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<UserRoleDisplayDto>()
            {
                Data = items.Adapt<List<UserRoleDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
