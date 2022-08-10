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
    public class FuelBillDetailController : Controller
    {
        private readonly DnlDBContext _context;

        public FuelBillDetailController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: FuelBillDetail
        public async Task<IActionResult> Index()
        {
            var dnlDBContext = _context.FuelBillSubDetails.Include(f => f.FuelBillAccount);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: FuelBillDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelBillSubDetail = await _context.FuelBillSubDetails
                .Include(f => f.FuelBillAccount)
                .FirstOrDefaultAsync(m => m.fuelAccId == id);
            if (fuelBillSubDetail == null)
            {
                return NotFound();
            }

            return View(fuelBillSubDetail);
        }

        // GET: FuelBillDetail/Create
        public IActionResult Create()
        {
            ViewData["billType"] = new SelectList(_context.FuelBillAccounts, "billAccId", "billAccId");
            return View();
        }

        // POST: FuelBillDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fuelAccId,billType,year,month,lastMonth,chargePerUnit,totalCharge,sno,fromDate,toDate,createdDate,userId,editDate,editUserId")] FuelBillSubDetail fuelBillSubDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelBillSubDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["billType"] = new SelectList(_context.FuelBillAccounts, "billAccId", "billAccId", fuelBillSubDetail.billType);
            return View(fuelBillSubDetail);
        }

        // GET: FuelBillDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelBillSubDetail = await _context.FuelBillSubDetails.FindAsync(id);
            if (fuelBillSubDetail == null)
            {
                return NotFound();
            }
            ViewData["billType"] = new SelectList(_context.FuelBillAccounts, "billAccId", "billAccId", fuelBillSubDetail.billType);
            return View(fuelBillSubDetail);
        }

        // POST: FuelBillDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("fuelAccId,billType,year,month,lastMonth,chargePerUnit,totalCharge,sno,fromDate,toDate,createdDate,userId,editDate,editUserId")] FuelBillSubDetail fuelBillSubDetail)
        {
            if (id != fuelBillSubDetail.fuelAccId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelBillSubDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelBillSubDetailExists(fuelBillSubDetail.fuelAccId))
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
            ViewData["billType"] = new SelectList(_context.FuelBillAccounts, "billAccId", "billAccId", fuelBillSubDetail.billType);
            return View(fuelBillSubDetail);
        }

        // GET: FuelBillDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelBillSubDetail = await _context.FuelBillSubDetails
                .Include(f => f.FuelBillAccount)
                .FirstOrDefaultAsync(m => m.fuelAccId == id);
            if (fuelBillSubDetail == null)
            {
                return NotFound();
            }

            return View(fuelBillSubDetail);
        }

        // POST: FuelBillDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelBillSubDetail = await _context.FuelBillSubDetails.FindAsync(id);
            _context.FuelBillSubDetails.Remove(fuelBillSubDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelBillSubDetailExists(int id)
        {
            return _context.FuelBillSubDetails.Any(e => e.fuelAccId == id);
        }
    }
}
