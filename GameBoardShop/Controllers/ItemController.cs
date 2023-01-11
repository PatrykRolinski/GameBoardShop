using FluentValidation;
using FluentValidation.AspNetCore;
using GameBoardShop.Data.Contracts.IServices;
using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Data.Enums;
using GameBoardShop.Data.Validators.ItemValidators;
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
        private readonly IValidator<NewItemVM> _validator;
        private readonly IItemService _itemService;

        public ItemController(IItemRepository itemRepository, IGameCategoryRepository gameCategoryRepository, IValidator<NewItemVM> validator, IItemService itemService)
        {
            _itemRepository = itemRepository;
            _gameCategoryRepository = gameCategoryRepository;
            _validator = validator;
            _itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            var itemList= await _itemRepository.GetAll(i=> i!.Price, i=> i!.Producer, i=> i!.GameCategories);
            var itemVMList = _itemService.MapToItemVM(itemList);
            return View(itemVMList);
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
            var validationResult= await _validator.ValidateAsync(newItemVM);

            if(!validationResult.IsValid) 
            {
                validationResult.AddToModelState(this.ModelState);

                var dropdownItems = await _itemRepository.GetDropdownItems();
                ViewBag.Producers = new SelectList(dropdownItems.Producers, "Id", "Name");
                ViewBag.GameCategories = new SelectList(dropdownItems.GameCategories, "Id", "Name");

                // re-render the view when validation failed.
                return View("create", newItemVM);
            }
            var item = new Item() { Name = newItemVM.Name!, CreatedAt=DateTime.UtcNow };
            
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
