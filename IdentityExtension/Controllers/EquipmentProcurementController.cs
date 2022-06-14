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
    public class EquipmentProcurementController : Controller
    {
        private readonly DnlDBContext _context;

        public EquipmentProcurementController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: EquipmentProcurement
        public async Task<IActionResult> Index()
        {
            try
            {
                var dnlDBContext = _context.equipmentProcurements.Include(e => e.Procurement);
                return View(await dnlDBContext.ToListAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: '{e}'");
            }

            return View(_context.equipmentProcurements);
        }

        // GET: EquipmentProcurement/Details/5
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

        // GET: EquipmentProcurement/Create
        public IActionResult Create()
        {
            ViewData["procuId"] = new SelectList(_context.procurements, "id", "id");
            return View();
        }

        // POST: EquipmentProcurement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,equipCode,make,model,rlRef,qtyOrdered,qtyApproved,lastPurchasePrice,remarks,userId,cDate,item,fileRef,proDistribution,procuId")] EquipProcuView equipProcuView)
        {
            if (ModelState.IsValid)
            {
               // Procurement procu = new Procurement(
               //         equipProcuView.equipCode,
               //         equipProcuView.make,
               //         equipProcuView.model,
               //         equipProcuView.rlRef,
               //         equipProcuView.qtyOrdered,
               //         equipProcuView.qtyApproved,
              //          equipProcuView.lastPurchasePrice,
              //          equipProcuView.remarks,
              //          equipProcuView.userId,
               //         equipProcuView.cDate
               //     );

                //EquipmentProcurement ep = new EquipmentProcurement(
                //    equipProcuView.item,
                //    equipProcuView.fileRef,
                //    equipProcuView.proDistribution,
                //    equipProcuView.id
                //    );
                _context.Add(equipProcuView);
                //_context.Add(ep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ViewData["procuId"] = new SelectList(_context.procurements, "id", "id", equipmentProcurement.procuId);
            // return View(equipmentProcurement);
            return View();
        }

        // GET: EquipmentProcurement/Edit/5
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

        // POST: EquipmentProcurement/Edit/5
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

        // GET: EquipmentProcurement/Delete/5
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

        // POST: EquipmentProcurement/Delete/5
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
