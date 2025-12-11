using Demo_MVC.Models;
namespace Demo_MVC.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    public class TuoiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }

        [HttpPost]
        public IActionResult Index(Tuoi ps)
        {
            ViewBag.Message = " " + ps.FullName + " " + ps.Age;
            return View();
        }


    }
}