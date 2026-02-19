using MediatR;
using SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Queries;
using SolutionExplorer.KMS.Application.Services.Interfaces.AAA;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Handlers
{
    public class GetAllUsersForDropDownQueryHandler : IRequestHandler<GetAllUsersForDropDownQuery, HandlerResponse<List<KeyValuePair<int, string>>>>
    {
        private readonly IBaseService<Personnel> _userService;

        public GetAllUsersForDropDownQueryHandler(IBaseService<Personnel> userService)
        {
            _userService = userService;
        }

        public async Task<HandlerResponse<List<KeyValuePair<int, string>>>> Handle(GetAllUsersForDropDownQuery request, CancellationToken cancellationToken)
        {
            var items = _userService.GetAll()
                .Include(x => x.Profile)
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .AsQueryable();

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
                }
            }

            return await items
                .Select(item => 
                    new KeyValuePair<int, string>(item.Id, $"{item.FirstName ?? ""} {item.LastName ?? ""}".Trim()))
                .ToListAsync();
        }
    }
}
