using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arash.Utility.Common
{
    public class PasswordGenerator
    {
        public static string GetHashPassword(string password)
        {
            // TODO: hash password
            return password;
        }

        public static bool Equals(string password, string hashedPassword)
        {
            return string.Equals(GetHashPassword(password), hashedPassword);
        }
    }
}
