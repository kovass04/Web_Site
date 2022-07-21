using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test_case.Areas.Identity.Data;
using test_case.Models;

namespace test_case.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly test_caseContext _context;

        public HomeController(ILogger<HomeController> logger, test_caseContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            TotalPrice();
            return View();
        }
        public decimal TotalPrice() => _context.Bucket != null ? ViewBag.totalPrice = _context.Bucket.Sum(x => x.Price) : 0;

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Stock()
        {
            return View();
        }

    }


}