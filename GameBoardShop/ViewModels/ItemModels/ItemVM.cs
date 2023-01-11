using GameBoardShop.Data.Enums;

namespace GameBoardShop.ViewModels.ItemModels
{
    public class ItemVM
    {
        public string? Name { get; set;}
        public string? Description { get; set;}
        public string ? ImageUrl { get; set;}
        public string? ProducerName { get; set; }
        public decimal Price { get; set; }
        public ICollection<string>? GameCategories { get; set; }

    }
}
