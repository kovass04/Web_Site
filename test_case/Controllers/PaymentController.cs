using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test_case.Areas.Identity.Data;
using test_case.Models;
using IronBarCode;


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
            ViewBag.text = "/images/qr_codes/QuickStart.jpg";

            TotalPrice();
            return _context.Bucket != null ?
                        View(await _context.Bucket.ToListAsync()) :
                        Problem("Entity set 'test_caseContext.Test'  is null.");
        }
        public decimal TotalPrice() => _context.Bucket != null ? ViewBag.totalPrice = _context.Bucket.Sum(x => x.Price) : 0;
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
        [HttpPost]
        public async Task<IActionResult> DeleteAll()
        {
            if (_context.Bucket == null)
            {
                return RedirectToAction(nameof(Bucket));
            }

            var toDelete = await _context.Bucket.Select(a => new Bucket { Id = a.Id }).ToListAsync();

            if (Bucket != null)
            {
                _context.Bucket.RemoveRange(toDelete);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Bucket));
        }
        [HttpPost]
        public async Task<IActionResult> Gener()
        {
            string generatebarcode = Request.Form["text"];
            GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(generatebarcode, BarcodeWriterEncoding.QRCode).SaveAsJpeg(@"wwwroot\images\qr_codes\QuickStart.jpg");
            return RedirectToAction(nameof(Bucket));
        }
    }
}
