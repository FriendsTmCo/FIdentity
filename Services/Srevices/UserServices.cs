using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.DomainClass;
using Fri2Ends.Identity.Services.Repository;
using Fri2Ends.Identity.Tools;
using Microsoft.EntityFrameworkCore;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class UserServices : IUserRepository , IDisposable
    {

        #region --Dependency--

        private readonly IdentityContext _db;

        public UserServices(IdentityContext db)
        {
            _db = db;
        }

        #endregion

        #region --Get--

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await Task.Run(() => _db.Users.ToListAsync());
        }

        public async Task<IEnumerable<Users>> GetAllUsers(Expression<Func<Users, bool>> @where = null)
        {
            return await Task.Run(() =>
            {
                IQueryable<Users> _user = _db.Users;
                if (where != null)
                {
                    _user = _user.Where(where);
                }

                return _user.ToListAsync();
            });
        }

        public async Task<IEnumerable<Users>> GetUserBySearch(string q)
        {
            return await Task.Run(() =>
                _db.Users.Where(u => u.Email.Contains(q) || u.UserName.Contains(q) || u.PhoneNumber.Contains(q))
                    .ToListAsync());
        }

        public async Task<Users> GetUserById(int userId)
        {
            return await Task.Run(() => _db.Users.Find(userId));
        }

        public async Task<Users> GetByUserName(string userName)
        {
            return await Task.Run(() => _db.Users.SingleOrDefault(u => u.UserName == userName));
        }

        public async Task<Users> GetByUserEmail(string email)
        {
            return await Task.Run(() => _db.Users.SingleOrDefault(u => u.Email == email));
        }

        public async Task<Users> GetByUserPhone(string phone)
        {
            return await Task.Run(() => _db.Users.SingleOrDefault(u => u.PhoneNumber == phone));
        }

        #endregion

        #region --Insert Update--

        public async Task<bool> Insert(Users user)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    user.Password = await Hasher.GetHashAsync(user, user.Password);
                    await _db.Users.AddAsync(user);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Update(Users user)
        {
            return await Task.Run(() =>
            {
                try
                {
                    user.Password = Hasher.GetHashAsync(user, user.Password).Result;
                    _db.Users.Update(user);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        #endregion

        #region --Delete--

        public async Task<bool> Delete(Users user)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.Users.Remove(user);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Delete(int userId)
        {
            return await Task.Run(async () => await Delete(await GetUserById(userId)));
        }

        #endregion

        #region --Check Users--

        public async Task<bool> CheckPasswordAsync(Users user, string password)
        {
            return await Task.Run(() =>
            {
                Users users = GetUserById(user.UserId).Result;
                if (users != null)
                {
                    string pass = Hasher.GetHash(users, password);
                    if (pass == users.Password)
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            });
        }

        public async Task<bool> IsExist(int userId)
        {
            return await Task.Run(() => _db.Users.Any(u => u.UserId == userId));
        }

        #endregion

        #region --Save Dispose--

        public async Task<bool> Save()
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

        public void Dispose()
        {
            _db.Dispose();
        }

        #endregion
    }
}
