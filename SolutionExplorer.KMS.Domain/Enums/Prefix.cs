using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.Domain.Enums
{
    /// <summary>
    /// پیشوندهای پرسنل
    /// </summary>
    ///<remarks>
    /// برای مثال: آقا، خانم، دکتر و ...
    ///</remarks>
    public enum Prefix
    {
        [Display(Name = "خانم")]
        Madam,
        [Display(Name = "آقا")]
        Sir,
        [Display(Name = "دکتر")]
        Dr
    }
}
