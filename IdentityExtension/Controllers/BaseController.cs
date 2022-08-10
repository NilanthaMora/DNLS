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
    public class BaseController : Controller
    {
        private readonly DnlDBContext _context;

        public BaseController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: Base
        public async Task<IActionResult> Index()
        {
            var dnlDBContext = _context.bases.Include(b => b.Area).Include(s => s.ShipType);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: Base/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @base = await _context.bases
                .Include(a => a.Area)
                .Include(s => s.ShipType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (@base == null)
            {
                return NotFound();
            }

            return View(@base);
        }

        // GET: Base/Create
        public IActionResult Create()
        {
            ViewData["areaId"] = new SelectList(_context.areas, "id", "description");
            ViewData["shipTypeId"] = new SelectList(_context.ShipType, "id", "description");
            return View();
        }

        // POST: Base/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,code,description,remCd,payBase,areaId,baseType,shipTypeId")] Base @base)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@base);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["areaId"] = new SelectList(_context.areas, "id", "description", @base.areaId);
            ViewData["shipTypeId"] = new SelectList(_context.ShipType, "id", "description", @base.shipTypeId);
            return View(@base);
        }

        // GET: Base/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @base = await _context.bases.FindAsync(id);
            if (@base == null)
            {
                return NotFound();
            }
            ViewData["areaId"] = new SelectList(_context.areas, "id", "description", @base.areaId);
            ViewData["shipTypeId"] = new SelectList(_context.ShipType, "id", "description", @base.shipTypeId);
            return View(@base);
        }

        // POST: Base/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,code,description,remCd,payBase,areaId,baseType,shipTypeId")] Base @base)
        {
            if (id != @base.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@base);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseExists(@base.id))
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
            ViewData["areaId"] = new SelectList(_context.areas, "id", "description", @base.areaId);
            ViewData["shipTypeId"] = new SelectList(_context.ShipType, "id", "description", @base.shipTypeId);
            return View(@base);
        }

        // GET: Base/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @base = await _context.bases
                .Include(a => a.Area)
                .Include(s => s.ShipType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (@base == null)
            {
                return NotFound();
            }

            return View(@base);
        }

        // POST: Base/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @base = await _context.bases.FindAsync(id);
            _context.bases.Remove(@base);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseExists(int id)
        {
            return _context.bases.Any(e => e.id == id);
        }
    }
}
