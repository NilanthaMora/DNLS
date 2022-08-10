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
    public class ShipTypeController : Controller
    {
        private readonly DnlDBContext _context;

        public ShipTypeController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: ShipType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShipType.ToListAsync());
        }

        // GET: ShipType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipType = await _context.ShipType
                .FirstOrDefaultAsync(m => m.id == id);
            if (shipType == null)
            {
                return NotFound();
            }

            return View(shipType);
        }

        // GET: ShipType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShipType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,code,description")] ShipType shipType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipType);
        }

        // GET: ShipType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipType = await _context.ShipType.FindAsync(id);
            if (shipType == null)
            {
                return NotFound();
            }
            return View(shipType);
        }

        // POST: ShipType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,code,description")] ShipType shipType)
        {
            if (id != shipType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipTypeExists(shipType.id))
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
            return View(shipType);
        }

        // GET: ShipType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipType = await _context.ShipType
                .FirstOrDefaultAsync(m => m.id == id);
            if (shipType == null)
            {
                return NotFound();
            }

            return View(shipType);
        }

        // POST: ShipType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipType = await _context.ShipType.FindAsync(id);
            _context.ShipType.Remove(shipType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipTypeExists(int id)
        {
            return _context.ShipType.Any(e => e.id == id);
        }
        
        public async Task<IActionResult> ShipType()
        {
            var ships = await _context.shipTypes.ToListAsync();
            ViewData["shipType"] = new SelectList(_context.shipTypes, "description", "description");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetShip(int id, Base Base)
        {
            if (id != Base.id)
            {
                return NotFound();
            }

            try
            {
                var ships = await _context.bases
                    .Include(a => a.ShipType)
                    .Where(a => a.ShipType.description.Equals(Base.description.ToString())).ToListAsync();
                ViewData["shipType"] = Base.description;
                ViewData["ships"] = new SelectList(ships, "description", "description");
                //return View();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipTypeExists(Base.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShipEquipments(int id, Base Base)
        {
            if (id != Base.id)
            {
                return NotFound();
            }

            try
            {
                string shipType = Request.Form["shipType"];
                var allequipments = await _context.equipments
                    .Include(a => a.Base)
                    .Include(a => a.Base.ShipType)
                    .Include(a => a.EquipmentTable)
                    .Include(a => a.Engine)
                    .Include(a => a.Ais)
                    .Include(a => a.Communication)
                    .Include(a => a.Radar)
                    .Include(a => a.Gyro)
                    .Include(a => a.Weapon)
                    .Include(a => a.Sonar)
                    .Include(a => a.Gps)
                    .Include(a => a.Guncom)
                    .Include(a => a.IntegratedHeadingSensor)
                    .Include(a => a.Epirb)
                    .Include(a => a.DVR)
                    .Include(a => a.CCTV)
                    .Include(a => a.EODs)
                    .Include(a => a.SatCompass)
                    .Include(a => a.SatPhone)
                    .Include(a => a.Sart)
                    .Include(a => a.SpeedLog)
                    .Include(a => a.Anemometers)
                    .Include(a => a.XenonSLight)
                    .Include(a => a.Navtex)
                    .Include(a => a.MiniSat)
                    .Include(a => a.ECDI)
                    .Where(b => 
                    b.Base.ShipType.description.ToString().Equals(shipType)
                    && b.Base.description.ToString().Equals(Base.description)
                    )
                    .ToListAsync();
                return View(allequipments);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipTypeExists(Base.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View();
        }

    }
}
