using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Handlers
{
    public class CreatePersonnelColorBlindnessTestCommandHandler : IRequestHandler<CreatePersonnelColorBlindnessTestCommand, HandlerResponse<PersonnelColorBlindnessTestDisplayDto>>
    {
        private readonly IBaseService<PersonnelColorBlindnessTest> _service;

        public CreatePersonnelColorBlindnessTestCommandHandler(IBaseService<PersonnelColorBlindnessTest> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PersonnelColorBlindnessTestDisplayDto>> Handle(CreatePersonnelColorBlindnessTestCommand request, CancellationToken cancellationToken)
        {
            var PersonnelColorBlindnessTest = request.PersonnelColorBlindnessTest.Adapt<PersonnelColorBlindnessTest>();

            var result = await _service.AddAsync(PersonnelColorBlindnessTest, cancellationToken);

            var returnObject = _service
                .GetAll(x => x.Id == result.Id)
                .Include(x => x.Personnel)
                .FirstOrDefaultAsync(cancellationToken);
            return returnObject.Adapt<PersonnelColorBlindnessTestDisplayDto>();
        }
    }
}
