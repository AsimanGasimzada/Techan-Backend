using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Techan.DataAccess.Configurations;
internal class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.HasIndex(x => x.Key).IsUnique();

        builder.Property(x => x.Key).HasMaxLength(64).IsRequired();
    }
}
