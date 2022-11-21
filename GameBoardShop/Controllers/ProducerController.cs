using GameBoardShop.Models;
using GameBoardShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameBoardShop.Controllers
{
    [Route("api/[controller]")]
    public class ProducerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(NewProducerVM newProducerVM)
        {
            return View();
        }

    }
}
