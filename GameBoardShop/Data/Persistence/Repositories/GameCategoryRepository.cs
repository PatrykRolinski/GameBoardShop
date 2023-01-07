using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace GameBoardShop.Data.Persistence.Repositories
{
    public class GameCategoryRepository : IGameCategoryRepository
    {
        protected readonly GameBoardShopContext _context;

        public GameCategoryRepository(GameBoardShopContext context)
        {
            _context = context;
        }
        public async Task<List<GameCategory>> SearchGameCategories(List<int> categoryIds)
        {
            var listOfGameCategories=await _context.GameCategories.Where(gc=> categoryIds.Contains(gc.Id)).ToListAsync();
            return listOfGameCategories;
        }
    }
}
