using System.Collections.Generic;
using Fri2Ends.Identity.DomainClass;

namespace Fri2Ends.Identity.ViewModels
{
    public struct AccountResponse
    {
        public bool UserExist { get; set; }
        public bool UserNotFound { get; set; }
        public bool PasswordNotMatch { get; set; }
        public bool Success { get; set; }
        public bool IsBlocked { get; set; }
        public bool SystemException { get; set; }
        public bool IsnotActive { get; set; }
    }

    public struct AccountResponseApi
    {
        public bool SystemException { get; set; }
        public bool UserExist { get; set; }
        public bool UserNotFound { get; set; }
        public bool WrongPassword { get; set; }
        public bool IsBlocked { get; set; }
        public string HeaderKey { get; set; }
        public string Session { get; set; }
        public bool Success { get; set; }
        public bool IsnotActive { get; set; }

    }

    public struct LoginResponseInfos
    {
        public bool IsLogin { get; set; }
        public bool NotFound { get; set; }
        public List<UserLogins> UserLogins { get; set; }
    }

    public struct RoleResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
