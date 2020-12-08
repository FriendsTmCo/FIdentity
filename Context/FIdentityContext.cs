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
    }
}
