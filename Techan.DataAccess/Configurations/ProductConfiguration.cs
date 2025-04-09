using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Techan.DataAccess.Configurations;
internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
    }
}

