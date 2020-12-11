using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface IUserManager
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<IEnumerable<Users>> GetAllUsersAsync(Expression<Func<Users,bool>> where);
        Task<IEnumerable<Users>> GetUsersBySearchAsync(string q);
        Task<Users> GetUserByIdAsync(int userId);
        Task<bool> InsertAsync(Users user);
        Task<bool> UpdateAsync(Users user);
        Task<bool> DeleteAsync(Users user);
        Task<bool> DeleteAsync(int userId);
        Task<bool> SaveAsync();
        bool Save();
    }
}
