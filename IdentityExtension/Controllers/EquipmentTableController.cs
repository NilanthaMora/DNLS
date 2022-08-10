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
    public class EquipmentTableController : Controller
    {
        private readonly DnlDBContext _context;

        public EquipmentTableController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: EquipmentTable
        public async Task<IActionResult> Index()
        {
            try
            {

                return View(await _context.equipment_Tables.ToListAsync());


            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: '{e}'");
            }
            return View();
        }

        // GET: EquipmentTable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentTable = await _context.equipment_Tables
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipmentTable == null)
            {
                return NotFound();
            }

            return View(equipmentTable);
        }

        // GET: EquipmentTable/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipmentTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,equipmentCode,equipment,varName,equipmentSellCode,imageUrl,equipmentGeneralInq")] EquipmentTable equipmentTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipmentTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipmentTable);
        }

        // GET: EquipmentTable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentTable = await _context.equipment_Tables.FindAsync(id);
            if (equipmentTable == null)
            {
                return NotFound();
            }
            return View(equipmentTable);
        }

        // POST: EquipmentTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,equipmentCode,equipment,varName,equipmentSellCode,imageUrl,equipmentGeneralInq")] EquipmentTable equipmentTable)
        {
            if (id != equipmentTable.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipmentTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentTableExists(equipmentTable.id))
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
            return View(equipmentTable);
        }

        // GET: EquipmentTable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentTable = await _context.equipment_Tables
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipmentTable == null)
            {
                return NotFound();
            }

            return View(equipmentTable);
        }

        // POST: EquipmentTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipmentTable = await _context.equipment_Tables.FindAsync(id);
            _context.equipment_Tables.Remove(equipmentTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentTableExists(int id)
        {
            return _context.equipment_Tables.Any(e => e.id == id);
        }
    }
}
