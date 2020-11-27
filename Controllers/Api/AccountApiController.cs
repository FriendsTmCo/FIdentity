using System.Collections.Generic;
using System.Threading.Tasks;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Fri2Ends.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fri2Ends.Identity.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        #region --Dependency--

        private readonly IAccountRepository _accountUser;
        private readonly IUserRepository _user;

        public AccountApiController(AccountServices accountUser, UserServices user)
        {
            _accountUser = accountUser;
            _user = user;
        }

        #endregion

        #region --Login--

        public async Task<IActionResult> Login(LoginViewModel login)
        {
            return await Task.Run(async () =>
            {
                string ipAddress = HttpContext.Connection.LocalIpAddress.ToString();
                AccountResponseApi result = await _accountUser.LoginAsyncApi(login, ipAddress);

                switch (result)
                {
                    case var _ when result.UserNotFound:
                        return Ok(new ApiResponse<List<string>>()
                        {
                            errorId = "-1",
                            errorTitle = "User Not Found",
                            result = new List<string>() { }
                        });


                    case var _ when result.IsBlocked:
                        return Ok(new ApiResponse<List<string>>()
                        {
                            errorId = "-2",
                            errorTitle = "User Blocked Please Try Latter",
                            result = new List<string>() { }
                        });


                    case var _ when result.WrongPassword:
                        return Ok(new ApiResponse<List<string>>()
                        {
                            errorId = "-2",
                            errorTitle = "Wrong Password",
                            result = new List<string>() { }
                        });


                    case var _ when result.SystemException:
                        return Ok(new ApiResponse<List<string>>()
                        {
                            errorId = "-3",
                            errorTitle = "Exception Please Try Latter",
                            result = new List<string>() { }
                        });


                    case var _ when result.Success:
                        return Ok(new ApiResponse<object>()
                        {
                            errorId = "0",
                            errorTitle = "Success To Login",
                            result = new { Key = result.HeaderKey, Value = result.Session }
                        });

                    default:
                        return Ok(new ApiResponse<object>()
                        {
                            errorTitle = "Null",
                            errorId = "-4",
                            result = new { }
                        });
                }

#pragma warning disable CS0162 // Unreachable code detected
                await _accountUser.Save();
#pragma warning restore CS0162 // Unreachable code detected
            });
        }

        #endregion

        #region --SignUp--

        public async Task<IActionResult> SignUp(SignUpViewModel signUp)
        {
            return await Task.Run(async () =>
            {
                var result = await _accountUser.SignUpAsync(signUp);

                switch (result)
                {
                    case var _ when result.UserExist:
                        return Ok(new ApiResponse<object>()
                        {
                            errorId = "-5",
                            errorTitle = "User Already Exist",
                            result = new { }
                        });

                    case var _ when result.IsBlocked:
                        return Ok(new ApiResponse<object>()
                        {
                            errorId = "-6",
                            errorTitle = "User Blocked Please Try Latter",
                            result = new { }
                        });

                    case var _ when result.Success:
                        return Ok(new ApiResponse<object>()
                        {
                            errorId = "0",
                            errorTitle = "Success To Sign Up Go For Activation and Login",
                            result = new { }
                        });

                    case var _ when result.SystemException:
                        return Ok(new ApiResponse<List<string>>()
                        {
                            errorId = "-3",
                            errorTitle = "Exception Please Try Latter",
                            result = new List<string>() { }
                        });

                    default:
                        return Ok(new ApiResponse<object>()
                        {
                            errorId = "-4",
                            errorTitle = "Null",
                            result = new { }
                        });
                }
#pragma warning disable CS0162 // Unreachable code detected
                await _accountUser.Save();
#pragma warning restore CS0162 // Unreachable code detected
            });
        }

        #endregion

    }
}
