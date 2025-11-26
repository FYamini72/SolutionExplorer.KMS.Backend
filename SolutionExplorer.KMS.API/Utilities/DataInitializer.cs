using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Infrastructure.Data;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Domain.Entities.Documents;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.API.Utilities;

public class DataInitializer
{
    internal static async Task Initialize(ApplicationDbContext context)
    {
        context.Database.Migrate();
        await InitData(context);
    }

    private static async Task InitData(ApplicationDbContext context)
    {
        if (!(await context.Set<User>().AnyAsync()))
        {
            var adminRole = new Role { Title = "Admin" };
            var userRole = new Role { Title = "ProjectUser" };

            await context.Set<Role>().AddRangeAsync(new List<Role>()
            {
                adminRole,
                userRole
            });

            await context.Set<User>().AddAsync(new User()
            {
                FirstName = "Farzam",
                LastName = "Yamini",
                UserName = "admin",
                PasswordHash = "Aa@12345".CleanString().GetSha256Hash(),
                SecurityStamp = Guid.NewGuid(),
                UserRoles = new List<UserRole>()
                {
                    new UserRole() { Role = adminRole },
                    new UserRole() { Role = userRole }
                }
            });

            await context.SaveChangesAsync();
        }

        if (!(await context.Set<DocumentInfo>().AnyAsync()))
        {
            var labName = "آزمایشگاه مرکزی";

            var documents = new List<DocumentInfo>
            {
                // 📂 پوشه 1
                new DocumentInfo { Title = "الزامات و اصول کلی", FileName = "1/1.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "تست مهارت و کنترل کیفی داخلی و خارجی", FileName = "1/2.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "عدم انطباق و اقدامات اصلاحی", FileName = "1/3.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "طرح (برنامه) کیفیت", FileName = "1/4.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },

                // 📂 پوشه 2
                new DocumentInfo { Title = "فضای فيزيکی", FileName = "2/1.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "اصول کلی تجهیزات", FileName = "2/2.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "هود بیولوژیک", FileName = "2/3.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "میکروسکوپ", FileName = "2/4.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "فور (آون)", FileName = "2/5.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "انکوباتور", FileName = "2/6.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "اتوكلاو", FileName = "2/7.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "سانتریفیوژ", FileName = "2/8.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "حمام آب (بن ماری)", FileName = "2/9.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "ترازوی دیجیتال", FileName = "2/10.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "pH مترسنج", FileName = "2/11.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "یخچال و فریزر آزمایشگاهی", FileName = "2/12.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "سمپلر", FileName = "2/13.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "جار بی هوازی و جار شمع دار", FileName = "2/14.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "اسپکتروفتومتر", FileName = "2/15.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "کشت خون خودکار", FileName = "2/16.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "لوپ میکروب", FileName = "2/17.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },

                // 📂 پوشه 3
                new DocumentInfo { Title = "رنگ ها و رنگ آمیزی ها", FileName = "3/1.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "معرف ها و محلول ها", FileName = "3/2.docx", LabName = labName, EditNumber = "1", EditDate = "1404/06/25", ReviewDate = "1404/06/30", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },

                // 📂 پوشه 4
                new DocumentInfo { Title = "دستورالعمل کلی", FileName = "4/1.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "نمونه گیری", FileName = "4/2.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "حفظ، نگهداری و انتقال", FileName = "4/3.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "درخواست، برچسب و پذیرش", FileName = "4/4.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "رد و تکرار نمونه", FileName = "4/5.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "اولویت بندی و بررسی ماکروسکوپی", FileName = "4/6.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "آماده سازی نمونه", FileName = "4/7.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "انتخاب محیط", FileName = "4/8.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "انجام و گزارش کشت", FileName = "4/9.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "مدیریت پسماند و شست شو", FileName = "4/10.docx", LabName = labName, EditNumber = "1", EditDate = "1404/07/01", ReviewDate = "1404/07/05", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },

                // 📂 پوشه 5
                new DocumentInfo { Title = "اصول شناسایی", FileName = "5/1.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "کوکسی گرم مثبت کاتالاز مثبت", FileName = "5/2.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "کوکسی گرم مثبت کاتالاز منفی", FileName = "5/3.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "باسیل های گرم مثبت", FileName = "5/4.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "انتروباکترال ها", FileName = "5/5.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "گرم منفی غیرتخمیری هوازی", FileName = "5/6.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "باسیل اکسیداز مثبت گوارشی", FileName = "5/7.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "نايسريا و موراکسلا", FileName = "5/8.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "باسيل گرم منفي سخت رشد", FileName = "5/9.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "بسیار کندرشد و بدون رشد", FileName = "5/10.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "مایکوباکتریوم ها", FileName = "5/11.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "بیهوازی ها", FileName = "5/12.docx", LabName = labName, EditNumber = "2", EditDate = "1404/07/02", ReviewDate = "1404/07/06", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },

                // 📂 پوشه 6
                new DocumentInfo { Title = "دستورالعمل کلی", FileName = "6/1.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "فلور طبیعی و بیماریزا", FileName = "6/2.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "خون", FileName = "6/3.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "مایعات استريل بدن", FileName = "6/4.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "دستگاه تنفسی", FileName = "6/5.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "دستگاه گوارش", FileName = "6/6.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "پوست، بافت و استخوان", FileName = "6/7.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "چشم، گوش و سینوس", FileName = "6/8.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "دستگاه تناسلی", FileName = "6/9.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "ادرار", FileName = "6/10.docx", LabName = labName, EditNumber = "3", EditDate = "1404/07/03", ReviewDate = "1404/07/07", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },

                // 📂 پوشه 7
                new DocumentInfo { Title = "کلیات", FileName = "7/1.docx", LabName = labName, EditNumber = "4", EditDate = "1404/07/04", ReviewDate = "1404/07/08", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "استاندارد نيم مک فارلند", FileName = "7/2.docx", LabName = labName, EditNumber = "4", EditDate = "1404/07/04", ReviewDate = "1404/07/08", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "مراحل عملی", FileName = "7/3.docx", LabName = labName, EditNumber = "4", EditDate = "1404/07/04", ReviewDate = "1404/07/08", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "خوانش و گزارش", FileName = "7/6.docx", LabName = labName, EditNumber = "4", EditDate = "1404/07/04", ReviewDate = "1404/07/08", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "آنتي بيوگرام مستقیم از خون", FileName = "7/7.docx", LabName = labName, EditNumber = "4", EditDate = "1404/07/04", ReviewDate = "1404/07/08", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "نگهداري سويه ها", FileName = "7/8.docx", LabName = labName, EditNumber = "4", EditDate = "1404/07/04", ReviewDate = "1404/07/08", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "کنترل کيفي", FileName = "7/9.docx", LabName = labName, EditNumber = "4", EditDate = "1404/07/04", ReviewDate = "1404/07/08", ConfirmerOneName = "دکتر الف", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "دکتر ب", ConfirmerTwoSignImage = "sample2.png" },

                // 📂 پوشه 7/4
                new DocumentInfo { Title = "کلیات انتخاب آنتی بیوتیک", FileName = "7/4/1.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "کوکسی گرم مثبت کاتالاز مثبت", FileName = "7/4/2.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "کوکسی گرم مثبت کاتالاز منفی", FileName = "7/4/3.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "انتروباکترال ها", FileName = "7/4/4.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "سودوموناس آئروژینوزا", FileName = "7/4/5.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "بورخولدریا سپاسیا", FileName = "7/4/6.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "آسینتوباکتر", FileName = "7/4/7.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "استنوتروفوموناس مالتوفیلیا", FileName = "7/4/8.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "غیر انتروباکترال", FileName = "7/4/9.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "هموفیلوس", FileName = "7/4/10.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "نایسریا و موراکسلا", FileName = "7/4/11.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "بیهوازی ها", FileName = "7/4/12.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "باسیل گرم مثبت", FileName = "7/4/13.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "آئروموناس", FileName = "7/4/14.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "کمپیلوباکتر", FileName = "7/4/15.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "گروه هاسک", FileName = "7/4/16.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "هلیکوباکتر پیلوری", FileName = "7/4/17.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "پاستورلا", FileName = "7/4/18.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "ویبریو", FileName = "7/4/19.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "باکتری های بیوتروریستی", FileName = "7/4/20.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },

                // 📂 پوشه 7/5
                new DocumentInfo { Title = "کلیات مقاومت", FileName = "7/5/1.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "استافیلوکوک", FileName = "7/5/2.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "انتروکوک و استرپتوکوک", FileName = "7/5/3.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "انتروباکترال و سودوموناس آئروجینوزا", FileName = "7/5/4.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "بقیه باکتری ها", FileName = "7/5/5.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },

                // 📂 پوشه 3/3
                new DocumentInfo { Title = "ساخت و کنترل کیفی", FileName = "3/3/1.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "بلادآگار گوسفندی", FileName = "3/3/2.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "شکلات آگار", FileName = "3/3/3.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "مک کانکی آگار (MAC)", FileName = "3/3/4.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "ائوزین متیلن بلو آگار (EMB)", FileName = "3/3/5.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "TCBS آگار", FileName = "3/3/6.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "تایر مارتین آگار", FileName = "3/3/7.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "هکتون انتریک آگار (HE)", FileName = "3/3/8.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "XLD آگار", FileName = "3/3/9.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "مک کانکی سوربیتول آگار", FileName = "3/3/10.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "تیوگلیکولات براث", FileName = "3/3/11.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "(CTA)سیستین تریپتون آگار", FileName = "3/3/12.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },

                // 📂 پوشه 3/4
                new DocumentInfo { Title = "اصول کلی", FileName = "3/4/1.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "حساسیت به باسیتراسین (و کوتریموکسازول)", FileName = "3/4/2.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "حساسیت به اپتوچین", FileName = "3/4/3.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "حساسیت به نووبیوسین", FileName = "3/4/4.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "β-گالاکتوزیداز یا ONPG", FileName = "3/4/5.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "اطمینان-گِرم", FileName = "3/4/6.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "نیازمندی به X و V", FileName = "3/4/7.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "بوتیرات استراز (کاتارالیس)", FileName = "3/4/8.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "آزمایش PYR", FileName = "3/4/9.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "آمینوپپتیداز لوسین (LAP )", FileName = "3/4/10.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "هیدرولیز هیپورات", FileName = "3/4/11.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "اکسیداز", FileName = "3/4/12.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "میکروداز", FileName = "3/4/13.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "کاتالاز", FileName = "3/4/14.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "کواگولاز", FileName = "3/4/15.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "بایل اسکولین", FileName = "3/4/16.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "حلالیت در صفرا", FileName = "3/4/17.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "کمپ( CAMP)", FileName = "3/4/18.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "هیدرولیز DNA (DNase)", FileName = "3/4/19.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "مانیتول سالت آگار", FileName = "3/4/20.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "پیروات براث", FileName = "3/4/21.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "تحمل نمک", FileName = "3/4/22.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "سیترات", FileName = "3/4/23.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "تولید ایندول", FileName = "3/4/24.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "بررسی حرکت", FileName = "3/4/25.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "متیل رد (MR) و (VP)", FileName = "3/4/26.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "اوره آز", FileName = "3/4/27.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "قند سه تایی آهن آگار (TSI)", FileName = "3/4/28.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "لیزین آیرون آگار (LIA)", FileName = "3/4/29.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "کلیگلر آیرون آگار (KIA)", FileName = "3/4/30.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "استفاده از استامید", FileName = "3/4/31.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "استفاده از استات", FileName = "3/4/32.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "احیای نیترات", FileName = "3/4/33.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "دکربوکسیلاز", FileName = "3/4/34.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "فنیل آلانین دآمیناز آگار", FileName = "3/4/35.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "مالونات براث", FileName = "3/4/36.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "هیدرولیز ژلاتین", FileName = "3/4/37.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "رشد در دمای 42درجه", FileName = "3/4/38.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },
                new DocumentInfo { Title = "اکسیداسیون و تخمیر", FileName = "3/4/39.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample1.jpg", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample2.png" },
                new DocumentInfo { Title = "آنتي سرم  ها", FileName = "3/4/40.docx", LabName = labName, EditNumber = "1", EditDate = "1403/01/01", ReviewDate = "1403/02/01", ConfirmerOneName = "تاییدکننده 1", ConfirmerOneSignImage = "sample2.png", ConfirmerTwoName = "تاییدکننده 2", ConfirmerTwoSignImage = "sample1.jpg" },

            };

            await context.Set<DocumentInfo>().AddRangeAsync(documents);
            await context.SaveChangesAsync();
        }

        if(!(await context.Set<Experiment>().AnyAsync()))
        {
            var userId = (await context.Set<User>().FirstOrDefaultAsync())?.Id ?? 0;
            var identifier = new Identifier()
            {
                Category = Domain.Enums.DocumentCategory.BaseInfoMicrobiologyLab,
                EditNo = "ویرایش 1",
                DocumentNumber = "B-001-0002",
                Title = "شناسنامه آزمایشات",
                ProducerUserId = userId,
                FirstConfirmerUserId = userId,
                SecondConfirmerUserId = userId
            };
            await context.Set<Identifier>().AddAsync(identifier);
            await context.SaveChangesAsync();

            var experiments = new List<Experiment>
            {
                new() { Title = "Fungi Direct Smear", Code = "804090", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Fungi Culture & Sensitivity", Code = "804095", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Urethral Discharge Direct Smear", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Urine Culture & Sensitivity:", Code = "804000", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Stool  Culture & Sensitivity:", Code = "804005", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Throat Smear (Gram Stain)", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Throat  Culture & Sensitivity:", Code = "804015", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Sputum  Culture", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Sputum Direct Smear", Code = "804420", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Urethral Discharge C&S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Prostatic Discharge Direct Smear:", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Prostatic Discharge C&S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Vaginal  Direct Smear:", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Vaginal Culture & Sensitivity:", Code = "804040", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Wound Discharge Direct Smear:", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Wound Discharge C&S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Ear Discharge Direct Smear:", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Ear  Culture & Sensitivity:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Nasal  Direct Smear:", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Nasal Discharge C&S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Semen Direct Smear:", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Semen Culture & Sensitivity:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Breast Aspiration Culture&Sensitivity", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Eye Discharge C & S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Gastric  Juice /C&S :", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "BK Smear", Code = "804075", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Nipple Discharge C & S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Pleural Fluid C &S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Ulcer Culture & Sensitivity:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Abscess Drain C&S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Synovial Fluid C & S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Sinus Drain C & S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Scabies Direct Smear:", Code = "804115", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "CSF Culture & Sensitivity:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "CSF Direct Smear", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Ascites C & S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "BK Direct Smear*1(Urine)", Code = "804075", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Post Nasal Discharge C & S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Bronchial Lavage C & S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Peritoneal Dialysis Culture", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Blood Culture*1", Code = "804010", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Leishmania Culture", Code = "804020", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Anaerobic C & S:", Code = "804030", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Tracheal C & S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "BK Smear For Trachea:", Code = "804075", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Bone Marrow C & S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Synovial Fluid For BK:", Code = "804075", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Sputum For Eosinophilia", Code = "802045", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Abscess (C&S):", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Direct Smear:", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Peritoneal Dialysis Direct Smear", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Abscess Discharge Direct Smear", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Testis specimen Direct  smear", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Testis specimen culture&sensitivity", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Tissue culture", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "BK Direct Smear*2(Urine)", Code = "804075", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "BK Direct Smear*3(Urine)", Code = "804075", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Bk Culture*2 ( Urine)", Code = "804080", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Catheter Culture", Code = "804015", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Discharge", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Discharge C&S:", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Urine Culture & Sensitivity:", Code = "804000", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "EPS Culture", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Discharge Culture", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Bronchial Culture", Code = "804035", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Bronchial Discharge Direct Smear:", Code = "804425", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Bactec Culture*3(Fungal)", Code = "804182", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
                new() { Title = "Stool  Culture x3", Code = "804005", IsActive = false, IdentifierId = identifier.Id, FirstConfirmerUserId = userId, SecondConfirmerUserId = userId },
            };

            await context.Set<Experiment>().AddRangeAsync(experiments);
            await context.SaveChangesAsync();
        }
    }
}