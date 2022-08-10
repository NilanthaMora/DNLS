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
    public class EquipmentProcurementViewController : Controller
    {
        private readonly DnlDBContext _context;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public EquipmentProcurementViewController(ApplicationDbContext applicationDbContext, DnlDBContext context, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;        }

        // GET: EquipmentProcurementView
        public async Task<IActionResult> Index()
        {

            var dnlDBContext = _context.equipmentProcurements.Include(e => e.Procurement);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: EquipmentProcurementView
        public async Task<IActionResult> IndexEdit()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            try
            {
                var userOb = await _applicationDbContext.applicationUsers.
                    FirstOrDefaultAsync(u => u.Id == user.Id);

                ViewBag.role = userOb.UserRole;
            }
            catch (Exception)
            {
                return NotFound();
            }
            
            

            var dnlDBContext = _context.equipmentProcurements.Include(e => e.Procurement);
            return View(await dnlDBContext.ToListAsync());
        }

        // GET: EquipmentProcurementView/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentProcurement = await _context.equipmentProcurements
                .Include(e => e.Procurement)
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipmentProcurement == null)
            {
                return NotFound();
            }

            return View(equipmentProcurement);
        }

        // GET: EquipmentProcurementView/Create
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> eq = _context.equipment_Tables.Select(e => new SelectListItem {
                Value = e.equipmentCode.ToString(),  
                Text = e.equipment
            }).ToList(); 
            //ViewData["Equipment"] = await eq;
            ViewBag.equipments = new SelectList(_context.equipment_Tables, "equipmentCode", "equipment");

            ViewBag.EquipmentList = eq; 

            ViewData["procuId"] = new SelectList(_context.procurements, "id", "id");
            return View();
        }

        // POST: EquipmentProcurementView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,equipCode,make,model,rlRef,qtyOrdered,qtyApproved,lastPurchasePrice,remarks,userId,cDate,item,fileRef,proDistribution,procuId")] EquipProcuView procurement)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.GetUserAsync(HttpContext.User);
                
                Procurement pro = new Procurement()
                {
                    id = procurement.id,
                    equipCode = procurement.equipCode,
                    make = procurement.make,
                    model = procurement.model,
                    rlRef = procurement.rlRef,
                    qtyOrdered = procurement.qtyOrdered,
                    qtyApproved = procurement.qtyApproved,
                    lastPurchasePrice = procurement.lastPurchasePrice,
                    remarks = procurement.remarks,
                    userId = user.Id,
                    cDate = procurement.cDate,
                    EquipmentProcurement = new EquipmentProcurement()
                    {
                        id = procurement.id,
                        item = procurement.item, 
                        fileRef = procurement.fileRef,
                        proDistribution = procurement.proDistribution,
                        procuId = procurement.id
                    }

                };
                _context.Add(pro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procurement);
        }

        // GET: EquipmentProcurementView/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var equipmentProcurementAll = await _context.equipmentProcurements.Where(e => e.id == id).Include(e => e.Procurement).FirstOrDefaultAsync();
            
            
            //var equipmentProcurement = await _context.equipmentProcurements.FindAsync(id);
            if (equipmentProcurementAll == null)
            {
                return NotFound();
            }

            List<SelectListItem> eq = _context.equipment_Tables.Select(e => new SelectListItem
            {
                Value = e.equipmentCode.ToString(),
                Text = e.equipment
            }).ToList();

            ViewBag.EquipmentList = eq;

            EquipProcuView pro = new EquipProcuView()
            {
                id = equipmentProcurementAll.Procurement.id, 
                equipCode = equipmentProcurementAll.Procurement.equipCode,  
                make = equipmentProcurementAll.Procurement.make,
                model = equipmentProcurementAll.Procurement.model,
                rlRef = equipmentProcurementAll.Procurement.rlRef,
                qtyOrdered = equipmentProcurementAll.Procurement.qtyOrdered,
                qtyApproved = equipmentProcurementAll.Procurement.qtyApproved,
                lastPurchasePrice = equipmentProcurementAll.Procurement.lastPurchasePrice,
                remarks = equipmentProcurementAll.Procurement.remarks,
                userId = equipmentProcurementAll.Procurement.userId,
                cDate = equipmentProcurementAll.Procurement.cDate,
                item = equipmentProcurementAll.item,
                fileRef = equipmentProcurementAll.fileRef,
                proDistribution = equipmentProcurementAll.proDistribution
            };
           // ViewData["procuId"] = new SelectList(_context.procurements, "id", "id", equipmentProcurement.procuId);
            return View(pro);
        }

        // POST: EquipmentProcurementView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,equipCode,make,model,rlRef,qtyOrdered,qtyApproved,lastPurchasePrice,remarks,userId,cDate,item,fileRef,proDistribution,procuId")] EquipProcuView procurement)
        {
            if (id != procurement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    Procurement pro = new Procurement()
                    {
                        id = procurement.id,
                        equipCode = procurement.equipCode,
                        make = procurement.make,
                        model = procurement.model,
                        rlRef = procurement.rlRef,
                        qtyOrdered = procurement.qtyOrdered,
                        qtyApproved = procurement.qtyApproved,
                        lastPurchasePrice = procurement.lastPurchasePrice,
                        remarks = procurement.remarks,
                        userId = user.Id,
                        cDate = procurement.cDate,
                        EquipmentProcurement = new EquipmentProcurement()
                        {
                            id = procurement.id,
                            item = procurement.item,
                            fileRef = procurement.fileRef,
                            proDistribution = procurement.proDistribution,
                            procuId = procurement.id
                        }

                    };
                    _context.Update(pro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentProcurementExists(procurement.id))
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
           // ViewData["procuId"] = new SelectList(_context.procurements, "id", "id", equipmentProcurement.procuId);
            return View(procurement);
        }

        // GET: EquipmentProcurementView/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentProcurement = await _context.equipmentProcurements
                .Include(e => e.Procurement)
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipmentProcurement == null)
            {
                return NotFound();
            }

            return View(equipmentProcurement);
        }

        // POST: EquipmentProcurementView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipmentProcurement = await _context.equipmentProcurements.FindAsync(id);
            _context.equipmentProcurements.Remove(equipmentProcurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentProcurementExists(int id)
        {
            return _context.equipmentProcurements.Any(e => e.id == id);
        }
    }
}
