using Microsoft.AspNetCore.Mvc;

namespace GameBoardShop.Controllers
{
    [Route("api/[controller]")]
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("404")]
        public IActionResult ItemNotFound()
        {
            return View();
        }
    }
}
