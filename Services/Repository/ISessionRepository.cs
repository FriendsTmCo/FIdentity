using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fri2Ends.Identity.DomainClass;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Sessions>> GetAll();
        Task<IEnumerable<Sessions>> GetAll(Expression<Func<Sessions, bool>> where = null);
        Task<Sessions> GetById(int sessionId);
        Task<IEnumerable<Sessions>> GetUserSessions(int userId);
        Task<Users> GetUserBySession(Sessions session);
        Task<bool> Insert(Sessions session);
        Task<bool> Update(Sessions session);
        Task<bool> Delete(Sessions session);
        Task<bool> Delete(int sessionId);
        Task<bool> IsExist(int sessionId);
        Task<bool> Save();
    }
}
