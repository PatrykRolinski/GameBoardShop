﻿using GameBoardShop.Data.Base;
using GameBoardShop.Data.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] expression)
        {
            var query = _context.Set<T>().AsQueryable();
            var result = expression.Aggregate(query, (current, next) => current.Include(next));
            return await query.ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T?> GetById(Guid id, params Expression<Func<T, object>>[] expression)
        {
            var query= _context.Set<T>().AsQueryable().Where(x=> x.Id==id);
            var result= expression.Aggregate(query, (current, next) => current.Include(next));
            return await query.FirstOrDefaultAsync();
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