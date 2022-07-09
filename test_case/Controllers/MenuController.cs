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
    public class MenuController : Controller
    {
        private readonly test_caseContext _context;

        public MenuController(test_caseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> Wok()
        {
            return _context.Wok != null ?
                        View(await _context.Wok.ToListAsync()) :
                        Problem("Entity set 'TaiFoodContext.Wok'  is null.");
        }
        public async Task<IActionResult> Sushi()
        {
            return _context.Sushi != null ?
                        View(await _context.Sushi.ToListAsync()) :
                        Problem("Entity set 'TaiFoodContext.Sushi'  is null.");
        }
        public async Task<IActionResult> Rolls()
        {
            return _context.Roll != null ?
                        View(await _context.Roll.ToListAsync()) :
                        Problem("Entity set 'TaiFoodContext.Rolls'  is null.");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rolls([Bind("Id,Name,Price,Description,ImagePath")] Bucket bucket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bucket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Rolls));
            }
            return View(bucket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sushi([Bind("Id,Name,Price,Description,ImagePath")] Bucket bucket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bucket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Sushi));
            }
            return View(bucket);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Wok([Bind("Id,Name,Price,Description,ImagePath")] Bucket bucket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bucket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Wok));
            }
            return View(bucket);
        }
    }
}
