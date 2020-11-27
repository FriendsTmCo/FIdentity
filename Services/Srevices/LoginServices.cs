using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.DomainClass;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class LoginServices : ILoginRepository
    {
        private readonly IdentityContext _db;

        public LoginServices(IdentityContext db)
        {
            _db = db;
        }

        public async Task<bool> Delete(UserLogins login)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.UserLogins.Remove(login);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Delete(int loginId)
        {
            return await Task.Run(() => Delete(GetById(loginId).Result));
        }

        public async Task<IEnumerable<UserLogins>> GetAll()
        {
            return await Task.Run(() => _db.UserLogins.ToListAsync());
        }

        public async Task<IEnumerable<UserLogins>> GetAll(Expression<Func<UserLogins, bool>> where = null)
        {
            return await Task.Run(() =>
            {
                IQueryable<UserLogins> _logins = _db.UserLogins;
                if (where != null)
                {
                    _logins = _logins.Where(where);
                }

                return _logins.ToListAsync();
            });
        }

        public async Task<IEnumerable<UserLogins>> GetallUserLogins(int userId)
        {
            return await Task.Run(() => _db.UserLogins.Where(l => l.UserId == userId).ToListAsync());
        }

        public async Task<UserLogins> GetById(int loginId)
        {
            return await Task.Run(() => _db.UserLogins.Find(loginId));
        }

        public async Task<IEnumerable<UserLogins>> GetByIpAddress(string ipAddress)
        {
            return await Task.Run(() => _db.UserLogins.Where(l => l.DeviceIp == ipAddress).ToListAsync());
        }

        public async Task<bool> Insert(UserLogins login)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.UserLogins.Add(login);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> IsExist(string ipAddress)
        {
            return await Task.Run(() => _db.UserLogins.Any(u => u.DeviceIp == ipAddress));
        }

        public async Task<bool> IsExist(int loginId)
        {
            return await Task.Run(() => _db.UserLogins.Any(u => u.LoginId == loginId));
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

        public async Task<bool> Update(UserLogins login)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.UserLogins.Update(login);
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
