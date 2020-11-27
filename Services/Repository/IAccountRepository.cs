using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Fri2Ends.Identity.DomainClass;
using Fri2Ends.Identity.ViewModels;
using Newtonsoft.Json.Linq;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface IAccountRepository
    {
        Task<AccountResponse> LoginAsync(LoginViewModel login,string ipAddress);
        AccountResponse Login(LoginViewModel login, string ipAddress);
        Task<AccountResponseApi> LoginAsyncApi(LoginViewModel login, string ipAddress); 
        AccountResponseApi LoginApi(LoginViewModel login, string ipAddress);
        Task<AccountResponse> SignUpAsync(SignUpViewModel signUp,string roleNamme = "users",int roleId = 1);
        AccountResponse SignUp(SignUpViewModel signUp, string roleNamme = "users", int roleId = 1);
        Task<bool> HasRole(int userId,string roleName);
        Task<IEnumerable<UsersRoles>> GetRoles(int userId);
        Task<bool> Save();

    }
}
