using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fri2Ends.Identity.Context;
using Fri2Ends.Identity.DomainClass;
using Fri2Ends.Identity.Services.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class SessionServices : ISessionRepository , IDisposable
    {
        #region --Dependency--

        private readonly IdentityContext _db;
        private readonly IUserRepository _user;

        public SessionServices(IdentityContext db, UserServices user)
        {
            _user = user;
            _db = db;
        }

        #endregion

        #region --Get--

        public async Task<IEnumerable<Sessions>> GetAll()
        {
            return await Task.Run(() => _db.Sessions.ToListAsync());
        }

        public async Task<IEnumerable<Sessions>> GetAll(Expression<Func<Sessions, bool>> @where = null)
        {
            return await Task.Run(() =>
            {
                IQueryable<Sessions> _session = _db.Sessions;
                if (where != null)
                {
                    _session = _session.Where(where);
                }

                return _session.ToListAsync();
            });
        }

        public async Task<Sessions> GetById(int sessionId)
        {
            return await Task.Run(() => _db.Sessions.Find(sessionId));
        }

        public async Task<IEnumerable<Sessions>> GetUserSessions(int userId)
        {
            return await Task.Run(() => _db.Sessions.Where(s => s.UserId == userId).ToListAsync());
        }

        public async Task<Users> GetUserBySession(Sessions session)
        {
            return await Task.Run(() =>
            {
                var sessions = GetById(session.SessionId).Result;
                if (sessions != null)
                {
                    var user = _user.GetUserById(sessions.UserId).Result;
                    if (user != null)
                    {
                        return user;
                    }
                    return null;
                }
                return null;
            });
        }

        #endregion

        #region --Insert Update--

        public async Task<bool> Insert(Sessions session)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.Sessions.Add(session);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Update(Sessions session)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.Sessions.Update(session);
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

        public async Task<bool> Delete(Sessions session)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.Sessions.Remove(session);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Delete(int sessionId)
        {
            return await Task.Run(() => Delete(GetById(sessionId).Result));
        }

        #endregion

        #region --Check--

        public async Task<bool> IsExist(int sessionId)
        {
            return await Task.Run(() => _db.Sessions.Any(s => s.SessionId == sessionId));
        }

        #endregion

        #region --Save Dispose--

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

        public void Dispose()
        {
            _db.Dispose();
        }

        #endregion
    }
}
