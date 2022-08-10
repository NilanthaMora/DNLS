using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExtension.Controllers.BillControllers
{
    public class FuelBillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ConsumptionFuel()
        {
            return View();
        }

        public IActionResult FuelBillType()
        {
            return View();
        }

        public IActionResult FuelBillAccount() 
        {
            return View();
        }
    }
}