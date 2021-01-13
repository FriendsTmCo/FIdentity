using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class LoginLogsManager : ICrudManager<LoginLogs>
    {
        #region ::Dependency::

        private readonly FIdentityContext _db;

        public LoginLogsManager(FIdentityContext db)
        {
            _db = db;
        }

        #endregion

        public Task<bool> DeleteAsync(LoginLogs model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoginLogs>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoginLogs>> GetAllAsync(Expression<Func<LoginLogs, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<LoginLogs> GetbyIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(LoginLogs model)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _db.LoginLogs.AddAsync(model);
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

        public Task<bool> UpdateAsync(LoginLogs model)
        {
            throw new NotImplementedException();
        }
    }
}
