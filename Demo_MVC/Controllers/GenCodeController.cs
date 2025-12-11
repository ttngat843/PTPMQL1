using Demo_MVC.Data;
using Demo_MVC.Models.Process;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
    public class GenCodeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenCodeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.GenCodes.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GenCode model)
        {
            if (ModelState.IsValid)
            {
                _context.GenCodes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var item = _context.GenCodes.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(GenCode model)
        {
            if (ModelState.IsValid)
            {
                _context.GenCodes.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var item = _context.GenCodes.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.GenCodes.Find(id);
            if (item == null) return NotFound();

            _context.GenCodes.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
