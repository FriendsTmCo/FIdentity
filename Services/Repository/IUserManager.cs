using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface IUserManager
    {
        Task<IEnumerable<Users>> GetUsersBySearchAsync(string q);
        Task<bool> IsExistAsync(int userId);
        Task<bool> IsExistAsync(string userName);
        Task<bool> IsExistAsync(Users user);
        Task<Users> CreateUserAsync(SignupViewModel signp);
    }
}
