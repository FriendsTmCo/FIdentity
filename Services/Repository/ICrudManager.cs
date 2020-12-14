using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Repository
{
    public interface ICrudManager<Model>
    {
        Task<IEnumerable<Model>> GetAllAsync();
        Task<IEnumerable<Model>> GetAllAsync(Expression<Func<Model,bool>> where);
        Task<Model> GetbyIdAsync(object id);
        Task<bool> InsertAsync(Model model);
        Task<bool> UpdateAsync(Model model);
        Task<bool> DeleteAsync(Model model);
        Task<bool> DeleteAsync(object id);
        Task<bool> SaveAsync();
    }
}
