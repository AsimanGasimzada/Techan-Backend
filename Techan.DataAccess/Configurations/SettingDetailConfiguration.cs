using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Techan.DataAccess.Configurations;

internal class SettingDetailConfiguration : IEntityTypeConfiguration<SettingDetail>
{
    public void Configure(EntityTypeBuilder<SettingDetail> builder)
    {
        builder.HasIndex(x => new { x.SettingId, x.LanguageId }).IsUnique();

        builder.Property(x => x.Value).IsRequired().HasMaxLength(256);
    }
}