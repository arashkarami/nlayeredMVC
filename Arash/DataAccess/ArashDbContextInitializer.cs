using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Arash.Core.Model;
using Arash.DataAccess;

namespace Arash.DataAccess
{
    public class ArashDbContextInitializer : DropCreateDatabaseAlways<ArashDbContext>
    {
        protected override void Seed(ArashDbContext context)
        {
            #region entity type
            new List<EntityType>
            {
                new EntityType {
                    Name = "Coffeeshop"
                },
                new EntityType {
                    Name = "bar"
                }
            }.ForEach(m => context.EntityType.Add(m));
            #endregion

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var ex = e.EntityValidationErrors.ToList();
            }

            base.Seed(context);
        }
    }
}