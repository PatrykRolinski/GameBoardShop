using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Models;
using GameBoardShop.ViewModels.ItemModels;
using Microsoft.EntityFrameworkCore;
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

        public async Task<NewItemDropdownVM> GetDropdownItems()
        {
            var newItemDropdownVM = new NewItemDropdownVM()
            {
                Producers = await _context.Producers.ToListAsync(),
                GameCategories = await _context.GameCategories.ToListAsync()
            };

            return newItemDropdownVM;
        }

    }
}
