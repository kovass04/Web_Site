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
        SharedController sharedController;

        public MenuController(test_caseContext context, IBufferedFileUploadService bufferedFileUploadService)
        {
            _context = context;
            _bufferedFileUploadService = bufferedFileUploadService;
            sharedController = new SharedController(_context);
        }
        public IActionResult Index()
        {

            return View();
        }
        public decimal TotalPrice() => _context.Bucket != null ? ViewBag.totalPrice = _context.Bucket.Sum(x => x.Price) : 0;

        public IList<test_case.Models.Menu> Menu { get; set; }
        public async Task<IActionResult> Wok()
        {
            ViewBag.totalPrice = sharedController.TotalPrice();
            var check = await (Task.Run(() => _context.Menu));
            check.ToList();
            var check2 = await (Task.Run(() => check.ToList()));
            string wok = "WOK";
            return _context.Menu != null ?
                View(Menu = check2.Where(u => u.Type == wok).ToList()) :
                Problem("Entity set 'TaiFoodContext.Wok'  is null.");
        }
        public async Task<IActionResult> Sushi()
        {
            ViewBag.totalPrice = sharedController.TotalPrice();
            var check = await (Task.Run(() => _context.Menu));
            check.ToList();
            var check2 = await (Task.Run(() => check.ToList()));
            string sushi = "SUSHI";
            return _context.Menu != null ?
                View(Menu = check2.Where(u => u.Type == sushi).ToList()) :
                Problem("Entity set 'TaiFoodContext.Wok'  is null.");
        }
        public async Task<IActionResult> Rolls()
        {
            ViewBag.totalPrice = sharedController.TotalPrice();
            var check = await (Task.Run(() => _context.Menu));
            check.ToList();
            var check2 = await (Task.Run(() => check.ToList()));
            string rolls = "ROLLS";
            return _context.Menu != null ?
                View(Menu = check2.Where(u => u.Type == rolls).ToList()) :
                Problem("Entity set 'TaiFoodContext.Wok'  is null.");

        }
/*        [HttpPost]
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
        }*/

        public async Task<IActionResult> Delete(int id,string type)
        {
            if (_context.Menu == null)
            {
                return Problem("Entity set 'test_caseContext.Test'  is null.");
            }
            var bucket = await _context.Menu.FindAsync(id);
            if (bucket != null)
            {
                _context.Menu.Remove(bucket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(($"{type}"));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(IFormFile file, [Bind("Id,Name,Type,Price,Description,ImagePath")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bufferedFileUploadService.UploadFile(file);
                }
                catch (Exception ex)
                {
                    return RedirectToAction(menu.Type);
                }
                menu.ImagePath = "/images/" + file.FileName;
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(menu.Type);
            }
            return View(menu);
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
