using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityExtension.Data;
using IdentityExtension.Models.Bill;

namespace IdentityExtension.Controllers.BillControllers
{
    public class ElectricityBillTypeController : Controller
    {
        private readonly DnlDBContext _context;

        public ElectricityBillTypeController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: ElectricityBillType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ElectricityBillTypes.ToListAsync());
        }

        // GET: ElectricityBillType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityBillType = await _context.ElectricityBillTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (electricityBillType == null)
            {
                return NotFound();
            }

            return View(electricityBillType);
        }

        // GET: ElectricityBillType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ElectricityBillType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,billType,description")] ElectricityBillType electricityBillType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electricityBillType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(electricityBillType);
        }

        // GET: ElectricityBillType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityBillType = await _context.ElectricityBillTypes.FindAsync(id);
            if (electricityBillType == null)
            {
                return NotFound();
            }
            return View(electricityBillType);
        }

        // POST: ElectricityBillType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,billType,description")] ElectricityBillType electricityBillType)
        {
            if (id != electricityBillType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electricityBillType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectricityBillTypeExists(electricityBillType.id))
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
            return View(electricityBillType);
        }

        // GET: ElectricityBillType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityBillType = await _context.ElectricityBillTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (electricityBillType == null)
            {
                return NotFound();
            }

            return View(electricityBillType);
        }

        // POST: ElectricityBillType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var electricityBillType = await _context.ElectricityBillTypes.FindAsync(id);
            _context.ElectricityBillTypes.Remove(electricityBillType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectricityBillTypeExists(int id)
        {
            return _context.ElectricityBillTypes.Any(e => e.id == id);
        }
    }
}
