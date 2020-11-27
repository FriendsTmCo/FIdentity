using System;

namespace Fri2Ends.Identity.Tools
{
    /// <summary>
    /// Login Type For Check What The Input Type (Email,User Name ,Phone)
    /// </summary>
    public class LoginType
    {

        /// <summary>
        /// if input for Login  is Phone This True
        /// </summary>
        public bool Phone { get; set; }

        /// <summary>
        /// if input for Login is Email This True
        /// </summary>
        public bool Email { get; set; }

        /// <summary>
        /// if input for Login is User Name This True
        /// </summary>
        public bool UserName { get; set; }
    }
}
