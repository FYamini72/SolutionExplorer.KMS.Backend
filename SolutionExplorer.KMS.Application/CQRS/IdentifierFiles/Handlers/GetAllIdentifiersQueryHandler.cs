using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Handlers
{
    public class GetAllIdentifiersQueryHandler : IRequestHandler<GetAllIdentifiersQuery, HandlerResponse<BaseGridDto<IdentifierDisplayDto>>>
    {
        private readonly IBaseService<Identifier> _service;

        public GetAllIdentifiersQueryHandler(IBaseService<Identifier> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<IdentifierDisplayDto>>> Handle(GetAllIdentifiersQuery request, CancellationToken cancellationToken)
        {
            var items = _service
                .GetAll()
                .Include(x => x.ProducerUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
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

                    if (!string.IsNullOrEmpty(request.SearchDto.DocumentNumber))
                        items = items.Where(x => x.DocumentNumber.Contains(request.SearchDto.DocumentNumber));

                    if (!string.IsNullOrEmpty(request.SearchDto.EditNo))
                        items = items.Where(x => x.EditNo.Contains(request.SearchDto.EditNo));

                    if (request.SearchDto.ProducerUserId.HasValue)
                        items = items.Where(x => x.ProducerUserId == request.SearchDto.ProducerUserId.Value);

                    if (request.SearchDto.FirstConfirmerUserId.HasValue)
                        items = items.Where(x => x.FirstConfirmerUserId == request.SearchDto.FirstConfirmerUserId.Value);

                    if (request.SearchDto.SecondConfirmerUserId.HasValue)
                        items = items.Where(x => x.SecondConfirmerUserId == request.SearchDto.SecondConfirmerUserId.Value);

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items = items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<IdentifierDisplayDto>()
            {
                Data = items.Adapt<List<IdentifierDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
