using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Techan.DataAccess.Configurations;

internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(512);
    }
}
