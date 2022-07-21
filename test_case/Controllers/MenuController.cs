using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test_case.Areas.Identity.Data;
using test_case.Models;
using test_case.Interfaces;



namespace test_case.Controllers
{
    public class MenuController : Controller
    {

        private readonly test_caseContext _context;
        readonly IBufferedFileUploadService _bufferedFileUploadService;

        public MenuController(test_caseContext context, IBufferedFileUploadService bufferedFileUploadService)
        {
            _context = context;
            _bufferedFileUploadService = bufferedFileUploadService;
        }
        public IActionResult Index()
        {

            return View();
        }
        public decimal TotalPrice() => _context.Bucket != null ? ViewBag.totalPrice = _context.Bucket.Sum(x => x.Price) : 0;
        public async Task<IActionResult> Wok()
        {
            TotalPrice();
            return _context.Wok != null ?
                        View(await _context.Wok.ToListAsync()) :
                        Problem("Entity set 'TaiFoodContext.Wok'  is null.");
        }
        public async Task<IActionResult> Sushi()
        {
            TotalPrice();
            return _context.Sushi != null ?
                        View(await _context.Sushi.ToListAsync()) :
                        Problem("Entity set 'TaiFoodContext.Sushi'  is null.");
        }
        public async Task<IActionResult> Rolls()
        {
            TotalPrice();
            return _context.Roll != null ?
                        View(await _context.Roll.ToListAsync()) :
                        Problem("Entity set 'TaiFoodContext.Rolls'  is null.");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(IFormFile file, [Bind("Id,Name,Price,Description,ImagePath")] Wok wok)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bufferedFileUploadService.UploadFile(file);
                }
                catch (Exception ex)
                {
                    return RedirectToAction(nameof(Wok));
                }

                wok.ImagePath = "/images/" + file.FileName;
                _context.Add(wok);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Wok));
            }
            return View(wok);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add2([Bind("Id,Name,Price,Description,ImagePath")] Roll roll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Rolls));
            }
            return View(roll);
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
