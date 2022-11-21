using Microsoft.AspNetCore.Mvc;

namespace GameBoardShop.Controllers
{
    [Route("api/[controller]")]
    public class ProducersController : Controller
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

    }
}
