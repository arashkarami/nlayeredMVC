using System.Security.Principal;
using Arash.Membership.Model;

namespace Arash.Membership.Site
{
    public interface ISitePrincipal : IPrincipal
    {
        string Username
        {
            get;
        }

        Role Role
        {
            get;
        }
    }
}