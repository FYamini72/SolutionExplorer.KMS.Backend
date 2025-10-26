using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;

using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;

namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Handlers
{
    public class GetAllLabReportHistoriesQueryHandler : IRequestHandler<GetAllLabReportHistoriesQuery, HandlerResponse<BaseGridDto<LabReportHistoryDisplayDto>>>
    {
        private readonly IBaseService<LabReportHistory> _service;

        public GetAllLabReportHistoriesQueryHandler(IBaseService<LabReportHistory> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<BaseGridDto<LabReportHistoryDisplayDto>>> Handle(GetAllLabReportHistoriesQuery request, CancellationToken cancellationToken)
        {
            var items = _service
                .GetAll()
                .Include(x => x.ReporterUser)
                .Include(x => x.ReceiverUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .AsQueryable();
            var totalCount = await items.CountAsync();

            if(request.SearchDto != null)
            {
                if (!request.SearchDto.GetAllItems)
                {
                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (request.SearchDto.Id.HasValue)
                        items = items.Where(x => x.Id == request.SearchDto.Id);

                    if (!string.IsNullOrEmpty(request.SearchDto.PatientName))
                        items = items.Where(x => x.PatientName.Contains(request.SearchDto.PatientName));

                    if (!string.IsNullOrEmpty(request.SearchDto.AdmissionNumber))
                        items = items.Where(x => x.AdmissionNumber.Contains(request.SearchDto.AdmissionNumber));

                    if (request.SearchDto.IsCritical.HasValue && request.SearchDto.IsCritical > 0)
                        items = items.Where(x => x.IsCritical == (request.SearchDto.IsCritical.Value == 1));

                    if (request.SearchDto.ReporterUserId.HasValue)
                        items = items.Where(x => x.ReporterUserId == request.SearchDto.ReporterUserId);

                    if (request.SearchDto.ReceiverUserId.HasValue)
                        items = items.Where(x => x.ReceiverUserId == request.SearchDto.ReceiverUserId);

                    //if (request.SearchDto.IsCritical.HasValue)
                    //    items = items.Where(x => x.IsCritical == request.SearchDto.IsCritical);

                    if (request.SearchDto.FromReportDate.HasValue)
                        items = items.Where(x => x.ReportDateTime >= request.SearchDto.FromReportDate);

                    if (request.SearchDto.ToReportDate.HasValue)
                        items = items.Where(x => x.ReportDateTime <= request.SearchDto.ToReportDate);

                    if (!request.SearchDto.Take.HasValue || request.SearchDto.Take <= 0)
                        request.SearchDto.Take = 10;

                    if (!request.SearchDto.Skip.HasValue || request.SearchDto.Skip < 0)
                        request.SearchDto.Skip = 0;

                    totalCount = await items.CountAsync();
                    items.Skip(request.SearchDto.Skip.Value).Take(request.SearchDto.Take.Value);
                }
            }

            var response = new BaseGridDto<LabReportHistoryDisplayDto>()
            {
                Data = items.Adapt<List<LabReportHistoryDisplayDto>>(),
                TotalCount = totalCount
            };
            return response;
        }
    }
}
