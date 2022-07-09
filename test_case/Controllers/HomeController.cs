using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test_case.Data;
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
            decimal totalAmount = 0;
            if (_context.Bucket != null)
            {
                totalAmount = _context.Bucket.Sum(x => x.Price);
                ViewBag.totalPrice = totalAmount;
            }
            else ViewBag.totalPrice = totalAmount;
            return View();
        }

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