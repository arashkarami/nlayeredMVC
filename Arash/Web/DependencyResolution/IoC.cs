using Arash.DataAccess;
using Arash.Membership.Site;
using Paradiso.Infrastructure.Data;
using StructureMap;
using Arash.Infrastructure.Data;
using Arash.DataAccess.Repository;

namespace Arash.Web.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.Assembly("Arash.Core");
                    scan.Assembly("Arash.Membership");
                    scan.Assembly("Arash.Restaurant");

                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    //scan.Assembly("Paradizon.Service");
                });
                x.For<IDbContext>().Use<ArashDbContext>();
                x.For(typeof(IRepository<>)).Use(typeof(Repository<>));
                x.For<IMemberService>().Use<MemberService>();
            });

            return ObjectFactory.Container;
        }
    }
}