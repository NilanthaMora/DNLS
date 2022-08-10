using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityExtension.Data;
using IdentityExtension.Models;

namespace IdentityExtension.Controllers.BillControllers
{
    public class FuelBillTypeController : Controller
    {
        private readonly DnlDBContext _context;

        public FuelBillTypeController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: FuelBillType
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelBillTypes.ToListAsync());
        }

        // GET: FuelBillType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelBillType = await _context.FuelBillTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (fuelBillType == null)
            {
                return NotFound();
            }

            return View(fuelBillType);
        }

        // GET: FuelBillType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelBillType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,billType,description")] FuelBillType fuelBillType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelBillType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelBillType);
        }

        // GET: FuelBillType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelBillType = await _context.FuelBillTypes.FindAsync(id);
            if (fuelBillType == null)
            {
                return NotFound();
            }
            return View(fuelBillType);
        }

        // POST: FuelBillType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,billType,description")] FuelBillType fuelBillType)
        {
            if (id != fuelBillType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelBillType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelBillTypeExists(fuelBillType.id))
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
            return View(fuelBillType);
        }

        // GET: FuelBillType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelBillType = await _context.FuelBillTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (fuelBillType == null)
            {
                return NotFound();
            }

            return View(fuelBillType);
        }

        // POST: FuelBillType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelBillType = await _context.FuelBillTypes.FindAsync(id);
            _context.FuelBillTypes.Remove(fuelBillType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelBillTypeExists(int id)
        {
            return _context.FuelBillTypes.Any(e => e.id == id);
        }
    }
}
