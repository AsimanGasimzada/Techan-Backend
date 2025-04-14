using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Techan.DataAccess.DataInitalizers;
using Techan.DataAccess.Interceptors;

namespace Techan.DataAccess.Contexts;
internal class AppDbContext : IdentityDbContext<AppUser>
{
    private readonly BaseAuditableInterceptor _interceptor;
    public AppDbContext(DbContextOptions options, BaseAuditableInterceptor interceptor) : base(options)
    {
        _interceptor = interceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.AddSeedData();
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
        base.OnConfiguring(optionsBuilder);
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
