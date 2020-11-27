using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.DomainClass;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Tools;
using Fri2Ends.Identity.ViewModels;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class AccountServices : IAccountRepository, IDisposable
    {
        #region --Dependency--

        private readonly IUserRepository _user;
        private readonly IdentityContext _db;
        private readonly ISessionRepository _session;
        private readonly ILoginRepository _login;
        private readonly ISelectedRoleRepository _selected;
        private readonly IRoleRepository _role;

        public AccountServices(UserServices user, IdentityContext db, SessionServices session, LoginServices login, SelectedRoleServices selected,RoleServices role)
        {
            _role = role;
            _selected = selected;
            _login = login;
            _session = session;
            _user = user;
            _db = db;
        }

        #endregion

        #region --Login Services--

        public async Task<AccountResponse> LoginAsync(LoginViewModel login, string ipAddress)
        {
            AccountResponse response = new AccountResponse();
            return await Task.Run(() =>
            {
                LoginType Type = login.UserName.GetLoginType();

                switch (Type)
                {
                    case var _ when new LoginType().UserName:
                        {
                            Users user = _user.GetByUserName(login.UserName.ToLower().Trim()).Result;
                            if (user != null)
                            {
                                if (_user.CheckPasswordAsync(user, login.Password).Result)
                                {
                                    if (user.IsActive)
                                    {
                                        Sessions session = new Sessions()
                                        {
                                            CreateDate = DateTime.Now,
                                            HeaderKey = "Auth",
                                            Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                            UserId = user.UserId
                                        };

                                        UserLogins logins = new UserLogins()
                                        {
                                            UserId = user.UserId,
                                            Date = DateTime.Now,
                                            DeviceIp = ipAddress
                                        };

                                        if (_session.Insert(session).Result && _session.Save().Result)
                                        {
                                            if (_login.Insert(logins).Result && _session.Save().Result)
                                            {
                                                response.Success = true;
                                                return response;
                                            }
                                            response.SystemException = true;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.IsnotActive = true;
                                    return response;
                                }
                                response.PasswordNotMatch = true;
                                return response;
                            }
                            response.UserNotFound = true;
                            return response;
                        }

                    case var _ when new LoginType().Email:
                        {
                            Users user = _user.GetByUserEmail(login.UserName.ToLower().Trim()).Result;
                            if (user != null)
                            {
                                if (_user.CheckPasswordAsync(user, login.Password).Result)
                                {
                                    if (user.IsActive)
                                    {
                                        Sessions session = new Sessions()
                                        {
                                            CreateDate = DateTime.Now,
                                            HeaderKey = "Auth",
                                            Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                            UserId = user.UserId
                                        };

                                        UserLogins logins = new UserLogins()
                                        {
                                            UserId = user.UserId,
                                            Date = DateTime.Now,
                                            DeviceIp = ipAddress
                                        };

                                        if (_session.Insert(session).Result && _session.Save().Result)
                                        {
                                            if (_login.Insert(logins).Result && _session.Save().Result)
                                            {
                                                response.Success = true;
                                                return response;
                                            }
                                            response.SystemException = true;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.IsnotActive = true;
                                    return response;
                                }
                                response.PasswordNotMatch = true;
                                return response;
                            }
                            response.UserNotFound = true;
                            return response;
                        }

                    case var _ when new LoginType().Phone:
                        {
                            Users user = _user.GetByUserPhone(login.UserName).Result;
                            if (user != null)
                            {
                                if (_user.CheckPasswordAsync(user, login.Password).Result)
                                {
                                    if (user.IsActive)
                                    {
                                        Sessions session = new Sessions()
                                        {
                                            CreateDate = DateTime.Now,
                                            HeaderKey = "Auth",
                                            Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                            UserId = user.UserId
                                        };

                                        UserLogins logins = new UserLogins()
                                        {
                                            UserId = user.UserId,
                                            Date = DateTime.Now,
                                            DeviceIp = ipAddress
                                        };

                                        if (_session.Insert(session).Result && _session.Save().Result)
                                        {
                                            if (_login.Insert(logins).Result && _session.Save().Result)
                                            {
                                                response.Success = true;
                                                return response;
                                            }
                                            response.SystemException = true;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.IsnotActive = true;
                                    return response;
                                }
                                response.PasswordNotMatch = true;
                                return response;
                            }
                            response.UserNotFound = true;
                            return response;
                        }
                    default:
                        {
                            response.UserNotFound = true;
                            return response;
                        }
                }
            });
        }

        public AccountResponse Login(LoginViewModel login, string ipAddress)
        {
            AccountResponse response = new AccountResponse();
            LoginType Type = login.UserName.GetLoginType();

            switch (Type)
            {
                case var _ when new LoginType().UserName:
                    {
                        Users user = _user.GetByUserName(login.UserName.ToLower().Trim()).Result;
                        if (user != null)
                        {
                            if (_user.CheckPasswordAsync(user, login.Password).Result)
                            {
                                if (user.IsActive)
                                {
                                    Sessions session = new Sessions()
                                    {
                                        CreateDate = DateTime.Now,
                                        HeaderKey = "Auth",
                                        Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                        UserId = user.UserId
                                    };

                                    UserLogins logins = new UserLogins()
                                    {
                                        UserId = user.UserId,
                                        Date = DateTime.Now,
                                        DeviceIp = ipAddress
                                    };

                                    if (_session.Insert(session).Result && _session.Save().Result)
                                    {
                                        if (_login.Insert(logins).Result && _session.Save().Result)
                                        {
                                            response.Success = true;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.SystemException = true;
                                    return response;
                                }
                                response.IsnotActive = true;
                                return response;
                            }
                            response.PasswordNotMatch = true;
                            return response;
                        }
                        response.UserNotFound = true;
                        return response;
                    }

                case var _ when new LoginType().Email:
                    {
                        Users user = _user.GetByUserEmail(login.UserName.ToLower().Trim()).Result;
                        if (user != null)
                        {
                            if (_user.CheckPasswordAsync(user, login.Password).Result)
                            {
                                if (user.IsActive)
                                {
                                    Sessions session = new Sessions()
                                    {
                                        CreateDate = DateTime.Now,
                                        HeaderKey = "Auth",
                                        Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                        UserId = user.UserId
                                    };

                                    UserLogins logins = new UserLogins()
                                    {
                                        UserId = user.UserId,
                                        Date = DateTime.Now,
                                        DeviceIp = ipAddress
                                    };

                                    if (_session.Insert(session).Result && _session.Save().Result)
                                    {
                                        if (_login.Insert(logins).Result && _session.Save().Result)
                                        {
                                            response.Success = true;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.SystemException = true;
                                    return response;
                                }
                                response.IsnotActive = true;
                                return response;
                            }
                            response.PasswordNotMatch = true;
                            return response;
                        }
                        response.UserNotFound = true;
                        return response;
                    }

                case var _ when new LoginType().Phone:
                    {
                        Users user = _user.GetByUserPhone(login.UserName).Result;
                        if (user != null)
                        {
                            if (_user.CheckPasswordAsync(user, login.Password).Result)
                            {
                                if (user.IsActive)
                                {
                                    Sessions session = new Sessions()
                                    {
                                        CreateDate = DateTime.Now,
                                        HeaderKey = "Auth",
                                        Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                        UserId = user.UserId
                                    };

                                    UserLogins logins = new UserLogins()
                                    {
                                        UserId = user.UserId,
                                        Date = DateTime.Now,
                                        DeviceIp = ipAddress
                                    };

                                    if (_session.Insert(session).Result && _session.Save().Result)
                                    {
                                        if (_login.Insert(logins).Result && _session.Save().Result)
                                        {
                                            response.Success = true;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.SystemException = true;
                                    return response;
                                }
                                response.IsnotActive = true;
                                return response;
                            }
                            response.PasswordNotMatch = true;
                            return response;
                        }
                        response.UserNotFound = true;
                        return response;
                    }
                default:
                    {
                        response.UserNotFound = true;
                        return response;
                    }
            }
            
        }

        public async Task<AccountResponseApi> LoginAsyncApi(LoginViewModel login, string ipAddress)
        {
            AccountResponseApi response = new AccountResponseApi();
            return await Task.Run(() =>
            {
                LoginType Type = login.UserName.GetLoginType();

                switch (Type)
                {
                    case var _ when new LoginType().UserName:
                        {
                            Users user = _user.GetByUserName(login.UserName.ToLower().Trim()).Result;
                            if (user != null)
                            {
                                if (_user.CheckPasswordAsync(user, login.Password).Result)
                                {
                                    if (user.IsActive)
                                    {
                                        Sessions session = new Sessions()
                                        {
                                            CreateDate = DateTime.Now,
                                            HeaderKey = "Auth",
                                            Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                            UserId = user.UserId
                                        };

                                        UserLogins logins = new UserLogins()
                                        {
                                            UserId = user.UserId,
                                            Date = DateTime.Now,
                                            DeviceIp = ipAddress
                                        };

                                        if (_session.Insert(session).Result && _session.Save().Result)
                                        {
                                            if (_login.Insert(logins).Result && _session.Save().Result)
                                            {
                                                response.Success = true;
                                                response.HeaderKey = session.HeaderKey;
                                                response.Session = session.Session;
                                                return response;
                                            }
                                            response.SystemException = true;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.IsnotActive = true;
                                    return response;
                                }
                                response.WrongPassword = true;
                                return response;
                            }
                            response.UserNotFound = true;
                            return response;
                        }

                    case var _ when new LoginType().Email:
                        {
                            Users user = _user.GetByUserEmail(login.UserName.ToLower().Trim()).Result;
                            if (user != null)
                            {
                                if (_user.CheckPasswordAsync(user, login.Password).Result)
                                {
                                    if (user.IsActive)
                                    {
                                        Sessions session = new Sessions()
                                        {
                                            CreateDate = DateTime.Now,
                                            HeaderKey = "Auth",
                                            Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                            UserId = user.UserId
                                        };

                                        UserLogins logins = new UserLogins()
                                        {
                                            UserId = user.UserId,
                                            Date = DateTime.Now,
                                            DeviceIp = ipAddress
                                        };

                                        if (_session.Insert(session).Result && _session.Save().Result)
                                        {
                                            if (_login.Insert(logins).Result && _session.Save().Result)
                                            {
                                                response.Success = true;
                                                response.Success = true;
                                                response.HeaderKey = session.HeaderKey;
                                                response.Session = session.Session;
                                                return response;
                                            }
                                            response.SystemException = true;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.IsnotActive = true;
                                    return response;
                                }
                                response.WrongPassword = true;
                                return response;
                            }
                            response.UserNotFound = true;
                            return response;
                        }

                    case var _ when new LoginType().Phone:
                        {
                            Users user = _user.GetByUserPhone(login.UserName).Result;
                            if (user != null)
                            {
                                if (_user.CheckPasswordAsync(user, login.Password).Result)
                                {
                                    if (user.IsActive)
                                    {
                                        Sessions session = new Sessions()
                                        {
                                            CreateDate = DateTime.Now,
                                            HeaderKey = "Auth",
                                            Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                            UserId = user.UserId
                                        };

                                        UserLogins logins = new UserLogins()
                                        {
                                            UserId = user.UserId,
                                            Date = DateTime.Now,
                                            DeviceIp = ipAddress
                                        };

                                        if (_session.Insert(session).Result && _session.Save().Result)
                                        {
                                            if (_login.Insert(logins).Result && _session.Save().Result)
                                            {

                                                response.Success = true;
                                                response.HeaderKey = session.HeaderKey;
                                                response.Session = session.Session;
                                                return response;
                                            }
                                            response.SystemException = true;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.IsnotActive = true;
                                    return response;
                                }
                                response.WrongPassword = true;
                                return response;
                            }
                            response.UserNotFound = true;
                            return response;
                        }
                    default:
                        {
                            response.UserNotFound = true;
                            return response;
                        }
                }
            });
        }

        public AccountResponseApi LoginApi(LoginViewModel login, string ipAddress)
        {
            AccountResponseApi response = new AccountResponseApi();
            LoginType Type = login.UserName.GetLoginType();

            switch (Type)
            {
                case var _ when new LoginType().UserName:
                    {
                        Users user = _user.GetByUserName(login.UserName.ToLower().Trim()).Result;
                        if (user != null)
                        {
                            if (_user.CheckPasswordAsync(user, login.Password).Result)
                            {
                                if (user.IsActive)
                                {
                                    Sessions session = new Sessions()
                                    {
                                        CreateDate = DateTime.Now,
                                        HeaderKey = "Auth",
                                        Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                        UserId = user.UserId
                                    };

                                    UserLogins logins = new UserLogins()
                                    {
                                        UserId = user.UserId,
                                        Date = DateTime.Now,
                                        DeviceIp = ipAddress
                                    };

                                    if (_session.Insert(session).Result && _session.Save().Result)
                                    {
                                        if (_login.Insert(logins).Result && _session.Save().Result)
                                        {
                                            response.Success = true;
                                            response.HeaderKey = session.HeaderKey;
                                            response.Session = session.Session;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.SystemException = true;
                                    return response;
                                }
                                response.IsnotActive = true;
                                return response;
                            }
                            response.WrongPassword = true;
                            return response;
                        }
                        response.UserNotFound = true;
                        return response;
                    }

                case var _ when new LoginType().Email:
                    {
                        Users user = _user.GetByUserEmail(login.UserName.ToLower().Trim()).Result;
                        if (user != null)
                        {
                            if (_user.CheckPasswordAsync(user, login.Password).Result)
                            {
                                if (user.IsActive)
                                {
                                    Sessions session = new Sessions()
                                    {
                                        CreateDate = DateTime.Now,
                                        HeaderKey = "Auth",
                                        Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                        UserId = user.UserId
                                    };

                                    UserLogins logins = new UserLogins()
                                    {
                                        UserId = user.UserId,
                                        Date = DateTime.Now,
                                        DeviceIp = ipAddress
                                    };

                                    if (_session.Insert(session).Result && _session.Save().Result)
                                    {
                                        if (_login.Insert(logins).Result && _session.Save().Result)
                                        {
                                            response.Success = true;
                                            response.Success = true;
                                            response.HeaderKey = session.HeaderKey;
                                            response.Session = session.Session;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.SystemException = true;
                                    return response;
                                }
                                response.IsnotActive = true;
                                return response;
                            }
                            response.WrongPassword = true;
                            return response;
                        }
                        response.UserNotFound = true;
                        return response;
                    }

                case var _ when new LoginType().Phone:
                    {
                        Users user = _user.GetByUserPhone(login.UserName).Result;
                        if (user != null)
                        {
                            if (_user.CheckPasswordAsync(user, login.Password).Result)
                            {
                                if (user.IsActive)
                                {
                                    Sessions session = new Sessions()
                                    {
                                        CreateDate = DateTime.Now,
                                        HeaderKey = "Auth",
                                        Session = "Identity-Fri2ends-" + Guid.NewGuid().ToString().GetHashCode().ToString(),
                                        UserId = user.UserId
                                    };

                                    UserLogins logins = new UserLogins()
                                    {
                                        UserId = user.UserId,
                                        Date = DateTime.Now,
                                        DeviceIp = ipAddress
                                    };

                                    if (_session.Insert(session).Result && _session.Save().Result)
                                    {
                                        if (_login.Insert(logins).Result && _session.Save().Result)
                                        {

                                            response.Success = true;
                                            response.HeaderKey = session.HeaderKey;
                                            response.Session = session.Session;
                                            return response;
                                        }
                                        response.SystemException = true;
                                        return response;
                                    }
                                    response.SystemException = true;
                                    return response;
                                }
                                response.IsnotActive = true;
                                return response;
                            }
                            response.WrongPassword = true;
                            return response;
                        }
                        response.UserNotFound = true;
                        return response;
                    }
                default:
                    {
                        response.UserNotFound = true;
                        return response;
                    }
            }
        }


        #endregion

        #region --SignUp Services--

        public async Task<AccountResponse> SignUpAsync(SignUpViewModel signUp, string roleNamme = "users", int roleId = 1)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var user = _user.GetByUserEmail(signUp.Email.ToLower().Trim()).Result;
                    if (user == null)
                    {
                        user = _user.GetByUserName(signUp.UserName.ToLower().Trim()).Result;
                        if (user == null)
                        {
                            Users newUser = new Users()
                            {
                                UserName = signUp.UserName.ToLower().Trim(),
                                Email = signUp.Email,
                                IsActive = false,
                                ActiveCode = Guid.NewGuid().GetHashCode().ToString().Substring(4, 4).Replace("-", string.Empty),
                                IsConfirmEmail = false,
                                IsConfirmPhone = false,
                                RegisterDate = DateTime.Now
                            };

                            if (_user.Insert(newUser).Result && _user.Save().Result)
                            {
                                var existUser = _user.GetByUserName(newUser.UserName).Result;
                                UserSelectedRoles userSelectedRoles = new UserSelectedRoles()
                                {
                                    RoleId = roleId,
                                    UserId = existUser.UserId
                                };
                                if (_selected.Insert(userSelectedRoles).Result && _selected.Save().Result)
                                {
                                    return new AccountResponse() { Success = true };
                                }
                                return new AccountResponse() { Success = true };
                            }
                            return new AccountResponse() { SystemException = true };
                        }
                        return new AccountResponse() { UserExist = true };
                    }
                    return new AccountResponse() { UserExist = true };
                }
                catch
                {
                    return new AccountResponse() { SystemException = true };
                }

            });
        }

        public AccountResponse SignUp(SignUpViewModel signUp, string roleNamme = "users", int roleId = 1)
        {
            try
            {

                var user = _user.GetByUserEmail(signUp.Email.ToLower().Trim()).Result;
                if (user == null)
                {
                    user = _user.GetByUserName(signUp.UserName.ToLower().Trim()).Result;
                    if (user == null)
                    {
                        Users newUser = new Users()
                        {
                            UserName = signUp.UserName.ToLower().Trim(),
                            Email = signUp.Email,
                            IsActive = false,
                            ActiveCode = Guid.NewGuid().GetHashCode().ToString().Substring(4, 4).Replace("-", string.Empty),
                            IsConfirmEmail = false,
                            IsConfirmPhone = false,
                            RegisterDate = DateTime.Now
                        };

                        if (_user.Insert(newUser).Result && _user.Save().Result)
                        {
                            var existUser = _user.GetByUserName(newUser.UserName).Result;
                            UserSelectedRoles userSelectedRoles = new UserSelectedRoles()
                            {
                                RoleId = roleId,
                                UserId = existUser.UserId
                            };
                            if (_selected.Insert(userSelectedRoles).Result && _selected.Save().Result)
                            {
                                return new AccountResponse() { Success = true };
                            }
                            return new AccountResponse() { Success = true };
                        }
                        return new AccountResponse() { SystemException = true };
                    }
                    return new AccountResponse() { UserExist = true };
                }
                return new AccountResponse() { UserExist = true };
            }
            catch
            {
                return new AccountResponse() { SystemException = true };
            }
        }


        #endregion

        #region --Save -- Dispose--

        public async Task<bool> Save()
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        #endregion

        #region --Roles Services--

        public async Task<bool> HasRole(int userId, string roleName)
        {
            return await Task.Run(() =>
            {
                var role = _role.GetRoleByName(roleName).Result;
                if (role != null)
                {
                    var user = _user.GetUserById(userId).Result;
                    if (user != null)
                    {
                        var userRoles = _selected.GetRolesByUserId(user.UserId).Result;
                        foreach (var item in userRoles)
                        {
                            var currentRole = _role.GetById(item.RoleId).Result;
                            if (currentRole != null)
                            {
                                if (currentRole.RoleName == roleName)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    return false;
                }
                return false;
            });
        }

        public async Task<IEnumerable<UsersRoles>> GetRoles(int userId)
        {
            return await Task.Run(() =>
            {
                var roles = _selected.GetRolesByUserId(userId).Result;
                if (roles != null)
                {
                    return roles;
                }
                return null;
            });
        }

        #endregion
    }
}
