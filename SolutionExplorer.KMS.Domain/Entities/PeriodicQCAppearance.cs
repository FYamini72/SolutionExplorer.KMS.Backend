using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
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
