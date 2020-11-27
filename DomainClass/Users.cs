using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fri2Ends.Identity.DomainClass
{

    /// <summary>
    /// User Model For Any Identity
    /// </summary>
    public record Users
    {
        public Users()
        {
            
        }

        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// User Name That Required
        /// </summary>
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(50, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(5, ErrorMessage =  "{0} Length Can't Smaller Than {1}")]
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
        /// Phone Number Is Required
        /// </summary>
        [Display(Name = "Phone Number")]
        [MaxLength(12, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(11, ErrorMessage = "{0} Length Can't Smaller Than {1}")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Confirm With Phone Number?
        /// </summary>
        [Required]
        public bool IsConfirmPhone { get; set; }
        
        /// <summary>
        /// Confirm With Email Address?
        /// </summary>
        [Required]
        public bool IsConfirmEmail { get; set; }


        /// <summary>
        /// This User Is Active?
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// User Activation Code
        /// </summary>
        [Display(Name = "Activation Code")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(4, ErrorMessage = "{0} Length Can't Upper Than {1}")]
        [MinLength(4, ErrorMessage = "{0} Length Can't Smaller Than {1}")]
        public string ActiveCode { get; set; }


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
        /// User Register Date
        /// </summary>
        [Required]
        public DateTime RegisterDate { get; set; }


        //Relationships
        public virtual List<Sessions> Sessions { get; set; }
        public virtual List<UserLogins> Logins { get; set; }
        public virtual List<UserSelectedRoles> UserSelectedRoles { get; set; }
    }
}
