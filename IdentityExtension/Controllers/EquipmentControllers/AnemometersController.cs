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
    public class AnemometersController : Controller
    {
        private readonly DnlDBContext _context;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnemometersController(ApplicationDbContext applicationDbContext, DnlDBContext context, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        // GET: Anemometers
        [Route("anemometers/{id?}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.menu = id;
            var dnlDBContext = _context.anemometers.Include(e => e.Equipment).Include(a => a.Equipment.Base).Include(a => a.Equipment.Base.ShipType);
            return View(await dnlDBContext.ToListAsync()); 
        }

        [Route("anemometers/edit/{id}")]
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
                .Where(a => a.EquipmentTable.varName == "anemometers").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
                .Where(a => a.EquipmentTable.varName == "anemometers").Select(a => a.Model), "description", "description");

            var anemometers = await _context.anemometers.Include(a => a.Equipment).Where(a => a.id.Equals(id)).FirstOrDefaultAsync();

            if (anemometers == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", anemometers.eqId);
            return View(anemometers);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("anemometers/edit/{id?}")]
        public async Task<IActionResult> Edit(int id, Anemometers anemometers)
        {
            if (id != anemometers.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    anemometers.Equipment.userId = user.ToString();

                    _context.Update(anemometers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnemometersExists(anemometers.id))
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
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", anemometers.eqId);
            return View(anemometers);
        }

        // GET: Anemometers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anemometers = await _context.anemometers
                .Include(a => a.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (anemometers == null)
            {
                return NotFound();
            }

            return View(anemometers);
        }

        // GET: Anemometers/Create
        [Route("anemometers/create")]
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
            .Where(a => a.EquipmentTable.varName == "anemometers").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
            .Where(a => a.EquipmentTable.varName == "anemometers").Select(a => a.Model), "description", "description");
            return View();
        }

        // POST: Anemometers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("anemometers/create")]
        public async Task<IActionResult> Create(Anemometers anemometers)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                anemometers.Equipment.userId = user.Id;
                _context.Add(anemometers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", anemometers.eqId);
            return View(anemometers);
        }

        // GET: anemometers/Update/5
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

            var anemometers = await _context.anemometers.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync(); 
            if (anemometers == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", anemometers.eqTId);
            return View(anemometers);
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
                    var anemometers = await _context.anemometers.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    anemometers.userId = user.ToString();
                    anemometers.remarks = equipment.remarks;
                    anemometers.state = equipment.state;

                    _context.Update(anemometers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnemometersExists(equipment.id))
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

        // GET: anemometers/Add-g47/5
        [Route("anemometers/add-g47/{id}")]
        public async Task<IActionResult> AddG47(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var anemometers = await _context.anemometers.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync(); 
            if (anemometers == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", anemometers.eqTId);
            return View(anemometers); 
        }

        // POST: anemometers/Add-g47/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("anemometers/add-g47/{id}")]
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
                    var anemometersObject = await _context.anemometers.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    anemometersObject.userId = user.ToString();
                    anemometersObject.g47Remarks = equipment.g47Remarks;
                    anemometersObject.g47Date = equipment.g47Date;

                    _context.Update(anemometersObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnemometersExists(equipment.id))
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

        // GET: Anemometers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anemometers = await _context.anemometers
                .Include(a => a.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (anemometers == null)
            {
                return NotFound();
            }

            return View(anemometers);
        }

        // POST: Anemometers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anemometers = await _context.anemometers.FindAsync(id);
            _context.anemometers.Remove(anemometers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnemometersExists(int id)
        {
            return _context.anemometers.Any(e => e.id == id);
        }
    }
}
