using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticeDesktopApp.Utils
{
    class AuthValidation
    {
        
        public static bool CheckPasswordMatch(string pass, string repPass)
        {
            return pass == repPass;
        }

        public static bool CheckSecurePassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            bool isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);

            return isValidated;
        }

    }
}
