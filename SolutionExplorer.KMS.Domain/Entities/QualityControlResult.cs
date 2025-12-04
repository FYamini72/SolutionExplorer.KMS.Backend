using SolutionExplorer.KMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class QualityControlResult : BaseEntity
    {
        /// <summary>
        /// اطلاعات پایه کنترل کیفی
        /// </summary>
        public int QCBaseInfoExpectedResultId { get; set; }
        [ForeignKey(nameof(QCBaseInfoExpectedResultId))]
        public QCBaseInfoExpectedResult QCBaseInfoExpectedResult { get; set; }
        
        /// <summary>
        /// کنترل کیفی
        /// </summary>
        public int QualityControlId { get; set; }
        [ForeignKey(nameof(QualityControlId))]
        public QualityControl QualityControl { get; set; }

        /// <summary>
        /// نتیجه
        /// </summary>
        public bool IsConfirmed { get; set; }

        public string? CorrectiveActions { get; set; }
    }
}
