using System.Web;

namespace Arash.Utility.Common
{
    public static class CookiePersister
    {
        private static string GetStringFromCookie(string key)
        {
            return GetObjectFromCookie(key).ToString();
        }

        private static object GetObjectFromCookie(string key)
        {
            return HttpContext.Current.Response.Cookies[key];
        }

        private static void SetItemInCookie(string item, string key)
        {
            HttpCookie cookie = new HttpCookie(key, item);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        
        private static void ClearItemFromCookie(string key)
        {
            HttpContext.Current.Response.Cookies.Remove(key);
        }
    }
}