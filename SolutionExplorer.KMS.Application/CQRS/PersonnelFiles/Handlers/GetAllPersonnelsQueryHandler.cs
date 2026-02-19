using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Handlers
{
    public class GetAllPersonnelsQueryHandler : IRequestHandler<GetAllPersonnelsQuery, HandlerResponse<BaseGridDto<PersonnelDisplayDto>>>
    {
        private readonly IBaseService<Personnel> _service;

        public GetAllPersonnelsQueryHandler(IBaseService<Personnel> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<PersonnelDisplayDto>>> Handle(GetAllPersonnelsQuery request, CancellationToken cancellationToken)
        {
            var items = _service
                .GetAll()
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Profile)
                .Include(x => x.Signature)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .Include(x => x.SuccessorUser)
                .AsQueryable();

            var totalCount = await items.CountAsync();

            if(request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (!string.IsNullOrEmpty(request.SearchDto.UserName))
                        items = items.Where(x => x.UserName.Contains(request.SearchDto.UserName));

                    if (!string.IsNullOrEmpty(request.SearchDto.FirstName))
                        items = items.Where(x => x.FirstName.Contains(request.SearchDto.FirstName));

                    if (!string.IsNullOrEmpty(request.SearchDto.LastName))
                        items = items.Where(x => x.LastName.Contains(request.SearchDto.LastName));

                    if (!string.IsNullOrEmpty(request.SearchDto.PersonnelNumber))
                        items = items.Where(x => x.PersonnelNumber.Contains(request.SearchDto.PersonnelNumber));

                    if (request.SearchDto.RoleId.HasValue)
                        items = items.Where(x => x.UserRoles.Any(ur => ur.RoleId == request.SearchDto.RoleId));

                    if (request.SearchDto.Prefix.HasValue)
                        items = items.Where(x => x.Prefix == request.SearchDto.Prefix);

                    if (request.SearchDto.Gender.HasValue)
                        items = items.Where(x => x.Gender == request.SearchDto.Gender);

                    if (request.SearchDto.Position.HasValue)
                        items = items.Where(x => x.Position == request.SearchDto.Position);

                    if (request.SearchDto.EducationalDegree.HasValue)
                        items = items.Where(x => x.EducationalDegree == request.SearchDto.EducationalDegree);

                    if (!string.IsNullOrEmpty(request.SearchDto.EducationalField))
                        items = items.Where(x => x.EducationalField.Contains(request.SearchDto.EducationalField));

                    if (request.SearchDto.FirstConfirmerUserId.HasValue)
                        items = items.Where(x => x.FirstConfirmerUserId == request.SearchDto.FirstConfirmerUserId.Value);

                    if (request.SearchDto.SecondConfirmerUserId.HasValue)
                        items = items.Where(x => x.SecondConfirmerUserId == request.SearchDto.SecondConfirmerUserId.Value);

                    if (request.SearchDto.SuccessorUserId.HasValue)
                        items = items.Where(x => x.SuccessorUserId == request.SearchDto.SuccessorUserId.Value);

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<PersonnelDisplayDto>()
            {
                Data = items.Adapt<List<PersonnelDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
