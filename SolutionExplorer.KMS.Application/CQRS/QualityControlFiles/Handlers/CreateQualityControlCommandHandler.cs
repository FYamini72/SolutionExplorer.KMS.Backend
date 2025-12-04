using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Handlers
{
    public class CreateQualityControlCommandHandler : IRequestHandler<CreateQualityControlCommand, HandlerResponse<QualityControlDisplayDto>>
    {
        private readonly IBaseService<QualityControl> _service;
        private readonly IBaseService<QualityControlBaseInfo> _qualityControlBaseInfoService;

        public CreateQualityControlCommandHandler(IBaseService<QualityControl> service, IBaseService<QualityControlBaseInfo> qualityControlBaseInfoService)
        {
            _service = service;
            _qualityControlBaseInfoService = qualityControlBaseInfoService;
        }

        public async Task<HandlerResponse<QualityControlDisplayDto>> Handle(CreateQualityControlCommand request, CancellationToken cancellationToken)
        {
            var baseInfo = await _qualityControlBaseInfoService.GetByIdAsync(cancellationToken, request.QualityControl.QualityControlBaseInfoId);
            if (baseInfo == null)
                return new(false, "اطلاعات پایه کنترل کیفی یافت نشد.", null);

            var QualityControl = request.QualityControl.Adapt<QualityControl>();

            var result = await _service.AddAsync(QualityControl, cancellationToken, false);
            baseInfo.NextQualityControlTime = CalculateNextQualityControlTime(baseInfo);
            await _qualityControlBaseInfoService.UpdateAsync(baseInfo, cancellationToken, true);

            var obj = await _service
                .GetAll()
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .Include(x => x.PerformedByUser)
                .Include(x => x.StorageCondition)
                .Include(x => x.PhysicalSpecifications)
                    .ThenInclude(x => x.QCBaseInfoPhysicalSpecification)
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == result.Id);

            return obj.Adapt<QualityControlDisplayDto>();
        }

        private DateTime CalculateNextQualityControlTime(QualityControlBaseInfo qualityControlBaseInfo)
        {
            DateTime nextDate;
            switch (qualityControlBaseInfo.QualityControlPeriod)
            {
                case Domain.Enums.QualityControlPeriod.Daily:
                    nextDate = qualityControlBaseInfo.NextQualityControlTime.AddDays(1);
                    break;
                case Domain.Enums.QualityControlPeriod.Monthly:
                    nextDate = qualityControlBaseInfo.NextQualityControlTime.AddMonths(1);
                    break;
                case Domain.Enums.QualityControlPeriod.Quarterly:
                    nextDate = qualityControlBaseInfo.NextQualityControlTime.AddMonths(3);
                    break;
                case Domain.Enums.QualityControlPeriod.Periodic:
                    nextDate = qualityControlBaseInfo.NextQualityControlTime.AddDays(qualityControlBaseInfo.DayIntervalCount ?? 0);
                    break;
                default:
                    nextDate = DateTime.Now;
                    break;
            }
            return nextDate;
        }
    }
}
