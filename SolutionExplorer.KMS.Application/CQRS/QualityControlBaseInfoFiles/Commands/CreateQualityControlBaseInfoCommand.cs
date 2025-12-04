using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Commands
{
    public class CreateQualityControlBaseInfoCommand : IRequest<HandlerResponse<QualityControlBaseInfoDisplayDto>>
    {
        public QualityControlBaseInfoCreateDto QualityControlBaseInfo { get; }

        public CreateQualityControlBaseInfoCommand(QualityControlBaseInfoCreateDto QualityControlBaseInfo)
        {
            this.QualityControlBaseInfo = QualityControlBaseInfo;
        }
    }
}