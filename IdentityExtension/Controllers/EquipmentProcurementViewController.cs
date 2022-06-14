using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityExtension.Data;
using IdentityExtension.Models;

namespace IdentityExtension.Controllers
{
    public class EquipmentProcurementViewController : Controller
    {
        private readonly DnlDBContext _context;

        public EquipmentProcurementViewController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: EquipmentProcurementView
        public async Task<IActionResult> Index()
        {
            var dnlDBContext = _context.equipmentProcurements.Include(e => e.Procurement);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: EquipmentProcurementView/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentProcurement = await _context.equipmentProcurements
                .Include(e => e.Procurement)
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipmentProcurement == null)
            {
                return NotFound();
            }

            return View(equipmentProcurement);
        }

        // GET: EquipmentProcurementView/Create
        public IActionResult Create()
        {
            ViewData["procuId"] = new SelectList(_context.procurements, "id", "id");
            return View();
        }

        // POST: EquipmentProcurementView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,equipCode,make,model,rlRef,qtyOrdered,qtyApproved,lastPurchasePrice,remarks,userId,cDate,item,fileRef,proDistribution,procuId")] EquipProcuView procurement)
        {
            if (ModelState.IsValid)
            {
                Procurement pro = new Procurement()
                {
                    id = procurement.id,
                    equipCode = procurement.equipCode,
                    make = procurement.make,
                    model = procurement.model,
                    rlRef = procurement.rlRef,
                    qtyOrdered = procurement.qtyOrdered,
                    qtyApproved = procurement.qtyApproved,
                    lastPurchasePrice = procurement.lastPurchasePrice,
                    remarks = procurement.remarks,
                    userId = procurement.userId,
                    cDate = procurement.cDate,
                    EquipmentProcurement = new EquipmentProcurement()
                    {
                        id = procurement.id,
                        item = procurement.item, 
                        fileRef = procurement.fileRef,
                        proDistribution = procurement.proDistribution,
                        procuId = procurement.id
                    }

                };
                _context.Add(pro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procurement);
        }

        // GET: EquipmentProcurementView/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentProcurement = await _context.equipmentProcurements.FindAsync(id);
            if (equipmentProcurement == null)
            {
                return NotFound();
            }
            ViewData["procuId"] = new SelectList(_context.procurements, "id", "id", equipmentProcurement.procuId);
            return View(equipmentProcurement);
        }

        // POST: EquipmentProcurementView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,item,fileRef,proDistribution,procuId")] EquipmentProcurement equipmentProcurement)
        {
            if (id != equipmentProcurement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipmentProcurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentProcurementExists(equipmentProcurement.id))
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
            ViewData["procuId"] = new SelectList(_context.procurements, "id", "id", equipmentProcurement.procuId);
            return View(equipmentProcurement);
        }

        // GET: EquipmentProcurementView/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentProcurement = await _context.equipmentProcurements
                .Include(e => e.Procurement)
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipmentProcurement == null)
            {
                return NotFound();
            }

            return View(equipmentProcurement);
        }

        // POST: EquipmentProcurementView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipmentProcurement = await _context.equipmentProcurements.FindAsync(id);
            _context.equipmentProcurements.Remove(equipmentProcurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentProcurementExists(int id)
        {
            return _context.equipmentProcurements.Any(e => e.id == id);
        }
    }
}
