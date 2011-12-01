using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arash.Web.ViewModel
{
    public class LogOnViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}