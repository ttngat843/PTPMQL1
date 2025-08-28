using Microsoft.AspNetCore.Mvc;
using Demo_MVC.Models;

namespace Demo_MVC.Controllers
{
    public class ToanController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ToanModel model)
        {
            switch (model.Operation)
            {
                case "Add":
                    model.Result = model.Number1 + model.Number2;
                    break;
                case "Subtract":
                    model.Result = model.Number1 - model.Number2;
                    break;
                case "Multiply":
                    model.Result = model.Number1 * model.Number2;
                    break;
                case "Divide":
                    model.Result = model.Number2 != 0 ? model.Number1 / model.Number2 : double.NaN;
                    break;
            }

            return View(model);
        }
    }
}
