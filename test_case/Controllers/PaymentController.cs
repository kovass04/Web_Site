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
        SharedController sharedController;
        public string Messege = "asd";
        public PaymentController(test_caseContext context)
        {
            _context = context;
            sharedController = new SharedController(_context);
        }

        public async Task<IActionResult> Bucket()
        {
            
            ViewBag.totalPrice = sharedController.TotalPrice();
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
/*        [HttpPost]
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
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckAction([Bind("Id,FirstName,LastName,Order,Price,Roles,Email")] Check check)
        {
            
            var toDelete = await _context.Bucket.Select(a => new Bucket { Id = a.Id }).ToListAsync();
            
            if (ModelState.IsValid)
            {
                _context.Add(check);
                // await _context.SaveChangesAsync();
                if (Bucket != null)
                {
                    _context.Bucket.RemoveRange(toDelete);
                    await _context.SaveChangesAsync();
                }
                
                return RedirectToAction(nameof(Bucket));
            }



           
            return RedirectToAction(nameof(Bucket));
        }

        /*[HttpPost]
        public async Task<IActionResult> Gener()
        {
            string generatebarcode = Request.Form["text"];
            GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(generatebarcode, BarcodeWriterEncoding.QRCode).SaveAsJpeg(@"wwwroot\images\qr_codes\QuickStart.jpg");
            return RedirectToAction(nameof(Bucket));
        }*/
        
    }
}
