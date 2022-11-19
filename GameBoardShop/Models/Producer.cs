using GameBoardShop.Data.Base;

namespace GameBoardShop.Models
{
    public class Producer : EntityBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public IEnumerable<Item>? Items { get; set; }
    }
}
