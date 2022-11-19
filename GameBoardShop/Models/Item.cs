﻿using GameBoardShop.Data.Base;
using GameBoardShop.Data.Enums;

namespace GameBoardShop.Models
{
    public class Item : EntityBase
    {
        public required string Name { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public ICollection<GameCategory>? GameCategories { get; set; }

    }
}
