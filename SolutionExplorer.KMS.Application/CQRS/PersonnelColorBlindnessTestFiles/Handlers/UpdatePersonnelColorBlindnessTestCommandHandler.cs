using SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Handlers
{
    public class UpdatePersonnelColorBlindnessTestCommandHandler : IRequestHandler<UpdatePersonnelColorBlindnessTestCommand, HandlerResponse<PersonnelColorBlindnessTestDisplayDto>>
    {
        private readonly IBaseService<PersonnelColorBlindnessTest> _service;

        public UpdatePersonnelColorBlindnessTestCommandHandler(IBaseService<PersonnelColorBlindnessTest> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PersonnelColorBlindnessTestDisplayDto>> Handle(UpdatePersonnelColorBlindnessTestCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.PersonnelColorBlindnessTest.Id);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.PersonnelColorBlindnessTest.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);

            var returnObject = _service
                .GetAll(x => x.Id == result.Id)
                .Include(x => x.Personnel)
                .FirstOrDefaultAsync(cancellationToken);
            return returnObject.Adapt<PersonnelColorBlindnessTestDisplayDto>();
        }
    }
}
