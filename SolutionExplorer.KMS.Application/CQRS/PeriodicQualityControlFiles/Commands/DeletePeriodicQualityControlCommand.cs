using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Commands
{
    public class DeletePeriodicQualityControlCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeletePeriodicQualityControlCommand(int id)
        {
            Id = id;
        }
    }
}