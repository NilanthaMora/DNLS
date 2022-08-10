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
    public class ElectricityAccountBillController : Controller
    {
        private readonly DnlDBContext _context;

        public ElectricityAccountBillController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: ElectricityAccountBill
        public async Task<IActionResult> Index()
        {
            var dnlDBContext = _context.ElectricityAccountBills.Include(e => e.Area).Include(e => e.ElectricityBillType);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: ElectricityAccountBill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityAccountBill = await _context.ElectricityAccountBills
                .Include(e => e.Area)
                .Include(e => e.ElectricityBillType)
                .FirstOrDefaultAsync(m => m.billAccId == id);
            if (electricityAccountBill == null)
            {
                return NotFound();
            }

            return View(electricityAccountBill);
        }

        public IActionResult GetArea() 
        {
            ViewBag.AreaId = _context.areas.Select(c => new SelectListItem { Value = c.id.ToString(), Text = c.description }).ToList();

            return View();
        }
        public IActionResult GetBase(int areaId) 
        {
            var Base_List = _context.bases.Where(s => s.Area.id == areaId).Select(c => new { Id = c.id, Name = c.description }).ToList();
            return Json(Base_List);
        }

        public IActionResult GetSubUnit(int baseId)
        {
            var SubUnit_List = _context.subUnits.Where(s => s.Base.id == baseId).Select(c => new { Id = c.id, Name = c.description }).ToList();
            return Json(SubUnit_List);
        }

        // GET: ElectricityAccountBill/Create
        public IActionResult Create()
        {
            // ViewData["areaId"] = new SelectList(_context.areas, "id", "description");
            // ViewData["baseId"] = new SelectList(_context.bases, "id", "description");
            ViewBag.AreaId = _context.areas.Select(c => new SelectListItem { Value = c.id.ToString(), Text = c.description }).ToList();
            ViewData["subunitId"] = new SelectList(_context.subUnits, "id", "description");
            ViewData["billType"] = new SelectList(_context.ElectricityBillTypes, "id", "description");
            return View();
        }

        // POST: ElectricityAccountBill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("billAccId,billType,areaId,baseId,subUnitId,accountNumber,capacity,active,createdDate,userId")] ElectricityAccountBill electricityAccountBill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electricityAccountBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["areaId"] = new SelectList(_context.areas, "id", "id", electricityAccountBill.areaId);
            ViewData["billType"] = new SelectList(_context.ElectricityBillTypes, "id", "id", electricityAccountBill.billType);
            return View(electricityAccountBill);
        }

        // GET: ElectricityAccountBill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityAccountBill = await _context.ElectricityAccountBills.FindAsync(id);
            if (electricityAccountBill == null)
            {
                return NotFound();
            }
            ViewData["areaId"] = new SelectList(_context.areas, "id", "id", electricityAccountBill.areaId);
            ViewData["billType"] = new SelectList(_context.ElectricityBillTypes, "id", "id", electricityAccountBill.billType);
            return View(electricityAccountBill);
        }

        // POST: ElectricityAccountBill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("billAccId,billType,areaId,baseId,subUnitId,accountNumber,capacity,active,createdDate,userId")] ElectricityAccountBill electricityAccountBill)
        {
            if (id != electricityAccountBill.billAccId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electricityAccountBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectricityAccountBillExists(electricityAccountBill.billAccId))
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
            ViewData["areaId"] = new SelectList(_context.areas, "id", "id", electricityAccountBill.areaId);
            ViewData["billType"] = new SelectList(_context.ElectricityBillTypes, "id", "id", electricityAccountBill.billType);
            return View(electricityAccountBill);
        }

        // GET: ElectricityAccountBill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityAccountBill = await _context.ElectricityAccountBills
                .Include(e => e.Area)
                .Include(e => e.ElectricityBillType)
                .FirstOrDefaultAsync(m => m.billAccId == id);
            if (electricityAccountBill == null)
            {
                return NotFound();
            }

            return View(electricityAccountBill);
        }

        // POST: ElectricityAccountBill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var electricityAccountBill = await _context.ElectricityAccountBills.FindAsync(id);
            _context.ElectricityAccountBills.Remove(electricityAccountBill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectricityAccountBillExists(int id)
        {
            return _context.ElectricityAccountBills.Any(e => e.billAccId == id);
        }
    }
}
