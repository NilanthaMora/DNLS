﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExtension.Controllers
{
    public class ViewEquipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}