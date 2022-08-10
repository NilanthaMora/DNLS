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
    public class SatPhoneController : Controller
    {
        private readonly DnlDBContext _context;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SatPhoneController(ApplicationDbContext applicationDbContext, DnlDBContext context, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        // GET: SatPhone
        [Route("sat-phone/{id?}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.menu = id;
            var dnlDBContext = _context.satPhones.Include(e => e.Equipment).Include(a => a.Equipment.Base).Include(a => a.Equipment.Base.ShipType);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: SatPhone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satPhone = await _context.satPhones
                .Include(s => s.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (satPhone == null)
            {
                return NotFound();
            }

            return View(satPhone);
        }

        // GET: SatPhone/Create
        [Route("sat-phone/create")]
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
           .Where(a => a.EquipmentTable.varName == "sat-phone").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
            .Where(a => a.EquipmentTable.varName == "sat-phone").Select(a => a.Model), "description", "description");
            return View();
        }

        // POST: SatPhone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("sat-phone/create")]
        public async Task<IActionResult> Create(SatPhone satPhone)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                satPhone.Equipment.userId = user.Id;
                _context.Add(satPhone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", satPhone.eqId);
            return View(satPhone);
        }

        [Route("sat-phone/edit/{id}")]
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
                .Where(a => a.EquipmentTable.varName == "sat-phone").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
                .Where(a => a.EquipmentTable.varName == "sat-phone").Select(a => a.Model), "description", "description");

            var satPhone = await _context.satPhones.Include(a => a.Equipment).Where(a => a.id.Equals(id)).FirstOrDefaultAsync();

            if (satPhone == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", satPhone.eqId);
            return View(satPhone);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("sat-phone/edit/{id?}")]
        public async Task<IActionResult> Edit(int id, SatPhone satPhone)
        {
            if (id != satPhone.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    satPhone.Equipment.userId = user.ToString();

                    _context.Update(satPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SatPhoneExists(satPhone.id))
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
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", satPhone.eqId);
            return View(satPhone);
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

            var satPhone = await _context.satPhones.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync();
            if (satPhone == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", satPhone.eqTId);
            return View(satPhone);
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
                    var satPhone = await _context.satPhones.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    satPhone.userId = user.ToString();
                    satPhone.remarks = equipment.remarks;
                    satPhone.state = equipment.state;

                    _context.Update(satPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SatPhoneExists(equipment.id))
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
        [Route("sat-phone/add-g47/{id}")]
        public async Task<IActionResult> AddG47(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var satPhone = await _context.satPhones.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync();
            if (satPhone == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", satPhone.eqTId);
            return View(satPhone);
        }

        // POST: Ais/Add-g47/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("sat-phone/add-g47/{id}")]
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
                    var satPhone = await _context.satPhones.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    satPhone.userId = user.ToString();
                    satPhone.g47Remarks = equipment.g47Remarks;
                    satPhone.g47Date = equipment.g47Date;

                    _context.Update(satPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SatPhoneExists(equipment.id))
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

        // GET: SatPhone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satPhone = await _context.satPhones
                .Include(s => s.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (satPhone == null)
            {
                return NotFound();
            }

            return View(satPhone);
        }

        // POST: SatPhone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var satPhone = await _context.satPhones.FindAsync(id);
            _context.satPhones.Remove(satPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SatPhoneExists(int id)
        {
            return _context.satPhones.Any(e => e.id == id);
        }
    }
}
