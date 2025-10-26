using SolutionExplorer.KMS.Domain.Entities.AAA;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    /// <summary>
    /// موجودیت تاریخچه گزارش‌های آزمایش بیماران
    /// </summary>
    public class LabReportHistory : BaseEntity
    {
        /// <summary>
        /// تاریخ و ساعت ثبت گزارش (ممکن است با زمان ایجاد سیستم متفاوت باشد)
        /// </summary>
        public DateTime ReportDateTime { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر گزارش‌دهنده
        /// </summary>
        public int ReporterUserId { get; set; }
        [ForeignKey(nameof(ReporterUserId))]
        public User ReporterUser { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر گزارش‌گیرنده
        /// </summary>
        public int? ReceiverUserId { get; set; }
        [ForeignKey(nameof(ReceiverUserId))]
        public User? ReceiverUser { get; set; }

        /// <summary>
        /// نام بیمار مرتبط با گزارش
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// شماره پذیرش بیمار
        /// </summary>
        public string AdmissionNumber { get; set; }

        /// <summary>
        /// آیا نتیجه آزمایش بحرانی است یا خیر
        /// </summary>
        public bool IsCritical { get; set; }

        /// <summary>
        /// شرح آزمایش یا مورد بحرانی
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// توضیحات یا یادداشت گزارش‌دهنده (در صورت نیاز)
        /// </summary>
        public string? ReporterComment { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تأییدکننده
        /// </summary>
        public int FirstConfirmerUserId { get; set; }
        [ForeignKey(nameof(FirstConfirmerUserId))]
        public User FirstConfirmerUser { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تصدیق‌کننده
        /// </summary>
        public int SecondConfirmerUserId { get; set; }
        [ForeignKey(nameof(SecondConfirmerUserId))]
        public User SecondConfirmerUser { get; set; }
    }
}
