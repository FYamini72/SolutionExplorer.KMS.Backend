using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    /// <summary>
    /// ثبت اطلاعات کنترل کیفی دوره‌ای محیط کشت
    /// </summary>
    public class PeriodicQualityControl : BaseEntity
    {
        /// <summary>
        /// شناسه اطلاعات پایه کنترل کیفی
        /// </summary>
        public int QualityControlBaseInfoId { get; set; }
        [ForeignKey(nameof(QualityControlBaseInfoId))]
        public QualityControlBaseInfo QualityControlBaseInfo { get; set; }

        /// <summary>
        /// تاریخ ساخت محیط
        /// </summary>
        public DateTime ManufactureDate { get; set; }

        /// <summary>
        /// شناسه کاربر انجام دهنده
        /// </summary>
        public int PerformedByUserId { get; set; }
        [ForeignKey(nameof(PerformedByUserId))]
        public User PerformedByUser { get; set; }

        /// <summary>
        /// شرکت سازنده
        /// </summary>
        public string ManufacturerCompany { get; set; }

        /// <summary>
        /// تاریخ تولید
        /// </summary>
        public DateTime ProductionDate { get; set; }

        /// <summary>
        /// تاریخ انقضاء
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// سری ساخت
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// تاریخ بازگشایی
        /// </summary>
        public DateTime OpeningDate { get; set; }

        /// <summary>
        /// مقدار گرم پودر در یک لیتر
        /// </summary>
        public float PowderGramPerLiter { get; set; }

        /// <summary>
        /// شماره پذیرش شروع استفاده
        /// </summary>
        public string UsageStartAcceptanceNumber { get; set; }

        /// <summary>
        /// تعداد محیط
        /// </summary>
        public MediumCountEnum MediumCount { get; set; }

        /// <summary>
        /// دمای نگهداری
        /// </summary>
        public StorageTemperatureEnum StorageTemperature { get; set; }

        /// <summary>
        /// زمان قابل نگهداری
        /// </summary>
        public ShelfLifeDurationEnum ShelfLifeDuration { get; set; }

        /// <summary>
        /// شرایط اتوکلاو
        /// </summary>
        public AutoclaveConditionEnum AutoclaveConditions { get; set; }

        public string? ExtraAutoclaveCondition { get; set; }

        /// <summary>
        /// نوع محیط
        /// </summary>
        public MediumTypeEnum MediumType { get; set; }

        /// <summary>
        /// دوره انجام کنترل کیفی
        /// </summary>
        public QualityControlPeriodEnum QualityControlPeriod { get; set; }

        /// <summary>
        /// تاریخ انجام کنترل کیفی
        /// </summary>
        public DateTime QualityControlDate { get; set; }

        /// <summary>
        /// مشخصات فیزیکی
        /// </summary>
        public ICollection<PeriodicQCPhysicalSpecification> PhysicalSpecifications { get; set; }

        /// <summary>
        /// مشخصات ظاهری ثبت شده
        /// </summary>
        public ICollection<PeriodicQCAppearance> Appearances { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تایید کننده
        /// </summary>
        public int FirstConfirmerUserId { get; set; }
        [ForeignKey(nameof(FirstConfirmerUserId))]
        public User FirstConfirmerUser { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تصدیق کننده
        /// </summary>
        public int SecondConfirmerUserId { get; set; }
        [ForeignKey(nameof(SecondConfirmerUserId))]
        public User SecondConfirmerUser { get; set; }

        public ICollection<PeriodicQualityControlCategoryResult> PeriodicQualityControlCategoryResults { get; set; }
    }

    public class PeriodicQualityControlCategoryResult : BaseEntity
    {
        public int PeriodicQualityControlId { get; set; }
        [ForeignKey(nameof(PeriodicQualityControlId))]
        public PeriodicQualityControl PeriodicQualityControl { get; set; }

        public int ATCCCategoryId { get; set; }
        [ForeignKey(nameof(ATCCCategoryId))]
        public ATCCCategory ATCCCategory { get; set; }

        public bool IsSelected { get; set; }
    }

    public class PeriodicQualityControlResult : BaseEntity
    {
        public int PeriodicQualityControlCategoryResultId { get; set; }
        [ForeignKey(nameof(PeriodicQualityControlCategoryResultId))]
        public PeriodicQualityControlCategoryResult PeriodicQualityControlCategoryResult { get; set; }


        public int? PeriodicQCBaseInfoExpectedResultId { get; set; }
        [ForeignKey(nameof(PeriodicQCBaseInfoExpectedResultId))]
        public PeriodicQCBaseInfoExpectedResult? PeriodicQCBaseInfoExpectedResult { get; set; }

        public string? CustomResultTitle { get; set; }
        public bool IsConfirmed { get; set; }
        public string? CorrectiveActions { get; set; }
    }
}
