using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Domain.EntitiesConfigurations
{
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
