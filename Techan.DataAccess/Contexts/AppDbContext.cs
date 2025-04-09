namespace Techan.DataAccess.Contexts;
internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public required DbSet<Product> Products { get; set; }
    public required DbSet<ProductCategory> ProductCategories { get; set; }
    public required DbSet<ProductDetail> ProductDetails { get; set; }
    public required DbSet<ProductImage> ProductImages { get; set; }
    public required DbSet<Brand> Brands { get; set; }
    public required DbSet<BrandDetail> BrandDetails { get; set; }
    public required DbSet<Category> Categories { get; set; }
    public required DbSet<Language> Languages { get; set; }
    public required DbSet<ProductProperty> ProductProperties { get; set; }
}
