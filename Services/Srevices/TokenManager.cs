using Fri2Ends.Identity.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Srevices
{
    public class TokenManager : ITokenManager
    {
        public Task<bool> DeleteAsync(Tokens token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string tokenValue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int tokenId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tokens>> GetAllTokensAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tokens>> GetAllTokensAsync(Expression<Func<Tokens, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<Tokens> GetTokenByIdAsync(int tokenId)
        {
            throw new NotImplementedException();
        }

        public Task<Tokens> GetTokenByValueAsync(string tokenValue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Tokens token)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Tokens token)
        {
            throw new NotImplementedException();
        }
    }
}
