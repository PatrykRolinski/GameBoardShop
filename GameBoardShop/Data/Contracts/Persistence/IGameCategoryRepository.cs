using GameBoardShop.Models;
using System.Linq.Expressions;

namespace GameBoardShop.Data.Contracts.Persistence
{
    public interface IGameCategoryRepository
    {
        public Task<List<GameCategory>> SearchGameCategories(List<int> categoryIds);
    }
}
