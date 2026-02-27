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

    /// <summary>
    /// نام محیط
    /// </summary>
    public enum EnvironmentNameEnum { }

    /// <summary>
    /// تعداد محیط
    /// </summary>
    public enum MediumCountEnum { }

    /// <summary>
    /// دمای نگهداری
    /// </summary>
    public enum StorageTemperatureEnum { }

    /// <summary>
    /// زمان قابل نگهداری
    /// </summary>
    public enum ShelfLifeDurationEnum { }

    /// <summary>
    /// نوع محیط
    /// </summary>
    public enum MediumTypeEnum { }

    /// <summary>
    /// دوره انجام کنترل کیفی
    /// </summary>
    [Flags]
    public enum QualityControlPeriodEnum { }

    /// <summary>
    /// گروه مشخصات ظاهری
    /// </summary>
    public enum AppearanceGroupEnum { }

    /// <summary>
    /// شرایط اتوکلاو
    /// </summary>
    [Flags]
    public enum AutoclaveConditionEnum
    {

    }

    public enum ResultType
    {
        Boolian,
        MultiSelect,
        SingleSelect,
        Text,
        Number
    }
}
