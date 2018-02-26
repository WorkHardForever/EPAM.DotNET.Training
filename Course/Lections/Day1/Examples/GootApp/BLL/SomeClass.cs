using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class SomeClass
    {
        public static string SomeMethod(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException("userName");
                //throw new ArgumentNullException(nameof(userName));
            }
            if (userName == string.Empty)
            {
                return "Hello, anonim!";
            }

            return string.Format("Hello, {0}!", userName);
            //return  $"Hello, {userName}!";
        }
    }
}


