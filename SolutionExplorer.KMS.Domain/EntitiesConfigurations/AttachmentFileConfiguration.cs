using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Domain.EntitiesConfigurations
{
    public class AttachmentFileConfiguration : IEntityTypeConfiguration<AttachmentFile>
    {
        public void Configure(EntityTypeBuilder<AttachmentFile> builder)
        {
            builder.Property(x => x.FileName).HasMaxLength(100);
        }
    }
}
