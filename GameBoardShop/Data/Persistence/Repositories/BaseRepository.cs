using GameBoardShop.Data.Base;
using GameBoardShop.Data.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase, new()
    {
        protected readonly GameBoardShopContext _context;

        public BaseRepository(GameBoardShopContext context)
        {
            _context = context;
        }

        public async Task Add(T item)
        {
          await _context.Set<T>().AddAsync(item);
          await _context.SaveChangesAsync();

        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (item is not null) _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GettAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T TItem)
        {
            var entityEntry = _context.Entry<T>(TItem);
            entityEntry.State= EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}