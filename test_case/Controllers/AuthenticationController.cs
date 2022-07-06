using Microsoft.AspNetCore.Mvc;

namespace test_case.Controllers
{
    public class AuthenticationController : Controller
    {
        Random random = new Random();
        List<string> pics = new List<string>() { "amogus.png", "astolfo.jpg", "ben.jpg", "cat.jpg", "cat_2.jpg",
            "elden.jpg", "jupiter.jpg", "kiryu.jpg", "like.jpg", "megumin.jpg", "shaman.jpg", "yotsugi.jpg"};

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == null || password == null) return null;
            return View();
        }

        public IActionResult Profile(string path)
        {
            string random_pic = pics[random.Next(0, pics.Count)];

            ViewBag.Message = $"~/images/profile_pictures/{random_pic}";
            
            path = $"~/images/profile_pictures/{random_pic}";

            return View();
        }
    }
}
