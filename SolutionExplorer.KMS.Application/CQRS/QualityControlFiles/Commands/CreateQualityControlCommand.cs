using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Commands
{
    public class CreateQualityControlCommand : IRequest<HandlerResponse<QualityControlDisplayDto>>
    {
        public QualityControlCreateDto QualityControl { get; }

        public CreateQualityControlCommand(QualityControlCreateDto QualityControl)
        {
            this.QualityControl = QualityControl;
        }
    }
}