using GameBoardShop.Models;
using GameBoardShop.ViewModels.ItemModels;

namespace GameBoardShop.Data.Contracts.Persistence
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        public Task<NewItemDropdownVM> GetDropdownItems();
    }
}
