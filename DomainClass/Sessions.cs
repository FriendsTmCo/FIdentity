using System;
using System.ComponentModel.DataAnnotations;

namespace Fri2Ends.Identity.DomainClass
{
    /// <summary>
    /// User and Admin Sessions
    /// </summary>
    public record Sessions
    {
        public Sessions()
        {
            
        }

        [Key]
        public int SessionId { get; set; }

        /// <summary>
        /// Session Header For Clients
        /// </summary>
        [Required]
        public string HeaderKey { get; set; }

        /// <summary>
        /// Session Value
        /// </summary>
        [Required]
        public string Session { get; set; }

        /// <summary>
        /// Set Session Date Time
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Delete Session Date Time
        /// </summary>
        [Required]
        public DateTime SetTimeOut { get; set; }

        /// <summary>
        /// This Session For This User 
        /// </summary>
        [Required] public int UserId { get; set; }

        //Relationships
        public virtual Users Users { get; set; }
      
    }
}
