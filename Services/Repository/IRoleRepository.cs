using Fri2Ends.Identity.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<UsersRoles>> GetAll();
        Task<IEnumerable<UsersRoles>> GetAll(Expression<Func<UsersRoles, bool>> where = null);
        Task<IEnumerable<UsersRoles>> GetByFilter(string q);
        Task<UsersRoles> GetRoleByName(string roleName);
        Task<UsersRoles> GetById(int roleId);
        Task<bool> Insert(UsersRoles role);
        Task<bool> Update(UsersRoles role);
        Task<bool> Delete(UsersRoles role);
        Task<bool> Delete(int roleId);
        Task<bool> Save();
    }
}
