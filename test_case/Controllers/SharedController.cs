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
        private static bool isPromoConfirmed;
        
        private static int keyInArray;
        public SharedController(test_caseContext context)
        {
            _context = context;
        }
        
        public decimal TotalPrice() {
           
            if(_context.Bucket != null)
            { 
                if(isPromoConfirmed != false && _context.Bucket.Sum(x => x.Price) >= 300)
                {
                    //var action = _context.Promos.Select(p => p.Action).ToList();
                    var number = _context.Promos.Select(p => p.Price).ToList();
                    string nubmerResult = $"{number[keyInArray]}";
                    return ViewBag.totalPrice = _context.Bucket.Sum(x => x.Price) - Convert.ToDecimal(nubmerResult);
                }
                else
                {
                    isPromoConfirmed = false;
                    return ViewBag.totalPrice = _context.Bucket.Sum(x => x.Price);
                }
            }
            
            return 0;
            
        }
        
        public IActionResult EnterPromo(string promo)
        {
            
            if (_context.Bucket.Sum(x => x.Price) >= 300)
            {
                var promos = _context.Promos.Select(p => p.Promo).ToList();
                int counter = 0;
                for (int i = 0; i < promos.ToList().Count; i++)
                {
                    if (promos[i] == promo)
                    {
                        isPromoConfirmed = true;
                        keyInArray = counter;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            else {
               
                return RedirectToAction("Bucket", "Payment");
            }
            

            return RedirectToAction("Bucket", "Payment");
        }
    }
}
