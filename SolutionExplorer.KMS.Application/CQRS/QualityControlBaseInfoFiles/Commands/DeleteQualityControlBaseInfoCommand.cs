using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Commands
{
    public class DeleteQualityControlBaseInfoCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteQualityControlBaseInfoCommand(int id)
        {
            Id = id;
        }
    }
}