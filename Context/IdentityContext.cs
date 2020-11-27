using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fri2Ends.Identity.DomainClass;
using Microsoft.EntityFrameworkCore;

namespace Fri2Ends.Identity.Context
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }
        public DbSet<UserSelectedRoles> UserSelectedRoles { get; set; }
        public DbSet<UserLogins> UserLogins { get; set; }

    }
}
