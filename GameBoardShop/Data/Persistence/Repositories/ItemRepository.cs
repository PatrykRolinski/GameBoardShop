using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Models;
using Persistence;
using Persistence.Repositories;
using System.Linq.Expressions;

namespace GameBoardShop.Data.Persistence.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(GameBoardShopContext context) : base(context)
        {

        }
    }
}
