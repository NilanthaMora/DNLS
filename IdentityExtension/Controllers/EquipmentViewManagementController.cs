using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityExtension.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityExtension.Controllers
{
    [Authorize]
    public class EquipmentViewManagementController : Controller
    {
        private readonly DnlDBContext _context;

        public EquipmentViewManagementController(DnlDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewIndexMenu(string id) 
        {
            try
            {

                ViewBag.menu = id;
                return View(await _context.equipment_Tables.ToListAsync());

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: '{e}'");
            }
            return View();
        }
    }
}