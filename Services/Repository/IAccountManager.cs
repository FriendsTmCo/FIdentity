using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    /// <summary>
    /// Account Services 
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// SignUp User 
        /// </summary>
        /// <param name="signUp">SignUp View Model</param>
        /// <returns></returns>
        Task<SignUpResponse> SignUpAsync(SignupViewModel signUp);

        /// <summary>
        /// Login Existing User
        /// </summary>
        /// <param name="login">Login View Model</param>
        /// <param name="rememmeberMe">Set Cookies For Remember User</param>
        /// <param name="expireDays">Expire Days Default 20 days</param>
        /// <returns></returns>
        Task<LoginResponse> LoginAsync(LoginViewModel login,bool rememmeberMe,int expireDays = 20);

        /// <summary>
        /// Active or Confitm Existing User Account
        /// </summary>
        /// <param name="activation">Activation View Model</param>
        /// <returns></returns>
        Task<ActivationResponse> ActiveUserAsync(ActivationViewModel activation);

        /// <summary>
        /// Delete Exisitng User Account
        /// </summary>
        /// <param name="deleteAccount">delete Account View Model</param>
        /// <returns></returns>
        Task<DeleteAccountResponse> DeleteAccountAsync(DeleteAccountViewModel deleteAccount);

        /// <summary>
        /// Logout User
        /// </summary>
        /// <param name="cookies">User Header Cookies
        /// var cookies = HttpContext.Request.Cookies</param>
        /// <returns></returns>
        Task<bool> LogoutAsync(IRequestCookieCollection cookies);
    }
}
