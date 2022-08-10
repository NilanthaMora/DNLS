using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityExtension.Data;
using IdentityExtension.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityExtension.Controllers.BillControllers
{
    public class FuelBillAccountController : Controller
    {
        private readonly DnlDBContext _context;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public FuelBillAccountController(ApplicationDbContext applicationDbContext, DnlDBContext context, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        // GET: FuelBillAccount
        public async Task<IActionResult> Index()
        {
            var dnlDBContext = _context.FuelBillAccounts.Include(f => f.Area).Include(f => f.FuelBillType);

            try
            {
                IDictionary<int, string> baseNew = new Dictionary<int, string>();
                IDictionary<int, string> subNew = new Dictionary<int, string>();

                foreach (FuelBillAccount i in dnlDBContext)
                {
                    baseNew.Add(i.billAccId, i.baseId != 0 ? _context.bases.Find(i.baseId).description.ToString() : null);
                    subNew.Add(i.billAccId, i.subUnitId != 0 ? _context.subUnits.Find(i.subUnitId).description.ToString() : null);
                };

                ViewBag.baseNew = baseNew;
                ViewBag.subNew = subNew;
            }
            catch (Exception e)
            {
                throw e;
            }

            return View(await dnlDBContext.ToListAsync());
        }

        // GET: FuelBillAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelBillAccount = await _context.FuelBillAccounts
                .Include(f => f.Area)
                .Include(f => f.FuelBillType)
                .FirstOrDefaultAsync(m => m.billAccId == id);
            if (fuelBillAccount == null)
            {
                return NotFound();
            }

            return View(fuelBillAccount);
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

        // GET: FuelBillAccount/Create
        public IActionResult Create()
        {
            ViewBag.AreaId = _context.areas.Select(c => new SelectListItem { Value = c.id.ToString(), Text = c.description }).ToList();
            ViewData["subunitId"] = new SelectList(_context.subUnits, "id", "description");
            ViewData["billType"] = new SelectList(_context.FuelBillTypes, "id", "description");
            return View();
        }

        // POST: FuelBillAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FuelBillAccount fuelBillAccount)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                fuelBillAccount.userId = user.Id;
                _context.Add(fuelBillAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["areaId"] = new SelectList(_context.areas, "id", "id", fuelBillAccount.areaId);
            ViewData["billType"] = new SelectList(_context.FuelBillTypes, "id", "id", fuelBillAccount.billType);
            return View(fuelBillAccount);
        }

        // GET: FuelBillAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelBillAccount = await _context.FuelBillAccounts.FindAsync(id);
            if (fuelBillAccount == null)
            {
                return NotFound();
            }
            ViewData["areaId"] = new SelectList(_context.areas, "id", "description", fuelBillAccount.areaId);
            ViewData["baseId"] = new SelectList(_context.bases.Include(a => a.Area)
                .Where(a => a.Area.id.ToString().Equals(fuelBillAccount.areaId.ToString())), "id", "description");
            ViewData["subId"] = new SelectList(_context.subUnits.Include(a => a.Base).Include(a => a.Base.Area)
                .Where(a => a.Base.Area.id.ToString().Equals(fuelBillAccount.areaId.ToString())), "id", "description"); 
            ViewData["billType"] = new SelectList(_context.FuelBillTypes, "id", "description", fuelBillAccount.billType);
            return View(fuelBillAccount);
        }

        // POST: FuelBillAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FuelBillAccount fuelBillAccount)
        {
            if (id != fuelBillAccount.billAccId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    fuelBillAccount.userId = user.ToString();

                    _context.Update(fuelBillAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelBillAccountExists(fuelBillAccount.billAccId))
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
            ViewData["areaId"] = new SelectList(_context.areas, "id", "description", fuelBillAccount.areaId);
            ViewData["billType"] = new SelectList(_context.FuelBillTypes, "id", "description", fuelBillAccount.billType);
            return View(fuelBillAccount);
        }

        // GET: FuelBillAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelBillAccount = await _context.FuelBillAccounts
                .Include(f => f.Area)
                .Include(f => f.FuelBillType)
                .FirstOrDefaultAsync(m => m.billAccId == id);
            if (fuelBillAccount == null)
            {
                return NotFound();
            }

            return View(fuelBillAccount);
        }

        // POST: FuelBillAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelBillAccount = await _context.FuelBillAccounts.FindAsync(id);
            _context.FuelBillAccounts.Remove(fuelBillAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelBillAccountExists(int id)
        {
            return _context.FuelBillAccounts.Any(e => e.billAccId == id);
        }
    }
}
