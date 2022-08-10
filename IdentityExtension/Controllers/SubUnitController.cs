using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityExtension.Data;
using IdentityExtension.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityExtension.Controllers
{
    [Authorize]
    public class SubUnitController : Controller
    {
        private readonly DnlDBContext _context;

        public SubUnitController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: SubUnit
        public async Task<IActionResult> Index()
        {
            var dnlDBContext = _context.subUnits.Include(s => s.Base);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: SubUnit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subUnit = await _context.subUnits
                .Include(s => s.Base)
                .FirstOrDefaultAsync(m => m.id == id);
            if (subUnit == null)
            {
                return NotFound();
            }

            return View(subUnit);
        }

        // GET: SubUnit/Create
        public IActionResult Create()
        {
            ViewData["baseId"] = new SelectList(_context.bases, "id", "description");
            return View();
        }

        // POST: SubUnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,subUnitCode,description,baseId,type")] SubUnit subUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["baseId"] = new SelectList(_context.bases, "id", "description", subUnit.baseId);
            return View(subUnit);
        }

        // GET: SubUnit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subUnit = await _context.subUnits.FindAsync(id);
            if (subUnit == null)
            {
                return NotFound();
            }
            ViewData["baseId"] = new SelectList(_context.bases, "id", "description", subUnit.baseId);
            return View(subUnit);
        }

        // POST: SubUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,subUnitCode,description,baseId,type")] SubUnit subUnit)
        {
            if (id != subUnit.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubUnitExists(subUnit.id))
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
            ViewData["baseId"] = new SelectList(_context.bases, "id", "description", subUnit.baseId);
            return View(subUnit);
        }

        // GET: SubUnit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subUnit = await _context.subUnits
                .Include(s => s.Base)
                .FirstOrDefaultAsync(m => m.id == id);
            if (subUnit == null)
            {
                return NotFound();
            }

            return View(subUnit);
        }

        // POST: SubUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subUnit = await _context.subUnits.FindAsync(id);
            _context.subUnits.Remove(subUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubUnitExists(int id)
        {
            return _context.subUnits.Any(e => e.id == id);
        }
    }
}
