using System;
using System.ComponentModel.DataAnnotations;

namespace Fri2Ends.Identity.DomainClass
{
    /// <summary>
    /// User Login Infos
    /// </summary>
    public record UserLogins
    {
        public UserLogins()
        {
            
        }

        [Key]
        public int LoginId { get; set; }

        /// <summary>
        /// Save Device Ip Address When Login With  that
        /// </summary>
        [Required]
        public string DeviceIp { get; set; }

        /// <summary>
        /// Login Date time 
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

        //Relationships
        public virtual Users Users { get; set; }

    }
}
