using SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Handlers
{
    public class DeleteLabReportHistoryCommandHandler : IRequestHandler<DeleteLabReportHistoryCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<LabReportHistory> _service;

        public DeleteLabReportHistoryCommandHandler(IBaseService<LabReportHistory> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteLabReportHistoryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
