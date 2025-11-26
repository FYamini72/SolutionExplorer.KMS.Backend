using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Domain.EntitiesConfigurations
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(150);
            builder.Property(x => x.Code).HasMaxLength(50);
            builder.Property(x => x.EquipmentModel).HasMaxLength(50);
            builder.Property(x => x.SerialNo).HasMaxLength(50);
            builder.Property(x => x.Manufacturer).HasMaxLength(50);
            builder.Property(x => x.ManufactureCountry).HasMaxLength(50);
        }
    }
}
