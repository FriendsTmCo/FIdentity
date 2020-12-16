using Fri2Ends.Identity.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class UserManager : IUserManager, ICrudManager<Users> , IDisposable
    {
        public Task<bool> DeleteAsync(Users model)
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

        public Task<IEnumerable<Users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllAsync(Expression<Func<Users, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetbyIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetUsersBySearchAsync(string q)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Users model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Users model)
        {
            throw new NotImplementedException();
        }
    }
}
