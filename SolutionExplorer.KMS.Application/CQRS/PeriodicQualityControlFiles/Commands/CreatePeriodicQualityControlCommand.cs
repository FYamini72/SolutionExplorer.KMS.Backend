using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Commands
{
    public class CreatePeriodicQualityControlCommand : IRequest<HandlerResponse<PeriodicQualityControlDisplayDto>>
    {
        public PeriodicQualityControlCreateDto PeriodicQualityControl { get; }

        public CreatePeriodicQualityControlCommand(PeriodicQualityControlCreateDto PeriodicQualityControl)
        {
            this.PeriodicQualityControl = PeriodicQualityControl;
        }
    }
}