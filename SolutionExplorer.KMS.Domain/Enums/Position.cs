using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.Domain.Enums
{
    /// <summary>
    /// سمت و مقام پرسنل
    /// </summary>
    public enum Position
    {
        [Display(Name = "مسئول فنی")]
        TechnicalOfficer,

        [Display(Name = "مدیر بخش")]
        DepartmentManager
    }
}
