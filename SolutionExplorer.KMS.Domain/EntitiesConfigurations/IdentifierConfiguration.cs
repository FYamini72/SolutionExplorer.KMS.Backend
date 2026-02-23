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
    public class PersonnelConfiguration : IEntityTypeConfiguration<Personnel>
    {
        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.Property(x => x.EducationalField).HasMaxLength(150);
            builder.Property(x => x.OrganizationalChart).HasMaxLength(750);
        }
    }
}
