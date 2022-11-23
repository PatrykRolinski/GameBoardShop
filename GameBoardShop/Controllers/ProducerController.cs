using FluentValidation;
using FluentValidation.AspNetCore;
using GameBoardShop.Data.Contracts.IServices;
using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Models;
using GameBoardShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GameBoardShop.Controllers
{
    [Route("api/[controller]")]
    public class ProducerController : Controller
    {
        private readonly IProducerRepository _repository;
        private readonly IProducerService _producerService;
        private IValidator<NewProducerVM> _validator;
        public ProducerController(IProducerRepository repository, IProducerService producerService, IValidator<NewProducerVM> validator)
        {
            _repository = repository;
            _producerService = producerService;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var producersVM= _producerService.MapToProducerVM(await _repository.GettAll());

            return View(producersVM);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(NewProducerVM newProducerVM)
        {
            var validationResult= await _validator.ValidateAsync(newProducerVM);

            if (!validationResult.IsValid)
            {

                validationResult.AddToModelState(this.ModelState);

                // re-render the view when validation failed.
                return View("create", newProducerVM);
            }

            var producer= _producerService.MapToModel(newProducerVM);

            await _repository.Add(producer);

            return RedirectToAction(nameof(Index), "Producer");
        }

    }
}
