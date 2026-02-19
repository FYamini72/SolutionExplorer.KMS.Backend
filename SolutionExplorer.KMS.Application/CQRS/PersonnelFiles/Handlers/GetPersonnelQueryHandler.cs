using SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Handlers
{
    public class GetPersonnelQueryHandler : IRequestHandler<GetPersonnelQuery, HandlerResponse<PersonnelDisplayDto>>
    {
        private readonly IBaseService<Personnel> _service;

        public GetPersonnelQueryHandler(IBaseService<Personnel> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PersonnelDisplayDto>> Handle(GetPersonnelQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetAll(x => x.Id == request.Id)
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Profile)
                .Include(x => x.Signature)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .Include(x => x.SuccessorUser)
                .FirstOrDefaultAsync();

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<PersonnelDisplayDto>();
        }
    }
}