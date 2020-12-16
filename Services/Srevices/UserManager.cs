using Fri2Ends.Identity.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class UserManager : IUserManager, ICrudManager<Users>, IDisposable
    {
        public async Task<Users> CreateUserAsync(SignupViewModel signp)
        {
            return await Task.Run(() =>
            {
                return new Users()
                {
                    ActiveCode = Guid.NewGuid().GetHashCode().ToString().Replace("-","").Substring(4,4),
                    ActiveDate = DateTime.Now,
                    Email = signp.Email,
                    IsConfirm = false,
                    Password = signp.Password.CreateSHA256(),
                    PhoneNumber = signp.PhoneNumber,
                    UserName = signp.UserName,
                    UserId = Guid.NewGuid()
                };
            });
        }

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
