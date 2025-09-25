using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo_MVC.Data;
using Demo_MVC.Models.Process;

namespace Demo_MVC.Controllers
{
    public class GenCodeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenCodeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GenCode
        public async Task<IActionResult> Index()
        {
            return View(await _context.GenCodes.ToListAsync());
        }

        // GET: GenCode/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genCode = await _context.GenCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genCode == null)
            {
                return NotFound();
            }

            return View(genCode);
        }

        // GET: GenCode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenCode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description")] GenCode genCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genCode);
        }

        // GET: GenCode/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genCode = await _context.GenCodes.FindAsync(id);
            if (genCode == null)
            {
                return NotFound();
            }
            return View(genCode);
        }

        // POST: GenCode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Description")] GenCode genCode)
        {
            if (id != genCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenCodeExists(genCode.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genCode);
        }

        // GET: GenCode/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genCode = await _context.GenCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genCode == null)
            {
                return NotFound();
            }

            return View(genCode);
        }

        // POST: GenCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genCode = await _context.GenCodes.FindAsync(id);
            if (genCode != null)
            {
                _context.GenCodes.Remove(genCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenCodeExists(int id)
        {
            return _context.GenCodes.Any(e => e.Id == id);
        }
    }
}
