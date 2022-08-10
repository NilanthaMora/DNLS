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
    public class MakeModelController : Controller
    {
        private readonly DnlDBContext _context;

        public MakeModelController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: MakeModel
        public async Task<IActionResult> Index()
        {
            var dnlDBContext = _context.MakeModels.Include(m => m.EquipmentTable).Include(m => m.Make).Include(m => m.Model);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: MakeModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makeModel = await _context.MakeModels
                .Include(m => m.EquipmentTable)
                .Include(m => m.Make)
                .Include(m => m.Model)
                .FirstOrDefaultAsync(m => m.makeId == id);
            if (makeModel == null)
            {
                return NotFound();
            }

            return View(makeModel);
        }

        // GET: MakeModel/Create
        public IActionResult Create()
        {
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables.Where(a => a.varName != "weapon"), "id", "equipment");
            ViewData["makeId"] = new SelectList(_context.Makes, "makeId", "makeId");
            ViewData["modelId"] = new SelectList(_context.Models, "modelId", "modelId");
            return View();
        }

        public IActionResult CreateWeaponSystem()
        {
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables.Where(a => a.varName == "weapon"), "id", "equipment");
            ViewData["makeId"] = new SelectList(_context.Makes, "makeId", "makeId");
            ViewData["modelId"] = new SelectList(_context.Models, "modelId", "modelId");
            return View();
        }

        // POST: MakeModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MakeModel makeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nextId = 0;
                    var ob = _context.Makes.ToList();
                    if (_context.Makes.ToList().Count() == 0) 
                    {
                         nextId = nextId + 1;
                    } else
                    {
                        nextId = _context.Makes.Max(a => a.makeId) + 1;
                    }
                    makeModel.id = nextId;
                    _context.Add(makeModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["eqTId"] = new SelectList(_context.equipment_Tables, "id", "equipment", makeModel.eqTId);
                ViewData["makeId"] = new SelectList(_context.Makes, "makeId", "makeId", makeModel.makeId);
                ViewData["modelId"] = new SelectList(_context.Models, "modelId", "modelId", makeModel.modelId);
            }
            catch(Exception e)
            {

            }
            return View(makeModel);
        }

        // GET: MakeModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makeModel = await _context.MakeModels.Where(a => a.id == id)
                .Include(a => a.EquipmentTable)
                .Include(a => a.Make)
                .Include(a => a.Model).FirstOrDefaultAsync();
            if (makeModel == null)
            {
                return NotFound();
            }
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables, "id", "equipment", makeModel.eqTId);
            ViewData["makeId"] = new SelectList(_context.Makes, "makeId", "makeId", makeModel.makeId);
            ViewData["modelId"] = new SelectList(_context.Models, "modelId", "modelId", makeModel.modelId);
            return View(makeModel);
        }

        // POST: MakeModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MakeModel makeModel)
        {
            if (id != makeModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    makeModel.Make.makeId = makeModel.makeId;
                    makeModel.Model.modelId = makeModel.modelId;
                    _context.Update(makeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakeModelExists(makeModel.makeId))
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
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables, "id", "equipment", makeModel.eqTId);
            ViewData["makeId"] = new SelectList(_context.Makes, "makeId", "makeId", makeModel.makeId);
            ViewData["modelId"] = new SelectList(_context.Models, "modelId", "modelId", makeModel.modelId);
            return View(makeModel);
        }

        // GET: MakeModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makeModel = await _context.MakeModels
                .Include(m => m.EquipmentTable)
                .Include(m => m.Make)
                .Include(m => m.Model)
                .FirstOrDefaultAsync(m => m.id == id); 
            if (makeModel == null)
            {
                return NotFound();
            }

            return View(makeModel);
        }

        // POST: MakeModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var makeModel = await _context.MakeModels.Where(a => a.id == id).FirstOrDefaultAsync();

            _context.MakeModels.Remove(makeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakeModelExists(int id)
        {
            return _context.MakeModels.Any(e => e.makeId == id);
        }
    }
}
