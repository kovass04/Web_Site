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
        SharedController sharedController;

        public HomeController(ILogger<HomeController> logger, test_caseContext context)
        {
            _logger = logger;
            _context = context;
            sharedController = new SharedController(_context);
        }
        
        public IActionResult Index()
        {
            
           
            ViewBag.totalPrice = sharedController.TotalPrice();
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