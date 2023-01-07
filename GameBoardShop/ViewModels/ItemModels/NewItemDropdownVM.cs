using GameBoardShop.Models;

namespace GameBoardShop.ViewModels.ItemModels;

public class NewItemDropdownVM
{
    public List<Producer> Producers { get; set; }
    public List<GameCategory> GameCategories { get; set; }
}
