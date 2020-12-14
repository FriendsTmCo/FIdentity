using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface IRoleManager
    {
        Task<IEnumerable<Roles>> GetRolesBySearchAsync(string q);
    }
}
