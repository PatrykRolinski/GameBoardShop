using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Data.Enums;
using GameBoardShop.Models;
using GameBoardShop.ViewModels.ItemModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameBoardShop.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IGameCategoryRepository _gameCategoryRepository;

        public ItemController(IItemRepository itemRepository, IGameCategoryRepository gameCategoryRepository)
        {
            _itemRepository = itemRepository;
            _gameCategoryRepository = gameCategoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var dropdownItems=await _itemRepository.GetDropdownItems();
            ViewBag.Producers = new SelectList(dropdownItems.Producers, "Id", "Name");
            ViewBag.GameCategories=new SelectList(dropdownItems.GameCategories, "Id", "Name");
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(NewItemVM newItemVM)
        {
            var item = new Item() { Name = newItemVM.Name, CreatedAt=DateTime.UtcNow };
            
            item.Description = newItemVM.Description;
            item.ImageURL = newItemVM.ImageURL;
            item.ProducerId= newItemVM.ProducerId;
            item.ItemCategory= newItemVM.ItemCategory;
            item.Price= new List<Price>() { new Price() {Value = newItemVM.Price } };
            item.GameCategories= await _gameCategoryRepository.SearchGameCategories(newItemVM.GameCategoriesId);
            await _itemRepository.Add(item);
          
            return RedirectToAction(nameof(Index));
        }
    }
}
