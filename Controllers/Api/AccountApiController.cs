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

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            LoginResponse result = await _account.LoginAsync(login, login.RememberMe, 20, HttpContext);

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

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignupViewModel signUp)
        {
            SignUpResponse result = await _account.SignUpAsync(signUp);

            switch (result)
            {
                case SignUpResponse.Success:
                    return Ok(new { Id = 0, Title = "Success Go To Active Account", Result = new { } });

                case SignUpResponse.Exception:
                    return Ok(new { Id = -2, Title = "Exception", Result = new { } });

                case SignUpResponse.UserAlreadyExist:
                    return Ok(new { Id = -3, Title = "User Already Exist", Result = new { } });

                default:
                    goto case SignUpResponse.Exception;
            }
        }

        #endregion

        #region --Activation--

        [HttpPost]
        [Route("Activation")]
        public async Task<IActionResult> Activation(ActivationViewModel activation)
        {
            ActivationResponse result = await _account.ActiveUserAsync(activation);

            switch (result)
            {
                case ActivationResponse.Success:
                    return Ok(new { Id = 0, Title = "User Actived", Result = new { } });

                case ActivationResponse.WrongActiveCode:
                    return Ok(new { Id = -1, Title = "Wrong ActiveCode", Result = new { } });

                case ActivationResponse.Exception:
                    return Ok(new { Id = -3, Title = "Exception", Result = new { } });

                default:
                    goto case ActivationResponse.Exception;
            }
        }

        #endregion


    }
}
