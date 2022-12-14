using GameBoardShop.Data.Base;
using System.Linq.Expressions;

namespace GameBoardShop.Data.Contracts.Persistence
{
    public interface IBaseRepository<T> where T: class, IEntityBase
    {
        Task<IEnumerable<T>> GettAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] expression);
        Task<T?> GetById(Guid id);
        Task<T?> GetById(Guid id, params Expression<Func<T, object>>[] expression);
        Task Add(T item);
        Task Update(T TItem);
        Task<int> Delete(Guid id);
    }
}
