using System.Web;
using Arash.Utility.Common;

namespace Arash.Membership.Site
{
    public static class SessionPersister
    {
        public static ISitePrincipal SitePrincipal
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                if (HttpContext.Current.Session[The.principal] != null)
                    return GetObjectFromSession(The.principal) as ISitePrincipal;
                return null;
            }
            set
            {
                if (value == null)
                    ClearItemFromSession(The.principal);
                SetItemInSession(value, The.principal);
            }
        }

        private static string GetStringFromSession(string key)
        {
            return GetObjectFromSession(key).ToString();
        }

        private static object GetObjectFromSession(string key)
        {
            return HttpContext.Current.Session[key];
        }

        private static void SetItemInSession(object item, string key)
        {
            HttpContext.Current.Session.Add(key, item);
        }

        private static void ClearItemFromSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
}