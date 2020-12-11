using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface ITokenManager
    {
        Task<IEnumerable<Tokens>> GetAllTokensAsync();
        Task<IEnumerable<Tokens>> GetAllTokensAsync(Expression<Func<Tokens,bool>> where);
        Task<Tokens> GetTokenByIdAsync(int tokenId);
        Task<bool> InsertAsync(Tokens token);
        Task<bool> UpdateAsync(Tokens token);
        Task<bool> DeleteAsync(Tokens token);
        Task<bool> DeleteAsync(int tokenId);
        Task<bool> SaveAsync();
        bool Save();
    }
}
