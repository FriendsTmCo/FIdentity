using System.ComponentModel.DataAnnotations;

namespace Fri2Ends.Identity.ViewModels
{
    public struct SignUpViewModel
    {
        /// <summary>
        /// User Name That Required
        /// </summary>
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(50, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(5, ErrorMessage = "{0} Length Can't Smaller Than {1}")]
        public string UserName { get; set; }


        /// <summary>
        /// Email Is Optional
        /// </summary>
        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(5, ErrorMessage = "{0} Length Can't Smaller Than {1}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// User Hash Password
        /// </summary>
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(27, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(6, ErrorMessage = "{0} Length Can't Smaller Than {1}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Confirm Password
        /// </summary>
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(27, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(6, ErrorMessage = "{0} Length Can't Smaller Than {1}")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Passwords not Match")]
        public string RePassword { get; set; }
    }
}
