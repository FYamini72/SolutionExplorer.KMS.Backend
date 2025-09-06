using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SolutionExplorer.KMS.Application.Repositories;
using SolutionExplorer.KMS.Application.Services.Interfaces.AAA;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.Services.Implementations.AAA
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IBaseRepository<User> _repository;

        public UserService(IBaseRepository<User> repository
            , IBaseRepository<EventLog> eventLogRepository
            , IConfiguration configuration
            , IHttpContextAccessor httpContext) : base(repository, eventLogRepository, configuration, httpContext)
        {
            _repository = repository;
        }
    }
}
