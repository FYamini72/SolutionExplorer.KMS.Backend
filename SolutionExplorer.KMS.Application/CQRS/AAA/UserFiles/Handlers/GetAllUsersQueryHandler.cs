using SolutionExplorer.KMS.Application.Dtos.AAA;
using Mapster;
using MediatR;
using SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Queries;
using SolutionExplorer.KMS.Application.Services.Interfaces.AAA;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, HandlerResponse<BaseGridDto<UserDisplayDto>>>
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<HandlerResponse<BaseGridDto<UserDisplayDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var items = _userService.GetAll()
                .Include(x => x.Profile)
                .Include(x=>x.UserRoles)
                    .ThenInclude(x=>x.Role)
                .AsQueryable();
            var totalCount = await items.CountAsync();

            if (request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (!string.IsNullOrEmpty(request.SearchDto.UserName))
                        items = items.Where(x => x.UserName.Contains(request.SearchDto.UserName));
                    
                    if (!string.IsNullOrEmpty(request.SearchDto.FirstName))
                        items = items.Where(x => x.FirstName.Contains(request.SearchDto.FirstName));
                    
                    if (!string.IsNullOrEmpty(request.SearchDto.LastName))
                        items = items.Where(x => x.LastName.Contains(request.SearchDto.LastName));

                    if (request.SearchDto.RoleId.HasValue)
                        items = items.Where(x => x.UserRoles.Any(x => x.RoleId == request.SearchDto.RoleId));

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<UserDisplayDto>()
            {
                Data = items.Adapt<List<UserDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
