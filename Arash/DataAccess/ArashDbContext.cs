using System.Data.Entity;
using Arash.Core.Model;
using Arash.Membership.Model;
using Arash.Restaurant.Model;
using Paradiso.Infrastructure.Data;

namespace Arash.DataAccess
{
    public class ArashDbContext : DbContext, IDbContext
    {
        public ArashDbContext() : base("arashConnectionString") { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<EntityBase> EntityBases { get; set; }
        public DbSet<EntityType> EntityType { get; set; }
        public DbSet<Tag> Tages { get; set; }
        public DbSet<TagEntity> TagEntities { get; set; }
        public DbSet<Coffeeshop> Coffeeshops { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public Database Query
        {
            get { return this.Database; }
        }

        public IDbSet<T> GetDbSet<T>() where T : class
        {
            return null;
        }

        public Database Db
        {
            get { return this.Database; }
        }
    }
}
