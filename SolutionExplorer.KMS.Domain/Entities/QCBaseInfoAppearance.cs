using SolutionExplorer.KMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
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
}
