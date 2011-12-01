using System.Security.Principal;

namespace Arash.Membership.Site
{
    public class SiteIdentity : IIdentity
    {
        public string AuthenticationType
        {
            get { return "ArKaAuthentication"; }
        }

        public bool IsAuthenticated
        {
            get
            {
                return (SessionPersister.SitePrincipal != null);
            }
        }

        public string Name
        {
            get { return SessionPersister.SitePrincipal.Username; }
        }
    }

}