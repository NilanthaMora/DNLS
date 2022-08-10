using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExtension.Controllers
{
    [Authorize]
    public class ProcurementManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}