using Microsoft.AspNetCore.Mvc;
using Demo_MVC.Models;

namespace Demo_MVC.Controllers
{
    public class BMIController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BMIModel model)
        {
            if (model.Height > 0)
            {
                model.Result = model.Weight / (model.Height * model.Height);

                if (model.Result < 18.5)
                    model.Category = "Gầy";
                else if (model.Result < 25)
                    model.Category = "Bình thường";
                else if (model.Result < 30)
                    model.Category = "Thừa cân";
                else
                    model.Category = "Béo phì";
            }
            return View(model);
        }
    }
}
