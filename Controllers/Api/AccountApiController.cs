using System.Collections.Generic;
using System.Threading.Tasks;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Services.Srevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fri2Ends.Identity.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        #region --Dependency--

        private readonly IAccountManager _account;

        public AccountApiController(AccountManager account)
        {
            _account = account;
        }

        #endregion

        #region --Login--

        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var result = await _account.LoginAsync(login, login.RememberMe, 20, HttpContext);

            switch (result.Status)
            {
                case LoginStatus.Success:
                    return Ok(new { Id = 0, Title = "Success", Result = result.Status });

                case LoginStatus.Exception:
                    return Ok(new { Id = -2, Title = "Exception", Result = new { } });

                case LoginStatus.WrongPassword:
                    return Ok(new { Id = -3, Title = "Wrong Password", Result = new { } });

                case LoginStatus.UserNotFound:
                    return Ok(new { Id = -4, Title = "User Not Found", Result = new { } });

                default:
                    goto case LoginStatus.Exception;
            }
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
