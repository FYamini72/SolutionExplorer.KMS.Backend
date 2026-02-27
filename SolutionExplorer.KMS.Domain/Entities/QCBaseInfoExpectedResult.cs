using SolutionExplorer.KMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class QCBaseInfoExpectedResult : BaseEntity
    {
        public int QualityControlBaseInfoId { get; set; }
        [ForeignKey(nameof(QualityControlBaseInfoId))]
        public QualityControlBaseInfo QualityControlBaseInfo { get; set; }

        /// <summary>
        /// ارگانیسم کنترل
        /// </summary>
        public string ATCCControlOrganism { get; set; }

        /// <summary>
        /// نتیجه مورد انتظار
        /// </summary>
        public string? ExpectedResult { get; set; }

        /// <summary>
        /// قطر هاله براساس میلی‌متر
        /// </summary>
        public string? HaloDiameter { get; set; }

        /// <summary>
        /// پلی گروه A
        /// </summary>
        public string? PoliGroup_A { get; set; }

        /// <summary>
        /// پلی گروه B
        /// </summary>
        public string? PoliGroup_B { get; set; }

        /// <summary>
        /// پلی گروه C
        /// </summary>
        public string? PoliGroup_C { get; set; }

        /// <summary>
        /// پلی گروه D
        /// </summary>
        public string? PoliGroup_D { get; set; }
    }

    public class PeriodicQCBaseInfoExpectedResultItem : BaseEntity
    {
        public int PeriodicQCBaseInfoExpectedResultId { get; set; }
        [ForeignKey(nameof(PeriodicQCBaseInfoExpectedResultId))]
        public PeriodicQCBaseInfoExpectedResult PeriodicQCBaseInfoExpectedResult { get; set; }

        public string Title { get; set; }
        public bool IsSelected { get; set; }
    }
    public class PeriodicQCBaseInfoExpectedResult : BaseEntity
    {
        public int QualityControlBaseInfoId { get; set; }
        [ForeignKey(nameof(QualityControlBaseInfoId))]
        public QualityControlBaseInfo QualityControlBaseInfo { get; set; }

        /// <summary>
        /// ارگانیسم کنترل
        /// </summary>
        public string ATCCControlOrganism { get; set; }

        /// <summary>
        /// نتیجه مورد انتظار
        /// </summary>
        public string? ExpectedResult { get; set; }

        public int ATCCCategoryId { get; set; }
        [ForeignKey(nameof(ATCCCategoryId))]
        public ATCCCategory ATCCCategory { get; set; }

        public ResultType ResultType { get; set; }

        public ICollection<PeriodicQCBaseInfoExpectedResultItem> Items { get; set; }
    }

    public class ATCCCategory : BaseEntity
    {
        public string Title { get; set; }
        public int? MinAcceptedResult { get; set; }
    }
}
