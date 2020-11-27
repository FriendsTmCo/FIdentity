using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.DomainClass;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class RoleServices : IRoleRepository, IDisposable
    {

        private readonly IdentityContext _db;

        public RoleServices(IdentityContext db)
        {
            _db = db;
        }

        public async Task<bool> Delete(UsersRoles role)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.UsersRoles.Remove(role);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Delete(int roleId)
        {
            return await Task.Run(()=> Delete(GetById(roleId).Result));
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<IEnumerable<UsersRoles>> GetAll()
        {
            return await Task.Run(()=> _db.UsersRoles.ToListAsync());
        }

        public async Task<IEnumerable<UsersRoles>> GetAll(Expression<Func<UsersRoles, bool>> where = null)
        {
            return await Task.Run(()=>
            {
                IQueryable<UsersRoles> _roles = _db.UsersRoles;
                if (where != null)
                {
                    _roles = _roles.Where(where);
                }
                return _roles.ToListAsync();
            });
        }

        public async Task<IEnumerable<UsersRoles>> GetByFilter(string q)
        {
            return await Task.Run(()=> _db.UsersRoles.Where(r=>r.RoleTitle.Contains(q) || r.RoleName.Contains(q)).ToListAsync());
        }

        public async Task<UsersRoles> GetById(int roleId)
        {
            return await Task.Run(()=> _db.UsersRoles.Find(roleId));
        }

        public async Task<UsersRoles> GetRoleByName(string roleName)
        {
            return await Task.Run(()=> _db.UsersRoles.SingleOrDefaultAsync(r=>r.RoleName == roleName));
        }

        public async Task<bool> Insert(UsersRoles role)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.UsersRoles.Add(role);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Save()
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Update(UsersRoles role)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.UsersRoles.Update(role);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
