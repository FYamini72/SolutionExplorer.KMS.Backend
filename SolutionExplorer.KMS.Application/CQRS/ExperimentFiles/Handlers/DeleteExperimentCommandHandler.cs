using SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Handlers
{
    public class DeleteExperimentCommandHandler : IRequestHandler<DeleteExperimentCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<Experiment> _service;

        public DeleteExperimentCommandHandler(IBaseService<Experiment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteExperimentCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
