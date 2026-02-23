using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.Domain.Enums
{
    public enum IdentifierType
    {
        /// <summary>
        /// تعیین نشده
        /// </summary>
        NotSet,

        /// <summary>
        /// شناسنامه تجهیزات
        /// </summary>
        Equipment,

        /// <summary>
        /// شناسنامه آزمایشات
        /// </summary>
        Experiment,

        /// <summary>
        /// چک لیست ممیزی
        /// </summary>
        AuditChecklist,

        /// <summary>
        /// گزارش جواب
        /// </summary>
        ReportAnswer,

        /// <summary>
        /// منابع
        /// </summary>
        References,

        /// <summary>
        /// شناسنامه و چارت سازمانی
        /// </summary>
        OrganizationalChart,
        /// <summary>
        /// صلاحیت و وظایف
        /// </summary>
        CompetenceAndDuties,
        /// <summary>
        /// ایمنی و حفاظت
        /// </summary>
        SafetyAndProtection,
    }
}
