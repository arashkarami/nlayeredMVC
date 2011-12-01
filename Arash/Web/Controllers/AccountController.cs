using System.Web.Mvc;
using System.Web.Security;
using Arash.Membership.Site;
using Arash.Core;
using Arash.Web.ViewModel;
using Arash.Utility.Common;
using Arash.Membership.Model;

namespace Arash.Web.Controllers
{
    public class AccountController : AuthenticationController
    {
        private IMemberService _memberService;
        private IMemberManager _memberManager;

        public AccountController(IMemberService memberService, IMemberManager memberManager)
        {
            _memberService = memberService;
            _memberManager = memberManager;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var member = _memberManager.Authenticate(model.UserName, model.Password);

            if (member == null)
            {
                ModelState.AddModelError(string.Empty, "MessageResource.UsernameOrPasswordIsIncorrect");
                return View(model);
            }

            _memberService.SignIn(member, model.RememberMe);

            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            _memberService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                ModelState.AddModelError("", "Please logout before calling register action");
            ViewBag.PasswordLength = 1;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                ModelState.AddModelError("", "Please logout before calling register action");
            if (!ModelState.IsValid)
                return View(model);

            var member = _memberManager.MakeInstance();
            member.Username = model.Email;
            member.Password = PasswordGenerator.GetHashPassword(model.Password);
            member.RoleId = (int)RoleType.User;
            member.Active = true;

            _memberManager.Add(member);
            _memberService.SignIn(member, false /* createPersistentCookie */);

            return RedirectToAction("Index", "Home");
        }

        public JsonResult ExistUsername(string username)
        {
            var member = _memberManager.MakeInstance();
            member.Username = username;
            var status = _memberService.Validate(member);
            var data = new AjaxMessage();

            if (status == MembershipCreateStatus.Success)
            {
                data.Message = "username is avaiable";
                data.Success = true;
            }
            else
            {
                data.Message = AccountValidation.ErrorCodeToString(status);
                data.Success = false;
            }

            var result = new JsonResult();
            result.Data = data;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (_memberService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            return View(model);
        }

    }
}
