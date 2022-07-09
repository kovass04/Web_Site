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
    public class PaymentController : Controller
    {
        private readonly test_caseContext _context;

        public PaymentController(test_caseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Bucket()
        {
            return _context.Bucket != null ?
                        View(await _context.Bucket.ToListAsync()) :
                        Problem("Entity set 'test_caseContext.Test'  is null.");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Bucket == null)
            {
                return Problem("Entity set 'test_caseContext.Test'  is null.");
            }
            var bucket = await _context.Bucket.FindAsync(id);
            if (bucket != null)
            {
                _context.Bucket.Remove(bucket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Bucket));
        }


       /* public decimal Total()
        {
            decimal totalAmount = 0;
            if (_context.Bucket != null)
            {
                totalAmount = _context.Bucket.Sum(x => x.Price);
            }
            return totalAmount;
        } */
    }
}
