using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Queries
{
    public class GetExperimentQuery : IRequest<HandlerResponse<ExperimentDisplayDto>>
    {
        public int Id { get; }

        public GetExperimentQuery(int id)
        {
            Id = id;
        }
    }
}