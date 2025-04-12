using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Claims;
using Techan.Core.Entities.Common;

namespace Techan.DataAccess.Interceptors;
internal class BaseAuditableInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _contextAccessor;

    public BaseAuditableInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _contextAccessor = httpContextAccessor;
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        UpdateEntity(eventData.Context);
        return base.SavedChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntity(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntity(DbContext? context)
    {
        if (context is null) return;

        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            var username = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value ?? "undefined";

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate= DateTime.UtcNow;
                entry.Entity.CreatedBy = username;
                entry.Entity.IsDeleted = false;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedBy = username;
                entry.Entity.UpdatedDate = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Deleted)
            {
                var existingEntry = context.ChangeTracker.Entries<BaseAuditableEntity>()
                    .FirstOrDefault(e => e.Entity.Id == entry.Entity.Id && e != entry);

                if (existingEntry is { })
                {
                    context.Entry(existingEntry.Entity).State = EntityState.Detached;
                }

                entry.State = EntityState.Modified;

                entry.Entity.IsDeleted = true;
                entry.Entity.UpdatedBy = username;
                entry.Entity.UpdatedDate = DateTime.UtcNow;
            }
        }
    }

}
