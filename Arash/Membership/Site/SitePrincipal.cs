using System;
using System.Security.Principal;
using Arash.Membership.Model;

namespace Arash.Membership.Site
{
    public class SitePrincipal : ISitePrincipal
    {
        public SitePrincipal(Member user)
        {
            this.Identity = new SiteIdentity();
            this.Username = user.Username;
            this.Role = user.Role;
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            if (Role == null && string.IsNullOrEmpty(this.Role.Name))
                return false;

            return string.Equals(this.Role.Name, role, StringComparison.OrdinalIgnoreCase);
        }

        public string Username
        {
            get;
            private set;
        }

        public Role Role
        {
            get;
            private set;
        }
    }
}