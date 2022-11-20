using GameBoardShop.Data.Base;
using GameBoardShop.Data.Contracts.Persistence;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase, new()
    {
        public Task Add(T item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GettAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(T TItem)
        {
            throw new NotImplementedException();
        }
    }
}