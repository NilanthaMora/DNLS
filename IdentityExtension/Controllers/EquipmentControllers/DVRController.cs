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
    public class DVRController : Controller
    {
        private readonly DnlDBContext _context;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DVRController(ApplicationDbContext applicationDbContext, DnlDBContext context, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        // GET: DVR
        [Route("dvr/{id?}")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.menu = id;
            var dnlDBContext = _context.dVRs.Include(e => e.Equipment).Include(a => a.Equipment.Base).Include(a => a.Equipment.Base.ShipType);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: DVR/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVR = await _context.dVRs
                .Include(d => d.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (dVR == null)
            {
                return NotFound();
            }

            return View(dVR);
        }

        // GET: DVR/Create
        [Route("dvr/create")]
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
            .Where(a => a.EquipmentTable.varName == "dvr").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
            .Where(a => a.EquipmentTable.varName == "dvr").Select(a => a.Model), "description", "description");
            return View();
        }

        // POST: DVR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("dvr/create")]
        public async Task<IActionResult> Create(DVR dVR)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                dVR.Equipment.userId = user.Id;
                _context.Add(dVR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", dVR.eqId);
            return View(dVR);
        }

        [Route("dvr/edit/{id}")]
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
                .Where(a => a.EquipmentTable.varName == "dvr").Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
                .Where(a => a.EquipmentTable.varName == "dvr").Select(a => a.Model), "description", "description");

            var dvr = await _context.dVRs.Include(a => a.Equipment).Where(a => a.id.Equals(id)).FirstOrDefaultAsync();

            if (dvr == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", dvr.eqId);
            return View(dvr);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("dvr/edit/{id?}")]
        public async Task<IActionResult> Edit(int id, DVR dVR)
        {
            if (id != dVR.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    dVR.Equipment.userId = user.ToString();

                    _context.Update(dVR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVRExists(dVR.id))
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
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", dVR.eqId);
            return View(dVR); 
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

            var dVR = await _context.dVRs.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync();
            if (dVR == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", dVR.eqTId);
            return View(dVR);
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
                    var dVR = await _context.dVRs.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    dVR.userId = user.ToString();
                    dVR.remarks = equipment.remarks;
                    dVR.state = equipment.state;

                    _context.Update(dVR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVRExists(equipment.id))
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
        [Route("dvr/add-g47/{id}")]
        public async Task<IActionResult> AddG47(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dVR = await _context.dVRs.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                .Select(a => a.Equipment).FirstOrDefaultAsync();
            if (dVR == null)
            {
                return NotFound();
            }
            ViewData["eqId"] = new SelectList(_context.equipments, "id", "srNo", dVR.eqTId);
            return View(dVR);
        }

        // POST: Ais/Add-g47/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("dvr/add-g47/{id}")]
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
                    var dvrObject = await _context.dVRs.Include(a => a.Equipment).Where(a => a.id.Equals(id))
                        .Select(a => a.Equipment).FirstOrDefaultAsync();

                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    dvrObject.userId = user.ToString();
                    dvrObject.g47Remarks = equipment.g47Remarks;
                    dvrObject.g47Date = equipment.g47Date;

                    _context.Update(dvrObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVRExists(equipment.id))
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

        // GET: DVR/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVR = await _context.dVRs
                .Include(d => d.Equipment)
                .FirstOrDefaultAsync(m => m.id == id);
            if (dVR == null)
            {
                return NotFound();
            }

            return View(dVR);
        }

        // POST: DVR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dVR = await _context.dVRs.FindAsync(id);
            _context.dVRs.Remove(dVR);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DVRExists(int id)
        {
            return _context.dVRs.Any(e => e.id == id);
        }
    }
}
