using Fri2Ends.Identity.Services.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class AccountManager : IAccountManager
    {
        #region --Dependency--

        /// <summary>
        /// Users Services
        /// </summary>
        private readonly IUserManager _user;

        /// <summary>
        /// Token Services
        /// </summary>
        private readonly ITokenManager _token;

        /// <summary>
        /// Crud Services For Tokens
        /// </summary>
        private readonly ICrudManager<Tokens> _tokenCrud;

        /// <summary>
        /// Crud Services For Users
        /// </summary>
        private readonly ICrudManager<Users> _userCrud;

        public AccountManager(UserManager user, TokenManager token)
        {
            _token = token;
            _userCrud = user;
            _user = user;
            _tokenCrud = token;
        }

        #endregion

        public Task<ActivationResponse> ActiveUserAsync(ActivationViewModel activation)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteAccountResponse> DeleteAccountAsync(DeleteAccountViewModel deleteAccount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(string userName, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(Users user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(IRequestCookieCollection cookies, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(IHeaderDictionary headers, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> LoginAsync(LoginViewModel login, bool rememmeberMe, int expireDays = 20)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LogoutAsync(IRequestCookieCollection cookies)
        {
            return await Task.Run(async () =>
            {
                var token = cookies["Token"];
                return await _tokenCrud.DeleteAsync(token) && await _tokenCrud.SaveAsync();
            });
        }

        public async Task<bool> LogoutAsync(IHeaderDictionary headers)
        {
            return await Task.Run(async () =>
            {
                var token = headers["Token"];
                return await _tokenCrud.DeleteAsync(token) && await _tokenCrud.SaveAsync();
            });
        }

        public async Task<SignUpResponse> SignUpAsync(SignupViewModel signUp)
        {
            return await Task.Run(async () =>
            {
                SignUpResponse response = new();
                var user = await _user.CreateUserAsync(signUp);
                if (!await _user.IsExistAsync(user.UserName))
                {

                    if (await _userCrud.InsertAsync(user) && await _userCrud.SaveAsync())
                    {
                        response.Success = true;
                        return response;
                    }

                    response.Exception = true;
                    return response;
                }
                response.UserAlreadyExist = true;
                return response;
            });
        }

       
    }
}
