using Fri2Ends.Identity.Services.Repository;
using Microsoft.AspNetCore.Http;
using System;
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

        /// <summary>
        /// Log Services For Login Logs
        /// </summary>
        private readonly ICrudManager<LoginLogs> _logCrud;

        /// <summary>
        /// Role Services
        /// </summary>
        private readonly IRoleManager _role;

        /// <summary>
        /// Selected Role Services
        /// </summary>
        private readonly ISelectedRoleManager _selectedRole;

        public AccountManager(UserManager user, TokenManager token, LoginLogsManager logs, RoleManager role, SelectedRoleManager selectedRole)
        {
            _selectedRole = selectedRole;
            _role = role;
            _logCrud = logs;
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

        public async Task<bool> CheckPasswordAsync(Users user, string currentPassword)
        {
            return await Task.Run(async () =>
                 user.Password == await currentPassword.CreateSHA256Async());
        }

        public Task<DeleteAccountResponse> DeleteAccountAsync(DeleteAccountViewModel deleteAccount)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsInRoleAsync(string userName, string roleName)
        {
            return await Task.Run(async () =>
            {
                Users user = await _user.GetUserByUserNameAsync(userName);
                return await IsInRoleAsync(user, roleName);
            });
        }

        public async Task<bool> IsInRoleAsync(Users user, string roleName)
        {
            return await Task.Run(async () =>
            {
                Roles role = await _role.GetRoleByNameAsync(roleName);
                return await _selectedRole.IsExistAsync(user.UserId, role.RoleId);
            });
        }

        public async Task<bool> IsInRoleAsync(IRequestCookieCollection cookies, string roleName)
        {
            return await Task.Run(async () =>
            {
                return true;
            });
        }

        public Task<bool> IsInRoleAsync(IHeaderDictionary headers, string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponse> LoginAsync(LoginViewModel login, bool rememmeberMe, int expireDays = 20, HttpContext context = null)
        {
            return await Task.Run(async () =>
            {
                LoginResponse response = new();

                Users user = await _user.GetUserByEmailAsync(login.Email);
                if (user != null)
                {
                    if (await CheckPasswordAsync(user, login.Password))
                    {
                        Tokens token = await CreateTokenAsync(user, expireDays);
                        if (await _tokenCrud.InsertAsync(token) && await _tokenCrud.SaveAsync())
                        {
                            LoginLogs log = await CreateLogAsync(token, context);
                            await _logCrud.InsertAsync(log); await _logCrud.SaveAsync();

                            //Create Success Type 
                            if (rememmeberMe)
                            {
                                response.Success = new Success
                                {
                                    IsSucces = true,
                                    Key = token.TokenKey,
                                    Value = token.TokenValue
                                };
                            }

                            response.Status = LoginStatus.Success;
                            return response;
                        }
                        response.Status = LoginStatus.Exception;
                        return response;
                    }
                    response.Status = LoginStatus.WrongPassword;
                    return response;
                }

                response.Status = LoginStatus.UserNotFound;
                return response;


            });
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
                var user = await _user.CreateUserAsync(signUp);
                if (!await _user.IsExistAsync(user.UserName))
                {
                    if (await _userCrud.InsertAsync(user) && await _userCrud.SaveAsync())
                    {
                        return SignUpResponse.Success;
                    }
                    return SignUpResponse.Exception;
                }
                return SignUpResponse.UserAlreadyExist;
            });
        }

        private async Task<Tokens> CreateTokenAsync(Users user, int expire)
        {
            return await Task.Run(() =>
            {
                return new Tokens
                {
                    UserId = user.UserId,
                    InsertDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddDays(expire),
                    TokenKey = "Token",
                    TokenValue = Guid.NewGuid().ToString().CreateSHA256()
                };
            });
        }

        private async Task<LoginLogs> CreateLogAsync(Tokens token, HttpContext context)
        {
            return await Task.Run(() =>
            {
                return new LoginLogs
                {
                    LocalIpAddress = context.Connection.LocalIpAddress.ToString(),
                    LocalPort = context.Connection.LocalPort.ToString(),
                    RemoteIpAddress = context.Connection.RemoteIpAddress.ToString(),
                    RemotePort = context.Connection.RemotePort.ToString(),
                    SetDate = DateTime.Now,
                    TokenId = token.TokenId
                };
            });
        }
    }
}
