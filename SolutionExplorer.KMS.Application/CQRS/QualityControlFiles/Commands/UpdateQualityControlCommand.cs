using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Commands
{
    public class UpdateQualityControlCommand : IRequest<HandlerResponse<QualityControlDisplayDto>>
    {
        public QualityControlCreateDto QualityControl { get; }

        public UpdateQualityControlCommand(QualityControlCreateDto QualityControl)
        {
            this.QualityControl = QualityControl;
        }
    }
}