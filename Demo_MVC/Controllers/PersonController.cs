using Demo_MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person/Index
        public IActionResult Index()
        {
            ViewBag.Message = "Dữ liệu từ controller gửi về view sử dụng ViewBag";
            return View();
        }

        // POST: Person/Index
        [HttpPost]
        public IActionResult Index(Person ps)
        {
            // Khi submit, hiển thị dữ liệu nhập vào
            ViewBag.Message = ps.FullName + " - " + ps.BirthYear;

            // Trả model về view để giữ lại giá trị đã nhập
            return View(ps);
        }
    }
}
