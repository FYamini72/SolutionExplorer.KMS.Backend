using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class IdentifierSearchDto : BaseSearchDto
    {
        /// <summary>
        /// اسم سند
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// شماره سند
        /// </summary>
        public string? DocumentNumber { get; set; }

        /// <summary>
        /// دسته بندی سند
        /// </summary>
        public DocumentCategory? Category { get; set; }

        /// <summary>
        /// شماره ویرایش
        /// </summary>
        public string? EditNo { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تهیه کننده
        /// </summary>
        public int? ProducerUserId { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تایید کننده
        /// </summary>
        public int? FirstConfirmerUserId { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تصدیق کننده 
        /// </summary>
        public int? SecondConfirmerUserId { get; set; }
    }
}