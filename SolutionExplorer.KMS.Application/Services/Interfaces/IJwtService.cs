using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.Services.Interfaces
{
    public interface IJwtService
    {
        Task<string> Generate(User user);
    }
}
