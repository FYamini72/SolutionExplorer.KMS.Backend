namespace SolutionExplorer.KMS.Application.Dtos
{
    /// <summary>
    /// DTO برای جست‌وجوی گزارش‌های ثبت‌شده در تاریخچه آزمایش‌ها
    /// </summary>
    public class LabReportHistorySearchDto : BaseSearchDto
    {
        /// <summary>
        /// نام بیمار برای فیلتر جست‌وجو
        /// </summary>
        public string? PatientName { get; set; }

        /// <summary>
        /// شماره پذیرش برای فیلتر جست‌وجو
        /// </summary>
        public string? AdmissionNumber { get; set; }

        /// <summary>
        /// شناسه کاربر گزارش‌دهنده
        /// </summary>
        public int? ReporterUserId { get; set; }

        /// <summary>
        /// شناسه کاربر گزارش‌گیرنده
        /// </summary>
        public int? ReceiverUserId { get; set; }

        /// <summary>
        /// وضعیت بحرانی بودن آزمایش
        /// </summary>
        public int? IsCritical { get; set; }

        /// <summary>
        /// تاریخ شروع گزارش برای بازه جست‌وجو
        /// </summary>
        public DateTime? FromReportDate { get; set; }

        /// <summary>
        /// تاریخ پایان گزارش برای بازه جست‌وجو
        /// </summary>
        public DateTime? ToReportDate { get; set; }
    }
}