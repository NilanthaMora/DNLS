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
    public class ProcurementController : Controller
    {
        private readonly DnlDBContext _context;

        public ProcurementController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: Procurement
        public async Task<IActionResult> Index()
        {
            return View(await _context.procurements.ToListAsync());
        }

        // GET: Procurement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procurement = await _context.procurements
                .FirstOrDefaultAsync(m => m.id == id);
            if (procurement == null)
            {
                return NotFound();
            }

            return View(procurement);
        }

        // GET: Procurement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procurement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,equipCode,make,model,rlRef,qtyOrdered,qtyApproved,lastPurchasePrice,remarks,userId,cDate")] Procurement procurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procurement);
        }

        // GET: Procurement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procurement = await _context.procurements.FindAsync(id);
            if (procurement == null)
            {
                return NotFound();
            }
            return View(procurement);
        }

        // POST: Procurement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,equipCode,make,model,rlRef,qtyOrdered,qtyApproved,lastPurchasePrice,remarks,userId,cDate")] Procurement procurement)
        {
            if (id != procurement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcurementExists(procurement.id))
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
            return View(procurement);
        }

        // GET: Procurement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procurement = await _context.procurements
                .FirstOrDefaultAsync(m => m.id == id);
            if (procurement == null)
            {
                return NotFound();
            }

            return View(procurement);
        }

        // POST: Procurement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procurement = await _context.procurements.FindAsync(id);
            _context.procurements.Remove(procurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcurementExists(int id)
        {
            return _context.procurements.Any(e => e.id == id);
        }
    }
}
