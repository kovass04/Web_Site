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
    public class SharedController : Controller
    {
        private readonly test_caseContext _context;

        public SharedController(test_caseContext context)
        {
            _context = context;
        }
        
        public decimal TotalPrice() => _context.Bucket != null ? ViewBag.totalPrice = _context.Bucket.Sum(x => x.Price) : 0;

    }
}
