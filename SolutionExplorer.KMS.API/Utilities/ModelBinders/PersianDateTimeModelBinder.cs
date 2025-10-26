namespace SolutionExplorer.KMS.API.Utilities.ModelBinders
{
    //public class PersianDateTimeModelBinder : IModelBinder
    //{
    //    public Task BindModelAsync(ModelBindingContext bindingContext)
    //    {
    //        var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;
    //        if (string.IsNullOrWhiteSpace(value))
    //            return Task.CompletedTask;

    //        try
    //        {
    //            // مثال ورودی: "1404/08/16 14:32:19"
    //            var parts = value.Split(' ');
    //            var dateParts = parts[0].Split('/');
    //            var timeParts = (parts.Length > 1 ? parts[1] : "00:00:00").Split(':');

    //            var pc = new PersianCalendar();
    //            var result = new DateTime(
    //                int.Parse(dateParts[0]),
    //                int.Parse(dateParts[1]),
    //                int.Parse(dateParts[2]),
    //                int.Parse(timeParts[0]),
    //                int.Parse(timeParts[1]),
    //                timeParts.Length > 2 ? int.Parse(timeParts[2]) : 0,
    //                pc
    //            );

    //            bindingContext.Result = ModelBindingResult.Success(result);
    //        }
    //        catch
    //        {
    //            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, $"تاریخ نامعتبر: {value}");
    //        }

    //        return Task.CompletedTask;
    //    }
    //}

    //public class PersianDateTimeModelBinderProvider : IModelBinderProvider
    //{
    //    public IModelBinder GetBinder(ModelBinderProviderContext context)
    //    {
    //        if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
    //            return new BinderTypeModelBinder(typeof(PersianDateTimeModelBinder));

    //        return null;
    //    }
    //}
}
