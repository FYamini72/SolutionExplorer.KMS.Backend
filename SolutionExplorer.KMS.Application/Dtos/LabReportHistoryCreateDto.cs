namespace SolutionExplorer.KMS.Application.Dtos;

/// <summary>
/// DTO برای ایجاد رکورد جدید تاریخچه گزارش آزمایش
/// </summary>
public class LabReportHistoryCreateDto : BaseDto
{
    /// <summary>
    /// تاریخ و ساعت ثبت گزارش
    /// </summary>
    public DateTime ReportDateTime { get; set; }

    /// <summary>
    /// شناسه دیتابیسی کاربر گزارش‌دهنده
    /// </summary>
    public int ReporterUserId { get; set; }

    /// <summary>
    /// شناسه دیتابیسی کاربر گزارش‌گیرنده
    /// </summary>
    public int? ReceiverUserId { get; set; }

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
    /// توضیحات یا یادداشت گزارش‌دهنده
    /// </summary>
    public string? ReporterComment { get; set; }

    /// <summary>
    /// شناسه دیتابیسی کاربر تأییدکننده
    /// </summary>
    public int FirstConfirmerUserId { get; set; }

    /// <summary>
    /// شناسه دیتابیسی کاربر تصدیق‌کننده
    /// </summary>
    public int SecondConfirmerUserId { get; set; }
}