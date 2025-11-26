
using Microsoft.AspNetCore.Http;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class ReferenceCreateDto : BaseDto
    {
        /// <summary>
        /// عنوان
        /// </summary>
		public string? Title { get; set; }

        /// <summary>
        /// فایل پیوست
        /// </summary>
        public IFormFile? SelectedFile { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string? Description { get; set; }
    }
}