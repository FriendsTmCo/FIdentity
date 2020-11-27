using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fri2Ends.Identity.DomainClass;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface ILoginRepository
    {
        Task<IEnumerable<UserLogins>> GetAll();
        Task<IEnumerable<UserLogins>> GetAll(Expression<Func<UserLogins,bool>> where = null);
        Task<IEnumerable<UserLogins>> GetallUserLogins(int userId);
        Task<UserLogins> GetById(int loginId);
        Task<IEnumerable<UserLogins>> GetByIpAddress(string ipAddress);
        Task<bool> Insert(UserLogins login);
        Task<bool> Update(UserLogins login);
        Task<bool> Delete(UserLogins login);
        Task<bool> Delete(int loginId);
        Task<bool> IsExist(string ipAddress);
        Task<bool> IsExist(int loginId);
        Task<bool> Save();
    }
}
