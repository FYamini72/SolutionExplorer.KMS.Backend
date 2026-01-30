using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Commands
{
    public class UpdateQualityControlBaseInfoCommand : IRequest<HandlerResponse<QualityControlBaseInfoDisplayDto>>
    {
        public QualityControlBaseInfoCreateDto QualityControlBaseInfo { get; }

        public UpdateQualityControlBaseInfoCommand(QualityControlBaseInfoCreateDto QualityControlBaseInfo)
        {
            this.QualityControlBaseInfo = QualityControlBaseInfo;
        }
    }
}