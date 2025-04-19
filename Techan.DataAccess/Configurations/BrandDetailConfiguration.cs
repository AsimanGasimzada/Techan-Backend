using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Techan.DataAccess.Configurations;

internal class BrandDetailConfiguration : IEntityTypeConfiguration<BrandDetail>
{
    public void Configure(EntityTypeBuilder<BrandDetail> builder)
    {
        builder.HasIndex(x => new { x.BrandId, x.LanguageId }).IsUnique();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(1024);
    }
}
