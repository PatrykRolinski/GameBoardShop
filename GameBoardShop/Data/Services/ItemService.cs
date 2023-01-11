using GameBoardShop.Data.Contracts.IServices;
using GameBoardShop.Models;
using GameBoardShop.ViewModels.ItemModels;

namespace GameBoardShop.Data.Services
{
    public class ItemService : IItemService
    {
        public IEnumerable<ItemVM> MapToItemVM(IEnumerable<Item> items)
        {
            var itemVMList = new List<ItemVM>();

            foreach(var item in items)
            {
                var itemVM = new ItemVM();

                itemVM.Name = item.Name;
                itemVM.Description = item.Description;
                itemVM.ImageUrl = item.ImageURL;

                if (item.Price is not null && item.Price.Count() > 0)
                {
                   itemVM.Price = item.Price.OrderBy(p => p.DateTime).First().Value;
                }

                if(item.Producer is not null)
                {
                   itemVM.ProducerName = item.Producer.Name;

                }
                
                if(item.GameCategories is not null && item.GameCategories.Count()>0)
                {
                    itemVM.GameCategories = new List<string>();
                    foreach(var gameCategory in item.GameCategories)
                    {
                        itemVM.GameCategories.Add(gameCategory.Name);
                    }
                }
                itemVMList.Add(itemVM);
                
            }

            return itemVMList;
        }
    }
}
