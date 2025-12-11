using Demo_MVC.Models.Process;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
    public class ExcelController : Controller
    {
        private readonly ExcelProcess _excel;

        public ExcelController()
        {
            _excel = new ExcelProcess();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Error = "Vui lòng chọn file Excel!";
                return View();
            }

            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Excels");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = Path.Combine(path, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var data = _excel.ExcelToDataTable(filePath);

            return View("Result", data);
        }
    }
}
