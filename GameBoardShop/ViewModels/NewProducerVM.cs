﻿using System.ComponentModel.DataAnnotations;

namespace GameBoardShop.ViewModels
{
    public class NewProducerVM
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Image Url")]
        public string? ImageURL { get; set; }
    }
}
