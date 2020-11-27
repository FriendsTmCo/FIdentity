using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fri2Ends.Identity.DomainClass;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllUsers();
        Task<IEnumerable<Users>> GetAllUsers(Expression<Func<Users, bool>> where = null);
        Task<IEnumerable<Users>> GetUserBySearch(string q);
        Task<Users> GetUserById(int userId);
        Task<Users> GetByUserName(string userName);
        Task<Users> GetByUserEmail(string email);
        Task<Users> GetByUserPhone(string phone);
        Task<bool> CheckPasswordAsync(Users user, string password);
        Task<bool> Insert(Users user);
        Task<bool> Update(Users user);
        Task<bool> Delete(Users user);
        Task<bool> Delete(int userId);
        Task<bool> IsExist(int userId);
        Task<bool> Save();

    }
}
