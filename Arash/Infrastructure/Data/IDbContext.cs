using System.Data.Entity;

namespace Paradiso.Infrastructure.Data
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;

        Database Db { get; }

        int SaveChanges();
    }
}
