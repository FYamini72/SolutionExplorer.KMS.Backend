using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class QualityControl : BaseEntity
    {
        public int QualityControlBaseInfoId { get; set; }
        [ForeignKey(nameof(QualityControlBaseInfoId))]
        public QualityControlBaseInfo QualityControlBaseInfo { get; set; }

        /// <summary>
        /// چه چیزی تولید می‌کند
        /// </summary>
        public string Produces { get; set; }

        public DateTime SampleDate { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public string Series { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        
        public int StorageConditionId { get; set; }
        [ForeignKey(nameof(StorageConditionId))]
        public StorageCondition StorageCondition { get; set; }

        ///// <summary>
        ///// مشخصات ظاهری
        ///// </summary>
        //public string? PhysicalSpecification { get; set; }

        public int? PerformedByUserId { get; set; }
        [ForeignKey(nameof(PerformedByUserId))]
        public User? PerformedByUser { get; set; }

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

        public bool IsConfirmed { get; set; }

        public bool IsDefaultValue { get; set; }

        public ICollection<QualityControlResult> QualityControlResults { get; set; }
        public ICollection<PhysicalSpecification> PhysicalSpecifications { get; set; }
    }

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
    }

    /// <summary>
    /// آیتم‌های پایه مشخصات ظاهری
    /// </summary>
    public class QCBaseInfoAppearance : BaseEntity
    {
        /// <summary>
        /// شناسه اطلاعات پایه کنترل کیفی
        /// </summary>
        public int QualityControlBaseInfoId { get; set; }
        [ForeignKey(nameof(QualityControlBaseInfoId))]
        public QualityControlBaseInfo QualityControlBaseInfo { get; set; }

        /// <summary>
        /// عنوان مشخصه ظاهری
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// گروه مشخصه ظاهری
        /// </summary>
        public AppearanceGroupEnum AppearanceGroup { get; set; }

        /// <summary>
        /// وضعیت انتخاب پیش‌فرض
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// آیتم‌های استفاده شده در کنترل‌های دوره‌ای
        /// </summary>
        public ICollection<PeriodicQCAppearance> PeriodicQCAppearances { get; set; }
    }

    /// <summary>
    /// مشخصات ظاهری ثبت شده برای کنترل کیفی دوره‌ای
    /// </summary>
    public class PeriodicQCAppearance : BaseEntity
    {
        /// <summary>
        /// شناسه کنترل کیفی دوره‌ای
        /// </summary>
        public int PeriodicQualityControlId { get; set; }
        [ForeignKey(nameof(PeriodicQualityControlId))]
        public PeriodicQualityControl PeriodicQualityControl { get; set; }

        /// <summary>
        /// شناسه مشخصه ظاهری پایه
        /// </summary>
        public int QCBaseInfoAppearanceId { get; set; }
        [ForeignKey(nameof(QCBaseInfoAppearanceId))]
        public QCBaseInfoAppearance QCBaseInfoAppearance { get; set; }
    }
}
