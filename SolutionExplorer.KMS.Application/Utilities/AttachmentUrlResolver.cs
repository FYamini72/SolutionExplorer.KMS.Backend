using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Enums;
using SolutionExplorer.KMS.Domain.Settings;

namespace SolutionExplorer.KMS.Application.Utilities
{
    public enum FileAccessMode
    {
        Read, 
        Write
    }
    public static class AttachmentUrlResolver
    {
        public static string GetFolderDirectory(FileCategory fileCategory, FileAccessMode accessMode)
        {
            var config = ServiceLocator.GetService<FilePathConfiguration>();
            if (config == null)
                throw new InvalidOperationException("تنظیمات مسیر فایل یافت نشد.");

            string basePath = config.BasePath;
            string baseUrl = config.BaseUrl;
            string relativePath = fileCategory switch
            {
                FileCategory.IdentifierAttachment => config.IdentifiersAttachmentPath,
                _ => string.Empty
            };

            // حالت Write → همیشه مسیر فیزیکی برای ذخیره فایل
            if (accessMode == FileAccessMode.Write)
            {
                // اگر مسیر نسبی بود، آن را به wwwroot نگاشت کن
                if (!Path.IsPathRooted(basePath))
                    basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", basePath);

                string physicalPath = Path.Combine(basePath, relativePath);

                if (!Directory.Exists(physicalPath))
                    Directory.CreateDirectory(physicalPath);

                return physicalPath.Replace("\\", "/");
            }
            else
                return $"{baseUrl.TrimEnd('/')}/{relativePath.TrimStart('/')}".Replace("\\", "/");

            //// حالت Read → بر اساس محیط تصمیم می‌گیرد
            //if (config.IsProductionMode)
            //{
            //    // در محیط پروداکشن مسیر URL (دامنه) برمی‌گردد

            //}
            //else
            //{
            //    // در محیط لوکال، مسیر فیزیکی برمی‌گردد
            //    if (!Path.IsPathRooted(basePath))
            //        basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", basePath);

            //    return Path.Combine(basePath, relativePath).Replace("\\", "/");
            //}
        }

        public static string GetFileDirectory(this AttachmentFile? attachmentFile, FileAccessMode accessMode = FileAccessMode.Read)
        {
            if (attachmentFile == null)
                return string.Empty;

            // در حالت خواندن یا نوشتن، از نوع دسترسی تصمیم گرفته می‌شودS
            string folder = GetFolderDirectory(attachmentFile.FileCategory, accessMode);
            return Path.Combine(folder, attachmentFile.FileName).Replace("\\", "/");
        }


        //public static string GetFolderDirectory(FileCategory fileCategory, FileAccessMode accessMode)
        //{
        //    var config = ServiceLocator.GetService<FilePathConfiguration>();
        //    if (config == null)
        //        throw new InvalidOperationException("تنظیمات مسیر فایل یافت نشد.");

        //    string basePath = config.BasePath;

        //    // اگر نسبی بود، مسیر را به wwwroot نگاشت کن
        //    if (!Path.IsPathRooted(basePath) && (!config.IsProductionMode || accessMode == FileAccessMode.Read))
        //        basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", basePath);

        //    string folderPath = fileCategory switch
        //    {
        //        FileCategory.IdentifierAttachment => Path.Combine(basePath, config.IdentifiersAttachmentPath),
        //        _ => basePath
        //    };

        //    if (!Directory.Exists(folderPath))
        //        Directory.CreateDirectory(folderPath);

        //    return folderPath;
        //}

        //public static string GetFileDirectory(this AttachmentFile? attachmentFile)
        //{
        //    if (attachmentFile == null)
        //        return string.Empty;

        //    string folder = GetFolderDirectory(attachmentFile.FileCategory);
        //    return Path.Combine(folder, attachmentFile.FileName);
        //}
    }
}
