using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExtension.Controllers.BillControllers
{
    public class ElectricityBillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConsumptionElectricity()
        {
            return View();
        }

        public IActionResult AccountElectricity()
        {
            return View();
        }
    }
}