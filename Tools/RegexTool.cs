using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Tools
{

    /// <summary>
    /// Regex Tools
    /// </summary>
    public static class RegexTool
    {
        /// <summary>
        /// Check Types With Regex
        /// </summary>
        /// <param name="value">Value For Check</param>
        /// <returns></returns>
        public static LoginType GetLoginType(this string value)
        {
            LoginType loginType = new LoginType();

            string phoneRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";

            string emailRegex =
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            Regex regexPhone = new Regex(phoneRegex,RegexOptions.IgnoreCase);
            if (regexPhone.IsMatch(value))
            {
                loginType.Phone = true;
                return loginType;
            }

            Regex regexEmail = new Regex(emailRegex,RegexOptions.IgnoreCase);
            if (regexEmail.IsMatch(value))
            {
                loginType.Email = true;
                return loginType;
            }

            loginType.UserName = true;
            return loginType;
        }
    }
}
