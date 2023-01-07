using GameBoardShop.Data.Enums;
using GameBoardShop.Models;
using System.ComponentModel.DataAnnotations;

namespace GameBoardShop.ViewModels.ItemModels;

public class NewItemVM
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    [Display(Name = "Image Url")]
    public string? ImageURL { get; set; }
    public decimal Price { get; set; }
    public ItemCategory ItemCategory { get; set; }
    public List<int> GameCategoriesId { get; set; }= new List<int>();
    public Guid ProducerId { get; set; }
}
