using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface ISelectedRoleManager
    {
        Task<IEnumerable<SelectedRoles>> GetAllSelectedRolesAsync();
        Task<IEnumerable<SelectedRoles>> GetAllSelectedRolesAsync(Expression<Func<SelectedRoles,bool>> where);
        Task<SelectedRoles> GetSelectedRolesByIdAsync(int selectedId);
        Task<bool> InsertAsync(SelectedRoles selectedRoles);
        Task<bool> UpdateAsync(SelectedRoles selectedRoles);
        Task<bool> DeleteAsync(SelectedRoles selectedRoles);
        Task<bool> DeleteAsync(int selectedId);
        Task<bool> SaveAsync();
        bool Save();
    }
}
