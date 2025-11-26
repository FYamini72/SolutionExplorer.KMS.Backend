using System.ComponentModel;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class SystemSetting : BaseEntity
    {
        /// <summary>
        /// نام آزمایشگاه
        /// </summary>
        public string LabName { get; set; }
    }
}
