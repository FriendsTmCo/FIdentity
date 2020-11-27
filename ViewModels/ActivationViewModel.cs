using System.ComponentModel.DataAnnotations;

namespace Fri2Ends.Identity.ViewModels
{
    public struct ActivationViewModel
    {
        /// <summary>
        /// Email Is Optional
        /// </summary>
        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(5, ErrorMessage = "{0} Length Can't Smaller Than {1}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        /// <summary>
        /// Phone Number Is Required
        /// </summary>
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(20, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(11, ErrorMessage = "{0} Length Can't Smaller Than {1}")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Activation Code
        /// </summary>
        [Display(Name = "Activation Code")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(4, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(4, ErrorMessage = "{0} Length Can't Smaller Than {1}")]
        public string ActiveCode { get; set; }
    }
}
