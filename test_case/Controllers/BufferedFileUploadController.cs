using Microsoft.AspNetCore.Mvc;
using test_case.Services;
using test_case.Interfaces;

namespace test_case.Controllers
{
    public class BufferedFileUploadController : Controller
    {
        readonly IBufferedFileUploadService _bufferedFileUploadService;
        public BufferedFileUploadController(IBufferedFileUploadService bufferedFileUploadService)
        {
            _bufferedFileUploadService = bufferedFileUploadService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(IFormFile file)
        {
            try
            {
                if (await _bufferedFileUploadService.UploadFile(file))
                {
                    ViewBag.Message = "File Upload Successful";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed";
                }
            }
            catch (Exception ex)
            {
                //Log ex
                ViewBag.Message = "File Upload Failed";
            }
            return View();
        }
        
    }
}
