using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface IRoleManager
    {
        Task<IEnumerable<Roles>> GetAllRolesAsync();
        Task<IEnumerable<Roles>> GetAllRolesAsync(Expression<Func<bool,Roles>> where);
        Task<IEnumerable<Roles>> GetRolesBySearchAsync(string q);
        Task<Roles> GetRoleByIdAsync(int roleId);
        Task<bool> InsertAsync(Roles role);
        Task<bool> UpdateAsync(Roles role);
        Task<bool> DeleteAsync(Roles role);
        Task<bool> DeleteAsync(int roleId);
        Task<bool> SaveAsync();
        bool Save();
    }
}
