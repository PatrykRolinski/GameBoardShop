using GameBoardShop.Data.Base;

namespace GameBoardShop.Data.Contracts.Persistence
{
    public interface IBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GettAll();
        Task<T> GetById(Guid id);
        Task Add(T item);
        Task Update(T TItem);
        Task Delete(Guid id);
    }
}
