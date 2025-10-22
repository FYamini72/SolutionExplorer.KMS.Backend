using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.ExperimentFiles.Queries
{
    public class GetAllExperimentsQuery : IRequest<HandlerResponse<BaseGridDto<ExperimentDisplayDto>>>
    {
        public ExperimentSearchDto? SearchDto { get; }

        public GetAllExperimentsQuery(ExperimentSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}