using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class BaseRepository<TModel> : BaseRepository<TModel, int>, IBaseRepository<TModel>
        where TModel : BaseItem
    {
        public BaseRepository(LibraryContext context) : base(context)
        {
        }
    }
    
    public class BaseRepository<TModel, TIdentifier> : IBaseRepository<TModel, TIdentifier>
        where TModel : BaseItem<TIdentifier>
    {
        private readonly LibraryContext _context;
        
        protected DbSet<TModel> Entities { get; }

        public BaseRepository(LibraryContext context)
        {
            _context = context;
            Entities = context.Set<TModel>();
        }
        
        public IEnumerable<TModel> GetAll()
        {
            return Entities;
        }

        public TModel Get(TIdentifier id)
        {
            return GetAll().FirstOrDefault(x => Equals(x.Id, id));
        }

        public async Task CreateAsync(TModel entity)
        {
            Entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TModel entity)
        {
            var record = Get(entity.Id);
            
            if (record == null) return;

            _context.Entry(record).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TModel entity)
        {
            Entities.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}