using Microsoft.AspNetCore.Mvc;

namespace test_case.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Wok()
        {

            return View();
        }
        public IActionResult Sushi()
        {
            return View();
        }
        public IActionResult Rolls()
        {
            return View();
        }
    }
}
