using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fri2Ends.Identity.Controllers
{
    public class AccountController : Controller
    {
        #region --Dependency--

        private readonly IAccountRepository _account;


        #endregion

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            return Ok();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(SignUpViewModel signUp)
        {
            return Ok();
        }
    }
}
