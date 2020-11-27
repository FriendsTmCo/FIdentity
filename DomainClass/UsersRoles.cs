using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fri2Ends.Identity.DomainClass
{
    public record UsersRoles
    {
        public UsersRoles()
        {
            
        }

        [Key]
        public int RoleId { get; set; }

        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(10,ErrorMessage = "{0} Can't Upper Than {1}")]
        [MinLength(3,ErrorMessage = "{0} Can't Smaller Than {1}")]
        public string RoleName { get; set; }

        [Display(Name = "Role Title")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(10, ErrorMessage = "{0} Can't Upper Than {1}")]
        [MinLength(3, ErrorMessage = "{0} Can't Smaller Than {1}")]
        public string RoleTitle { get; set; }

        //Relationships
        public virtual List<UserSelectedRoles> UserSelectedRoles { get; set; }
    }
}
