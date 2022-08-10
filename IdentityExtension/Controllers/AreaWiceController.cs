using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityExtension.Data;
using IdentityExtension.Models;
using IdentityExtension.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdentityExtension.Controllers
{
    [Authorize]
    public class AreaWiceController : Controller
    {
        private readonly DnlDBContext _context;

        public AreaWiceController(DnlDBContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            ViewData["area"] = new SelectList(_context.areas, "id", "description");
            ViewData["equipment"] = new SelectList(_context.equipment_Tables, "id", "equipment");
            return View();
        }


        [Route("index-column")]
        public IActionResult IndexColumn()
        {
            var eq = _context.equipment_Tables;
            if (ViewBag.AreaWiseSearchInput.equipment == EquipmentEnum.eqip.engine) {

                ViewBag.aa = "aa";
            }
            
            return View();
        }
    }
}