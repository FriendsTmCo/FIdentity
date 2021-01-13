using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Context
{
    public class FIdentityContext : DbContext
    {
        public FIdentityContext(DbContextOptions<FIdentityContext> options) : base(options)
        {

        }

        /// <summary>
        /// Roles Table
        /// </summary>
        public DbSet<Roles> Roles { get; set; }

        /// <summary>
        /// Selected User Roles
        /// </summary>
        public DbSet<SelectedRoles> SelectedRoles { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public DbSet<Users> Users { get; set; }

        /// <summary>
        /// User Tokens
        /// </summary>
        public DbSet<Tokens> Tokens { get; set; }

        /// <summary>
        /// Login Logs
        /// </summary>
        public DbSet<LoginLogs> LoginLogs { get; set; }
    }
}
