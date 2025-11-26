
namespace SolutionExplorer.KMS.Application.Dtos
{
    /// <summary>
    /// DTO برای نمایش اطلاعات تاریخچه گزارش آزمایش
    /// </summary>
    public class LabReportHistoryDisplayDto : BaseDto
    {
        public DateTime ReportDateTime { get; set; }

        public bool IsCritical { get; set; }

        public int ReporterUserId { get; set; }
        public string? ReporterUserFullName { get; set; }

        public int? ReceiverUserId { get; set; }
        public string? ReceiverUserFullName { get; set; }

        public string PatientName { get; set; }
        public string AdmissionNumber { get; set; }

        public string? Description { get; set; }
        public string? ReporterComment { get; set; }

        public int FirstConfirmerUserId { get; set; }
        public string? FirstConfirmerUserFullName { get; set; }

        public int SecondConfirmerUserId { get; set; }
        public string? SecondConfirmerUserFullName { get; set; }
    }
}