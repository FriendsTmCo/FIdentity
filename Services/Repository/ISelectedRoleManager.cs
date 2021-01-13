using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface ISelectedRoleManager
    {
        Task<bool> IsExistAsync(Guid userId, Guid roleId);
    }
}
