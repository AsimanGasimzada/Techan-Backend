using Techan.DataAccess.Contexts;
using Techan.DataAccess.Repositories.Abstractions;
using Techan.DataAccess.Repositories.Implementations.Generic;

namespace Techan.DataAccess.Repositories.Implementations;
internal class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
