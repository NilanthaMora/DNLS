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
    public class IntegratedHeadingSensorController : Controller
    {
        private readonly DnlDBContext _context;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public IntegratedHeadingSensorController(ApplicationDbContext applicationDbContext, DnlDBContext context, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        // GET: IntegratedHeadingSensor
        [Route("integrated-heading-sensor/{id?}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.menu = id;
            var dnlDBContext = _context.integratedHeadingSensors.Include(e => e.Equipment).Include(a => a.Equipment.Base).Include(a => a.Equipment.Base.ShipType);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: IntegratedHeadingSensor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integratedHeadingSensor = await _context.integratedHeadingSensors
                .Include(i => i.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (integratedHeadingSensor == null)
            {
                return NotFound();
            }

            return View(integratedHeadingSensor);
        }

        // GET: IntegratedHeadingSensor/Create
        [Route("integrated-heading-sensor/create")]
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
            .Where(a => a.EquipmentTable.varName == "integrated-heading-sensor").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
            .Where(a => a.EquipmentTable.varName == "integrated-heading-sensor").Select(a => a.Model), "description", "description");
            return View();
        }

        // POST: IntegratedHeadingSensor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("integrated-heading-sensor/create")]
        public async Task<IActionResult> Create(IntegratedHeadingSensor integratedHeadingSensor)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                integratedHeadingSensor.Equipment.userId = user.Id;
                _context.Add(integratedHeadingSensor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", integratedHeadingSensor.eqId);
            return View(integratedHeadingSensor);
        }

        [Route("integrated-heading-sensor/edit/{id}")]
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
                .Where(a => a.EquipmentTable.varName == "integrated-heading-sensor").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
                .Where(a => a.EquipmentTable.varName == "integrated-heading-sensor").Select(a => a.Model), "description", "description");

            var integratedHeadingSensor = await _context.integratedHeadingSensors.Include(a => a.Equipment).Where(a => a.id.Equals(id)).FirstOrDefaultAsync();

            if (integratedHeadingSensor == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", integratedHeadingSensor.eqId);
            return View(integratedHeadingSensor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("integrated-heading-sensor/edit/{id?}")]
        public async Task<IActionResult> Edit(int id, IntegratedHeadingSensor sensor)
        {
            if (id != sensor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    sensor.Equipment.userId = user.ToString();

                    _context.Update(sensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntegratedHeadingSensorExists(sensor.id))
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
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", sensor.eqId);
            return View(sensor);
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

            var sensor = await _context.integratedHeadingSensors.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync();
            if (sensor == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", sensor.eqTId);
            return View(sensor);
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
                    var sensor = await _context.integratedHeadingSensors.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    sensor.userId = user.ToString();
                    sensor.remarks = equipment.remarks;
                    sensor.state = equipment.state;

                    _context.Update(sensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntegratedHeadingSensorExists(equipment.id))
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
        [Route("integrated-heading-sensor/add-g47/{id}")]
        public async Task<IActionResult> AddG47(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sensor = await _context.integratedHeadingSensors.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync();
            if (sensor == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", sensor.eqTId);
            return View(sensor);
        }

        // POST: Ais/Add-g47/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("integrated-heading-sensor/add-g47/{id}")]
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
                    var sensor = await _context.integratedHeadingSensors.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    sensor.userId = user.ToString();
                    sensor.g47Remarks = equipment.g47Remarks;
                    sensor.g47Date = equipment.g47Date;

                    _context.Update(sensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntegratedHeadingSensorExists(equipment.id))
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

        // GET: IntegratedHeadingSensor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integratedHeadingSensor = await _context.integratedHeadingSensors
                .Include(i => i.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (integratedHeadingSensor == null)
            {
                return NotFound();
            }

            return View(integratedHeadingSensor);
        }

        // POST: IntegratedHeadingSensor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var integratedHeadingSensor = await _context.integratedHeadingSensors.FindAsync(id);
            _context.integratedHeadingSensors.Remove(integratedHeadingSensor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntegratedHeadingSensorExists(int id)
        {
            return _context.integratedHeadingSensors.Any(e => e.id == id);
        }
    }
}
