using Demo_MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Demo_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Demo_MVC.Models.Process;
using System.Data;

namespace Demo_MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------- INDEX -------------------
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persons.ToListAsync());
        }

        // ----------------- CREATE -------------------
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // ------------------- EDIT --------------------
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Persons.FindAsync(id);
            if (person == null) return NotFound();

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            if (id != person.PersonId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Persons.Any(e => e.PersonId == id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        // ------------------- DETAILS --------------------
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Persons.FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null) return NotFound();

            return View(person);
        }

        // ------------------- DELETE --------------------
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Persons.FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null) return NotFound();

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // ------------------- UPLOAD --------------------
        // Không dùng View Upload nữa
        public IActionResult Upload()
        {
            return RedirectToAction("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Vui lòng chọn file Excel!");
                return View("Create");
            }

            var extension = Path.GetExtension(file.FileName);

            if (extension != ".xls" && extension != ".xlsx")
            {
                ModelState.AddModelError("", "File phải là .xls hoặc .xlsx");
                return View("Create");
            }

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Excels");

            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
            var filePath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            DataTable dt = _excelProcess.ExcelToDataTable(filePath);

            foreach (DataRow row in dt.Rows)
            {
                var person = new Person();

                int.TryParse(row[0]?.ToString(), out int personId);
                person.PersonId = personId;

                person.FullName = row[1]?.ToString() ?? "";
                person.Address = row[2]?.ToString() ?? "";

                if (dt.Columns.Count > 3)
                {
                    int.TryParse(row[3]?.ToString(), out int year);
                    person.BirthYear = year;
                }

                _context.Persons.Add(person);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
