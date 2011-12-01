using System.Threading;
using System.Web.Mvc;

namespace Arash.Membership.Site
{
    public class AuthenticationController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionPersister.SitePrincipal != null)
            {
                Thread.CurrentPrincipal = SessionPersister.SitePrincipal;
                filterContext.HttpContext.User = SessionPersister.SitePrincipal;
            }

            base.OnAuthorization(filterContext);
        }
    }
}