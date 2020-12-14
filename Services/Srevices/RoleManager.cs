using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class RoleManager : IRoleManager, ICrudManager<Roles>, IDisposable
    {
        #region ::Dependency::

        /// <summary>
        /// F Identity Data Base Context
        /// </summary>
        private readonly FIdentityContext _db;

        public RoleManager(FIdentityContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<bool> DeleteAsync(Roles model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.Roles.Remove(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> DeleteAsync(object id)
        {
            return await Task.Run(async () => await DeleteAsync(await GetbyIdAsync(id)));
        }

        public async void Dispose()
        {
            await _db.DisposeAsync();
        }

        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await Task.Run(async () => await _db.Roles.ToListAsync());
        }

        public async Task<IEnumerable<Roles>> GetAllAsync(Expression<Func<Roles, bool>> where)
        {
            return await Task.Run(async () => await _db.Roles.Where(where).ToListAsync());
        }

        public async Task<Roles> GetbyIdAsync(object id)
        {
            return await Task.Run(async () => await _db.Roles.FindAsync(id));
        }

       
        public async Task<IEnumerable<Roles>> GetRolesBySearchAsync(string q)
        {
            return await Task.Run(async () => await GetAllAsync(r => r.RoleTitle.Contains(q) || r.RoleName.Contains(q)));
        }

        public async Task<bool> InsertAsync(Roles model)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _db.Roles.AddAsync(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> SaveAsync()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> UpdateAsync(Roles model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.Roles.Update(model);
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
