using GameBoardShop.Models;
using GameBoardShop.ViewModels.ItemModels;

namespace GameBoardShop.Data.Contracts.IServices;

public interface IItemService
{
    public IEnumerable<ItemVM> MapToItemVM(IEnumerable<Item> items);
    
}
