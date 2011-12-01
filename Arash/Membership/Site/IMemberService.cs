using System;
using System.Web.Security;
using Arash.Membership.Model;

namespace Arash.Membership.Site
{
    public interface IMemberService
    {
        ISitePrincipal GetMember();

        void SignIn(Member member, bool createPersistentCookie);

        void SignOut();

        MembershipCreateStatus Validate(Member member);

        bool ChangePassword(string p, string p_2, string p_3);
    }
}