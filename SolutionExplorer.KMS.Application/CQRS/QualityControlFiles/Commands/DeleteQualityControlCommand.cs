using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Commands
{
    public class DeleteQualityControlCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteQualityControlCommand(int id)
        {
            Id = id;
        }
    }
}