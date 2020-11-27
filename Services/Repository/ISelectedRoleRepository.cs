using Fri2Ends.Identity.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface ISelectedRoleRepository
    {
        Task<IEnumerable<UserSelectedRoles>> GetAll();
        Task<IEnumerable<UserSelectedRoles>> GetAll(Expression<Func<UserSelectedRoles, bool>> where = null);
        Task<UserSelectedRoles> GetById(int selectedId);
        Task<IEnumerable<UsersRoles>> GetRolesByUserId(int userId);
        Task<bool> Insert(UserSelectedRoles selectedRoles);
        Task<bool> Update(UserSelectedRoles selectedRoles);
        Task<bool> Delete(UserSelectedRoles selectedRoles);
        Task<bool> Delete(int selectedId);
        Task<bool> Save();
    }
}
