using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.Domain.Enums
{
    /// <summary>
    /// جنسیت پرسنل
    /// </summary>
    public enum Gender
    {
        [Display(Name = "مرد")]
        Man,
        [Display(Name = "زن")]
        Woman
    }
}
