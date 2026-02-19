using SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Handlers
{
    public class GetPersonnelColorBlindnessTestQueryHandler : IRequestHandler<GetPersonnelColorBlindnessTestQuery, HandlerResponse<PersonnelColorBlindnessTestDisplayDto>>
    {
        private readonly IBaseService<PersonnelColorBlindnessTest> _service;

        public GetPersonnelColorBlindnessTestQueryHandler(IBaseService<PersonnelColorBlindnessTest> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PersonnelColorBlindnessTestDisplayDto>> Handle(GetPersonnelColorBlindnessTestQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll(x => x.Id == request.Id)
                .Include(x => x.Personnel)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(cancellationToken);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<PersonnelColorBlindnessTestDisplayDto>();
        }
    }
}