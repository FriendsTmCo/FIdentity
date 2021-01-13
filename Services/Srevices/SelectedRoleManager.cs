using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class SelectedRoleManager : ISelectedRoleManager, ICrudManager<SelectedRoles>, IDisposable
    {
        #region ::Dependency::

        private readonly FIdentityContext _db;

        public SelectedRoleManager(FIdentityContext db)
        {
            _db = db;
        }

        #endregion

        public Task<bool> DeleteAsync(SelectedRoles model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectedRoles>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectedRoles>> GetAllAsync(Expression<Func<SelectedRoles, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<SelectedRoles> GetbyIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(SelectedRoles model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExistAsync(Guid userId, Guid roleId)
        {
            return await Task.Run(async () => await _db.SelectedRoles.AnyAsync(s => s.UserId == userId && s.RoleId == roleId));
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(SelectedRoles model)
        {
            throw new NotImplementedException();
        }
    }
}
