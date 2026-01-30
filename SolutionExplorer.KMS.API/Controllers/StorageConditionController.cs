using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.API.Utilities.Api;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class StorageConditionController : BaseController<StorageCondition, StorageConditionDisplayDto, StorageConditionCreateDto, StorageConditionSearchDto>
    {
        public StorageConditionController(IBaseService<StorageCondition> service, 
            IValidator<StorageConditionCreateDto> createValidator, 
            IValidator<StorageConditionSearchDto> searchValidator) : base(service, createValidator, searchValidator)
        {
        }
    }
}
