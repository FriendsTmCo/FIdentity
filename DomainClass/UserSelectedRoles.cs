using System.ComponentModel.DataAnnotations;

namespace Fri2Ends.Identity.DomainClass
{
    public record UserSelectedRoles
    {
        public UserSelectedRoles()
        {
            
        }

        [Key]
        public int SelectedId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int UserId { get; set; }

        //Relationships
        public virtual UsersRoles UsersRoles { get; set; }
        public virtual Users Users { get; set; }
    }
}
