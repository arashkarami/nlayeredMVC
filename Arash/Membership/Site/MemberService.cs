using System.Web;
using System.Web.Security;
using System;
using Arash.Core;
using Arash.Core.Manager;
using Arash.Membership.Model;
using Paradiso.Infrastructure.Data;
using Arash.Utility.Common;

namespace Arash.Membership.Site
{
    public class MemberService : IMemberService
    {
        private IMemberManager _memberManager;

        public MemberService(IMemberManager memberManager)
        {
            _memberManager = memberManager;
        }

        public ISitePrincipal GetMember()
        {
            var context = HttpContext.Current;

            if (context.User == null)
                return null;

            if (!context.User.Identity.IsAuthenticated)
                return null;

            var member = _memberManager.Get(p => p.Username == context.User.Identity.Name);

            if (member == null)
                return null;

            return new SitePrincipal(member);
        }

        public MembershipCreateStatus Validate(Member member)
        {
            var entity = _memberManager.Get(p => p.Username == member.Username);

            if (entity == null)
                return MembershipCreateStatus.Success;
            return MembershipCreateStatus.DuplicateUserName;
        }

        public void SignIn(Member member, bool createPersistentCookie)
        {
            if (member == null && String.IsNullOrEmpty(member.Username))
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            SetAuthenticationValues(member);
        }

        private void SetAuthenticationValues(Member member)
        {
            SessionPersister.SitePrincipal = new SitePrincipal(member);
        }

        private void ClearAuthenticationValues()
        {
            SessionPersister.SitePrincipal = null;
        }

        public void SignOut()
        {
            ClearAuthenticationValues();
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(oldPassword) || String.IsNullOrEmpty(newPassword))
                return false;

            var currentUser = _memberManager.Get(p => p.Username == username);

            if (currentUser != null)
                return false;

            if (!PasswordGenerator.Equals(oldPassword, currentUser.Password))
            {
                return false;
            }

            currentUser.Password = PasswordGenerator.GetHashPassword(newPassword);

            _memberManager.Edit(currentUser);
            return true;
        }
    }
}