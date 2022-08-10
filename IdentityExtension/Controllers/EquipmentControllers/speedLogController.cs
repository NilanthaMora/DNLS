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
using IdentityExtension.Models.Enum;
using Microsoft.AspNetCore.Authorization;

namespace IdentityExtension.Controllers.EquipmentControllers
{
    [Authorize]
    public class speedLogController : Controller
    {
        private readonly DnlDBContext _context;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public speedLogController(ApplicationDbContext applicationDbContext, DnlDBContext context, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        // GET: speedLog
        [Route("speed-log/{id?}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.menu = id;
            var dnlDBContext = _context.speedLogs.Include(e => e.Equipment).Include(a => a.Equipment.Base).Include(a => a.Equipment.Base.ShipType);

            return View(await dnlDBContext.ToListAsync());
        }

        // GET: speedLog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speedLog = await _context.speedLogs
                .Include(s => s.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (speedLog == null)
            {
                return NotFound();
            }

            return View(speedLog);
        }

        // GET: speedLog/Create
        [Route("speed-log/create")]
        public IActionResult Create()
        {
            ViewData["equipStatus"] = new SelectList(Enum.GetValues(typeof(EquipmentEnum.EqStatus)).Cast<EquipmentEnum.EqStatus>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList(), "Value", "Text");
            ViewData["equipId"] = new SelectList(_context.equipments, "id", "srNo");
            ViewData["eqBase"] = new SelectList(_context.bases, "id", "description");
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables, "id", "equipment");
            ViewData["make"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Make)
           .Where(a => a.EquipmentTable.varName == "speed-log").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
            .Where(a => a.EquipmentTable.varName == "speed-log").Select(a => a.Model), "description", "description");
            return View();
        }

        // POST: speedLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("speed-log/create")]
        public async Task<IActionResult> Create(speedLog speedLog)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                speedLog.Equipment.userId = user.Id;
                _context.Add(speedLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", speedLog.eqId);
            return View(speedLog);
        }

        [Route("speed-log/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // set status enum
            ViewData["equipStatus"] = new SelectList(Enum.GetValues(typeof(EquipmentEnum.EqStatus)).Cast<EquipmentEnum.EqStatus>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList(), "Value", "Text");

            ViewData["equipId"] = new SelectList(_context.equipments, "id", "srNo");
            ViewData["eqBase"] = new SelectList(_context.bases, "id", "description");
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables, "id", "equipment");
            ViewData["make"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Make)
                .Where(a => a.EquipmentTable.varName == "speed-log").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
                .Where(a => a.EquipmentTable.varName == "speed-log").Select(a => a.Model), "description", "description");

            var speedLog = await _context.speedLogs.Include(a => a.Equipment).Where(a => a.id.Equals(id)).FirstOrDefaultAsync();

            if (speedLog == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", speedLog.eqId);
            return View(speedLog);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("speed-log/edit/{id?}")]
        public async Task<IActionResult> Edit(int id, speedLog speedLog)
        {
            if (id != speedLog.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    speedLog.Equipment.userId = user.ToString();

                    _context.Update(speedLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!speedLogExists(speedLog.id))
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
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", speedLog.eqId);
            return View(speedLog);
        }

        // GET: Ais/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // set status enum
            ViewData["equipStatus"] = new SelectList(Enum.GetValues(typeof(EquipmentEnum.EqStatus)).Cast<EquipmentEnum.EqStatus>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList(), "Value", "Text");

            var speedLog = await _context.speedLogs.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync();
            if (speedLog == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", speedLog.eqTId);
            return View(speedLog);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Models.Equipment equipment)
        {
            if (id != equipment.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var speedLog = await _context.speedLogs.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    speedLog.userId = user.ToString();
                    speedLog.remarks = equipment.remarks;
                    speedLog.state = equipment.state;

                    _context.Update(speedLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!speedLogExists(equipment.id))
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
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", equipment.eqTId);
            return View(equipment);
        }

        // GET: Ais/Add-g47/5
        [Route("speed-log/add-g47/{id}")]
        public async Task<IActionResult> AddG47(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var speedLog = await _context.speedLogs.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync();
            if (speedLog == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", speedLog.eqTId);
            return View(speedLog);
        }

        // POST: Ais/Add-g47/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("speed-log/add-g47/{id}")]
        public async Task<IActionResult> AddG47(int id, Models.Equipment equipment)
        {
            if (id != equipment.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var speedLog = await _context.speedLogs.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    speedLog.userId = user.ToString();
                    speedLog.g47Remarks = equipment.g47Remarks;
                    speedLog.g47Date = equipment.g47Date;

                    _context.Update(speedLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!speedLogExists(equipment.id))
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
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", equipment.eqTId);
            return View(equipment);
        }

        // GET: speedLog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speedLog = await _context.speedLogs
                .Include(s => s.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (speedLog == null)
            {
                return NotFound();
            }

            return View(speedLog);
        }

        // POST: speedLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speedLog = await _context.speedLogs.FindAsync(id);
            _context.speedLogs.Remove(speedLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool speedLogExists(int id)
        {
            return _context.speedLogs.Any(e => e.id == id);
        }
    }
}
