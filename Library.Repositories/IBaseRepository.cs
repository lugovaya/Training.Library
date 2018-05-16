using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Models;

namespace Library.Repositories
{
    public interface IBaseRepository<TModel, in TIdentifier>
        where TModel : BaseItem<TIdentifier>
    {
        IEnumerable<TModel> GetAll();

        TModel Get(TIdentifier id);

        Task CreateAsync(TModel entity);

        Task UpdateAsync(TModel entity);

        Task DeleteAsync(TModel entity);
    }

    public interface IBaseRepository<TModel> : IBaseRepository<TModel, int> 
        where TModel : BaseItem
    {
    }
}