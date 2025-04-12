using Techan.DataAccess.Contexts;
using Techan.DataAccess.Repositories.Abstractions;
using Techan.DataAccess.Repositories.Implementations.Generic;

namespace Techan.DataAccess.Repositories.Implementations;
internal class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(AppDbContext context) : base(context)
    {
    }
}
