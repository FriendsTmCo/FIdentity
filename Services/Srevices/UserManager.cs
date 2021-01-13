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
    public class UserManager : IUserManager, ICrudManager<Users>, IDisposable
    {
        #region ::Dependency::

        private readonly FIdentityContext _db;

        public UserManager(FIdentityContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<Users> CreateUserAsync(SignupViewModel signp)
        {
            return await Task.Run(() =>
            {
                return new Users()
                {
                    ActiveCode = Guid.NewGuid().GetHashCode().ToString().Replace("-", "").Substring(4, 4),
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

        public async Task<bool> DeleteAsync(Users model)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.Users.Remove(model);
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

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await Task.Run(async () => await _db.Users.ToListAsync());
        }

        public async Task<IEnumerable<Users>> GetAllAsync(Expression<Func<Users, bool>> where)
        {
            return await Task.Run(async () => await _db.Users.Where(where).ToListAsync());
        }

        public async Task<Users> GetbyIdAsync(object id)
        {
            return await Task.Run(async () => await _db.Users.FindAsync(id));
        }

        public async Task<IEnumerable<Users>> GetUsersBySearchAsync(string q)
        {
            return await Task.Run(async () => await GetAllAsync(u => u.UserName.Contains(q) ||
            u.Email.Contains(q) ||
            u.PhoneNumber.Contains(q)));
        }

        public async Task<bool> InsertAsync(Users model)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _db.Users.AddAsync(model);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> IsExistAsync(Guid userId)
        {
            return await Task.Run(async () => await _db.Users.AnyAsync(u => u.UserId == userId));
        }

        public async Task<bool> IsExistAsync(string userName)
        {
            return await Task.Run(async () => await _db.Users.AnyAsync(u => u.UserName == userName));
        }

        public async Task<bool> IsExistAsync(Users user)
        {
            return await Task.Run(async () => await _db.Users.AnyAsync(u => u.UserId == user.UserId &&
            u.UserName == user.UserName));
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

        public async Task<bool> UpdateAsync(Users model)
        {
            return await Task.Run(() =>
           {
               try
               {
                   _db.Users.Update(model);
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
