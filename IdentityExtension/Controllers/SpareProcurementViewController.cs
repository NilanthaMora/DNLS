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
using Microsoft.AspNetCore.Authorization;

namespace IdentityExtension.Controllers
{
    [Authorize]
    public class SpareProcurementViewController : Controller
    {
        private readonly DnlDBContext _context;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SpareProcurementViewController(ApplicationDbContext applicationDbContext, DnlDBContext context, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        // GET: SpareProcurement
        public async Task<IActionResult> Index()
        {
            var dnlDBContext = _context.spareProcurements.Include(s => s.Procurement);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: SpareProcurementView
        public async Task<IActionResult> IndexEdit()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            try
            {
                var userOb = await _applicationDbContext.applicationUsers.
                FirstOrDefaultAsync(u => u.Id == user.Id);

                ViewBag.role = userOb.UserRole;
            }
            catch(Exception)
            {
                return NotFound();
            }
                


            var dnlDBContext = _context.spareProcurements.Include(e => e.Procurement);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: SpareProcurement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spareProcurement = await _context.spareProcurements
                .Include(s => s.Procurement)
                .FirstOrDefaultAsync(m => m.id == id);
            if (spareProcurement == null)
            {
                return NotFound();
            }

            return View(spareProcurement);
        }

        // GET: SpareProcurement/Create
        public IActionResult Create()
        {

            List<SelectListItem> eq = _context.equipment_Tables.Select(e => new SelectListItem
            {
                Value = e.equipmentCode.ToString(),
                Text = e.equipment
            }).ToList();
            //ViewData["Equipment"] = await eq;
            ViewBag.equipments = new SelectList(_context.equipment_Tables, "equipmentCode", "equipment"); ;

            ViewBag.EquipmentList = eq;

            ViewData["procuId"] = new SelectList(_context.procurements, "id", "id");
            return View();
        }

        // POST: SpareProcurement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,equipCode,make,model,rlRef,qtyOrdered,qtyApproved,lastPurchasePrice,remarks,userId,cDate,partNo,sbRef,currentStock,firstRate,secondRate,thirdRate,forthRate,procuId")] SpareProcuView spareProcurement)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                Procurement spare = new Procurement()
                {
                    id = spareProcurement.id,
                    equipCode = spareProcurement.equipCode,
                    make = spareProcurement.make,
                    model = spareProcurement.model,
                    rlRef = spareProcurement.rlRef,
                    qtyOrdered = spareProcurement.qtyOrdered,
                    qtyApproved = spareProcurement.qtyApproved,
                    lastPurchasePrice = spareProcurement.lastPurchasePrice,
                    remarks = spareProcurement.remarks,
                    userId = user.Id,
                    cDate = spareProcurement.cDate,
                    SpareProcurement = new SpareProcurement()
                    {
                        id = spareProcurement.id,
                        partNo = spareProcurement.partNo,
                        sbRef = spareProcurement.sbRef,
                        currentStock = spareProcurement.currentStock,
                        firstRate = spareProcurement.firstRate,
                        secondRate = spareProcurement.secondRate,
                        thirdRate = spareProcurement.thirdRate,
                        forthRate = spareProcurement.forthRate,
                        procuId = spareProcurement.id
                    }

                };

                _context.Add(spare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["procuId"] = new SelectList(_context.procurements, "id", "id", spareProcurement.procuId);
            return View(spareProcurement);
        }

        // GET: SpareProcurement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var spareProcurementAll = await _context.spareProcurements.Where(e => e.id == id).Include(e => e.Procurement).FirstOrDefaultAsync();
            if (spareProcurementAll == null)
            {
                return NotFound();
            }

            List<SelectListItem> eq = _context.equipment_Tables.Select(e => new SelectListItem
            {
                Value = e.equipmentCode.ToString(),
                Text = e.equipment
            }).ToList();

            ViewBag.EquipmentList = eq;

            SpareProcuView spare = new SpareProcuView()
            {
                id = spareProcurementAll.Procurement.id,
                equipCode = spareProcurementAll.Procurement.equipCode,
                make = spareProcurementAll.Procurement.make,
                model = spareProcurementAll.Procurement.model,
                rlRef = spareProcurementAll.Procurement.rlRef,
                qtyOrdered = spareProcurementAll.Procurement.qtyOrdered,
                qtyApproved = spareProcurementAll.Procurement.qtyApproved,
                lastPurchasePrice = spareProcurementAll.Procurement.lastPurchasePrice,
                remarks = spareProcurementAll.Procurement.remarks,
                userId = spareProcurementAll.Procurement.userId,
                cDate = spareProcurementAll.Procurement.cDate,
                partNo = spareProcurementAll.partNo,
                sbRef = spareProcurementAll.sbRef,
                currentStock = spareProcurementAll.currentStock,
                firstRate = spareProcurementAll.firstRate,
                secondRate = spareProcurementAll.secondRate,
                thirdRate = spareProcurementAll.thirdRate,
                forthRate = spareProcurementAll.forthRate,
                procuId = spareProcurementAll.id 
            };

         //   ViewData["procuId"] = new SelectList(_context.procurements, "id", "id", spareProcurementAll.procuId);
            return View(spare);
        }

        // POST: SpareProcurement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,equipCode,make,model,rlRef,qtyOrdered,qtyApproved,lastPurchasePrice,remarks,userId,cDate,partNo,sbRef,currentStock,firstRate,secondRate,thirdRate,forthRate,procuId")] SpareProcuView spareProcurement)
        {
            if (id != spareProcurement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    Procurement spare = new Procurement()
                    {
                        id = spareProcurement.id,
                        equipCode = spareProcurement.equipCode,
                        make = spareProcurement.make,
                        model = spareProcurement.model,
                        rlRef = spareProcurement.rlRef,
                        qtyOrdered = spareProcurement.qtyOrdered,
                        qtyApproved = spareProcurement.qtyApproved,
                        lastPurchasePrice = spareProcurement.lastPurchasePrice,
                        remarks = spareProcurement.remarks,
                        userId = user.Id,
                        cDate = spareProcurement.cDate,
                        SpareProcurement = new SpareProcurement()
                        {
                            id = spareProcurement.id,
                            partNo = spareProcurement.partNo,
                            sbRef = spareProcurement.sbRef,
                            currentStock = spareProcurement.currentStock,
                            firstRate = spareProcurement.firstRate,
                            secondRate = spareProcurement.secondRate,
                            thirdRate = spareProcurement.thirdRate,
                            forthRate = spareProcurement.forthRate,
                            procuId = spareProcurement.id
                        }

                    };

                    _context.Update(spare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpareProcurementExists(spareProcurement.id))
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
           // ViewData["procuId"] = new SelectList(_context.procurements, "id", "id", spareProcurement.procuId);
            return View(spareProcurement);
        }

        // GET: SpareProcurement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spareProcurement = await _context.spareProcurements
                .Include(s => s.Procurement)
                .FirstOrDefaultAsync(m => m.id == id);
            if (spareProcurement == null)
            {
                return NotFound();
            }

            return View(spareProcurement);
        }

        // POST: SpareProcurement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spareProcurement = await _context.spareProcurements.FindAsync(id);
            _context.spareProcurements.Remove(spareProcurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpareProcurementExists(int id)
        {
            return _context.spareProcurements.Any(e => e.id == id);
        }
    }
}
