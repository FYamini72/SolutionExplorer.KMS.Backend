using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Handlers
{
    public class GetAllReferencesQueryHandler : IRequestHandler<GetAllReferencesQuery, HandlerResponse<BaseGridDto<ReferenceDisplayDto>>>
    {
        private readonly IBaseService<Reference> _service;

        public GetAllReferencesQueryHandler(IBaseService<Reference> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<ReferenceDisplayDto>>> Handle(GetAllReferencesQuery request, CancellationToken cancellationToken)
        {
            var items = _service
                .GetAll(x => x.Identifier.IdentifierType == IdentifierType.References)
                .Include(x => x.AttachmentFile)
                .AsQueryable();
            var totalCount = await items.CountAsync();

            if (request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (!string.IsNullOrEmpty(request.SearchDto.Title))
                        items = items.Where(x => x.Title.Contains(request.SearchDto.Title));

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<ReferenceDisplayDto>()
            {
                Data = items.Adapt<List<ReferenceDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
