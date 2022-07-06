using Microsoft.AspNetCore.Mvc;

namespace test_case.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bucket()
        {
            return View();
        }
    }
}
