using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Domain.EntitiesConfigurations
{
    public class IdentifierConfiguration : IEntityTypeConfiguration<Identifier>
    {
        public void Configure(EntityTypeBuilder<Identifier> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(150);
            builder.Property(x => x.DocumentNumber).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(1000);
        }
    }
    public class LabReportHistoryConfiguration : IEntityTypeConfiguration<LabReportHistory>
    {
        public void Configure(EntityTypeBuilder<LabReportHistory> builder)
        {
            builder.Property(x => x.PatientName).HasMaxLength(100);
            builder.Property(x => x.AdmissionNumber).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(1500);
            builder.Property(x => x.ReporterComment).HasMaxLength(1500);
        }
    }
}
