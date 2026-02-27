using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Commands
{
    public class UpdatePeriodicQualityControlCommand : IRequest<HandlerResponse<PeriodicQualityControlDisplayDto>>
    {
        public PeriodicQualityControlCreateDto PeriodicQualityControl { get; }

        public UpdatePeriodicQualityControlCommand(PeriodicQualityControlCreateDto PeriodicQualityControl)
        {
            this.PeriodicQualityControl = PeriodicQualityControl;
        }
    }
}