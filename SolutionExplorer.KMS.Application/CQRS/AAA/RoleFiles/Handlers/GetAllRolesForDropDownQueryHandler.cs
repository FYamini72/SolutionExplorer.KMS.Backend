using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Queries;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Handlers
{
    public class GetAllRolesForDropDownQueryHandler : IRequestHandler<GetAllRolesForDropDownQuery, HandlerResponse<List<KeyValuePair<int, string>>>>
    {
        private readonly IBaseService<Role> _roleService;

        public GetAllRolesForDropDownQueryHandler(IBaseService<Role> roleService)
        {
            _roleService = roleService;
        }

        public async Task<HandlerResponse<List<KeyValuePair<int, string>>>> Handle(GetAllRolesForDropDownQuery request, CancellationToken cancellationToken)
        {
            var items = _roleService.GetAll();

            if (request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (!string.IsNullOrEmpty(request.SearchDto.Title))
                        items = items.Where(x => x.Title.Contains(request.SearchDto.Title));
                }
            }

            return await items
                .Select(item => new KeyValuePair<int, string>(item.Id, item.Title))
                .ToListAsync();
        }
    }
}
