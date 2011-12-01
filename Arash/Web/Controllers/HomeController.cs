using System.Web.Mvc;
using Arash.Membership.Site;

namespace Arash.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : AuthenticationController
    {
        public ActionResult Index()
        {
            var x = User.IsInRole("Admin");
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
