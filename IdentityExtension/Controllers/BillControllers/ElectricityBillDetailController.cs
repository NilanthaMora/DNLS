using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityExtension.Data;
using IdentityExtension.Models.Bill;
using IdentityExtension.Models.Enum;

namespace IdentityExtension.Controllers.BillControllers
{
    public class ElectricityBillDetailController : Controller
    {
        private readonly DnlDBContext _context;

        public ElectricityBillDetailController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: ElectricityBillDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.ElectricityBillDetails.ToListAsync());
        }

        // GET: ElectricityBillDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityBillDetail = await _context.ElectricityBillDetails
                .FirstOrDefaultAsync(m => m.eleAccId == id);
            if (electricityBillDetail == null)
            {
                return NotFound();
            }

            return View(electricityBillDetail);
        }

        // GET: ElectricityBillDetail/Create
        public IActionResult Create()
        {
            ViewData["billType"] = new SelectList(_context.ElectricityBillTypes, "id", "description");
            ViewData["months"] = new SelectList(Enum.GetValues(typeof(Month.MonthsOfYear))
                .Cast<Month.MonthsOfYear>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList(), "Value", "Text");
            return View();
        }

        // POST: ElectricityBillDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("eleAccId,billType,year,month,lastMonth,currentMonth,unit,chargePerUnit,departmentCharge,fixedCharges,monthlyCost,billConfirm,createdDate,userId,editDate,editUserId,billConUserId,billConDate,adfRefer,adfDate")] ElectricityBillDetail electricityBillDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electricityBillDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(electricityBillDetail);
        }

        // GET: ElectricityBillDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityBillDetail = await _context.ElectricityBillDetails.FindAsync(id);
            if (electricityBillDetail == null)
            {
                return NotFound();
            }
            return View(electricityBillDetail);
        }

        // POST: ElectricityBillDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("eleAccId,billType,year,month,lastMonth,currentMonth,unit,chargePerUnit,departmentCharge,fixedCharges,monthlyCost,billConfirm,createdDate,userId,editDate,editUserId,billConUserId,billConDate,adfRefer,adfDate")] ElectricityBillDetail electricityBillDetail)
        {
            if (id != electricityBillDetail.eleAccId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electricityBillDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectricityBillDetailExists(electricityBillDetail.eleAccId))
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
            return View(electricityBillDetail);
        }

        // GET: ElectricityBillDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityBillDetail = await _context.ElectricityBillDetails
                .FirstOrDefaultAsync(m => m.eleAccId == id);
            if (electricityBillDetail == null)
            {
                return NotFound();
            }

            return View(electricityBillDetail);
        }

        // POST: ElectricityBillDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var electricityBillDetail = await _context.ElectricityBillDetails.FindAsync(id);
            _context.ElectricityBillDetails.Remove(electricityBillDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectricityBillDetailExists(int id)
        {
            return _context.ElectricityBillDetails.Any(e => e.eleAccId == id);
        }
    }
}
