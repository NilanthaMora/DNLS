using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityExtension.Models;
using IdentityExtension.Data;
using Microsoft.AspNetCore.Http;
using IdentityExtension.Models.Enum;
using IdentityExtension.Service;
using System.Data;
using IdentityExtension.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
//using IdentityExtension.Models;

namespace IdentityExtension.Controllers
{
    [Authorize]
    public class EquipmentsController : Controller
    {
        private readonly DnlDBContext _context;

        public EquipmentsController(DnlDBContext context)
        {
            _context = context;
        }

        // GET: 
        [Route("Equipments")]
        public async Task<IActionResult> Index()
        {
            var eqTables = _context.equipment_Tables;
            var report = new List<EquipmentReport> { };

            foreach(var item in _context.equipment_Tables)
            {
                report.Add(new EquipmentReport
                {   equipment = item.equipment,
                    total = _context.equipments.Where(a => a.eqTId.ToString().Equals(item.id.ToString())).Count(),
                    op = _context.equipments.Where(a => a.state.ToString().Equals("1") && a.eqTId.Equals(item.equipmentCode)).Count(),
                    nop = _context.equipments.Where(a => a.state.ToString().Equals("2") && a.eqTId.Equals(item.equipmentCode)).Count(),
                    sop = _context.equipments.Where(a => a.state.ToString().Equals("3") && a.eqTId.Equals(item.equipmentCode)).Count()
                });
            }

           // var engine = new EquipmentReport { equipment = "Engine", total = _context.equipments.Where(a => a.eqTId.Equals(1)).Count(), op = _context.equipments.Where(a => a.state.Equals("1")).Count(), nop = _context.equipments.Where(a => a.state.Equals("2")).Count(), sop = _context.equipments.Where(a => a.state.Equals("3")).Count() };
           // var radar = new EquipmentReport { equipment = "Radar", total = _context.equipments.Where(a => a.eqTId.Equals(2)).Count(), op = _context.equipments.Where(a => a.state.Equals("1")).Count(), nop = _context.equipments.Where(a => a.state.Equals("2")).Count(), sop = _context.equipments.Where(a => a.state.Equals("3")).Count() };

          //  report.Add(engine);
          //  report.Add(radar);

            ViewBag.report = report; 

            return View(); 
        }

        [Route("equipment-details")] 
        public async Task<IActionResult> IndexTable()
        {
            try
            {

                return View(await _context.equipment_Tables.ToListAsync());


            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: '{e}'");
            }
            return View();
        }

        // GET: Equipments/Details/5
        [Route("Equipments/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.equipments
                .Include(e => e.Base)
                .Include(e => e.EquipmentTable)
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipments/G47/5
        [Route("equipments/g47/{id}")]
        public async Task<IActionResult> EquipmentG47Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.menu = id;

            var equipment = _context.equipments
                .Include(e => e.Base)
                .Include(e => e.EquipmentTable)
                .Where(e => e.EquipmentTable.varName == id && e.g47Remarks != null).ToListAsync();
            if (equipment == null)
            {
                return NotFound();
            }

            return View(await equipment);
        }

        // GET: Equipments/G47/5
        [Route("equipments/general/{id}")]
        public IActionResult EquipmentGeneralDetails(string id)
        {
            ViewData["eq"] = id; 
            ViewData["equipStatus"] = new SelectList(Enum.GetValues(typeof(EquipmentEnum.EqStatus)).Cast<EquipmentEnum.EqStatus>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList(), "Value", "Text");
            ViewData["area"] = new SelectList(_context.areas, "id", "description");
            ViewData["eqBase"] = new SelectList(_context.bases, "id", "description");
            ViewData["make"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Make)
            .Where(a => a.EquipmentTable.varName == id).Select(a => a.Make), "description", "description");
            ViewData["model"] = new SelectList(_context.MakeModels.Include(a => a.EquipmentTable).Include(a => a.Model)
            .Where(a => a.EquipmentTable.varName == id).Select(a => a.Model), "description", "description");

            if(id.Equals("engine"))
            {
                ViewData["powerRatingEngine"] = new SelectList(_context.engines, "powerRating", "powerRating");
            }
            if (id.Equals("radar"))
            {
                ViewData["powerRatingRadar"] = new SelectList(_context.radars, "power", "power");
            }
            if (id.Equals("communication"))
            {
                ViewData["typeCom"] = new SelectList(_context.communications.GroupBy(a => a.type).Select(x => x.FirstOrDefault()), "type", "type");
                ViewData["freqBand"] = new SelectList(_context.communications.GroupBy(b => b.freqBand).Select(x => x.FirstOrDefault()), "freqBand", "freqBand");
            }
            if (id.Equals("weapon"))
            {
                ViewData["range"] = new SelectList(_context.ammunitions.GroupBy(a => a.description).Select(x => x.FirstOrDefault()), "description", "description");
            }
            if (id.Equals("satPhone"))
            {
                ViewData["typeSPhone"] = new SelectList(_context.satPhones.GroupBy(a => a.type).Select(x => x.FirstOrDefault()), "type", "type");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("equipments/general")]
        public async Task<IActionResult> CreateGeneralDetails(GeneralInquire generalInquire)
        {
            if (ModelState.IsValid)
            {
                ViewData["eq"] = generalInquire.equipmet;
                var data = await _context.equipments
                    .Include(a => a.EquipmentTable)
                    .Include(a => a.EquipmentTable.MakeModels)
                    .Include(c => c.Base)
                    .Include(d => d.Base.Area)
                    .Where(
                        e => e.Base.id.ToString().Equals(generalInquire.eqBase)
                        && e.Base.Area.id.ToString().Equals(generalInquire.area)
                        && e.make.ToString().Equals(generalInquire.make)
                        && e.model.ToString().Equals(generalInquire.model)
                        && e.state.ToString().Equals(generalInquire.status)
                    )
                  .ToListAsync();
                if (generalInquire.equipmet.Equals("engine"))
                {
                    data = await _context.equipments
                   .Include(a => a.EquipmentTable)
                   .Include(a => a.EquipmentTable.MakeModels)
                   .Include(c => c.Base)
                   .Include(d => d.Base.Area)
                   .Include(d => d.Engine)
                   .Where(
                       e => e.Base.id.ToString().Equals(generalInquire.eqBase)
                       && e.Base.Area.id.ToString().Equals(generalInquire.area)
                       && e.make.ToString().Equals(generalInquire.make)
                       && e.model.ToString().Equals(generalInquire.model)
                       && e.state.ToString().Equals(generalInquire.status)
                       && e.Engine.powerRating.ToString().Equals(generalInquire.power)
                   )
                 .ToListAsync();
                }
                if (generalInquire.equipmet.Equals("radar"))
                {
                    data = await _context.equipments
                   .Include(a => a.EquipmentTable)
                   .Include(a => a.EquipmentTable.MakeModels)
                   .Include(c => c.Base)
                   .Include(d => d.Base.Area)
                   .Include(d => d.Radar)
                   .Where(
                       e => e.Base.id.ToString().Equals(generalInquire.eqBase)
                       && e.Base.Area.id.ToString().Equals(generalInquire.area)
                       && e.make.ToString().Equals(generalInquire.make)
                       && e.model.ToString().Equals(generalInquire.model)
                       && e.state.ToString().Equals(generalInquire.status)
                       && e.Radar.power.ToString().Equals(generalInquire.power)
                   )
                 .ToListAsync();
                }
                if (generalInquire.equipmet.Equals("communication"))
                {
                    data = await _context.equipments
                   .Include(a => a.EquipmentTable)
                   .Include(a => a.EquipmentTable.MakeModels)
                   .Include(c => c.Base)
                   .Include(d => d.Base.Area)
                   .Include(d => d.Communication)
                   .Where(
                       e => e.Base.id.ToString().Equals(generalInquire.eqBase)
                       && e.Base.Area.id.ToString().Equals(generalInquire.area)
                       && e.make.ToString().Equals(generalInquire.make)
                       && e.model.ToString().Equals(generalInquire.model)
                       && e.state.ToString().Equals(generalInquire.status)
                       && e.Communication.freqBand.ToString().Equals(generalInquire.frequency)
                       && e.Communication.type.ToString().Equals(generalInquire.type)
                   )
                 .ToListAsync();
                }
                if (generalInquire.equipmet.Equals("weapon"))
                {
                    data = await _context.equipments
                    .Include(a => a.EquipmentTable)
                    .Include(a => a.EquipmentTable.MakeModels)
                    .Include(c => c.Base)
                    .Include(d => d.Base.Area)
                    .Include(d => d.Communication)
                    .Where(
                        e => e.Base.id.ToString().Equals(generalInquire.eqBase)
                        && e.Base.Area.id.ToString().Equals(generalInquire.area)
                        && e.make.ToString().Equals(generalInquire.make)
                        && e.model.ToString().Equals(generalInquire.model)
                        && e.state.ToString().Equals(generalInquire.status)
                        && e.Weapon.Ammunition.description.ToString().Equals(generalInquire.ammunitionRange)
                    )
                    .ToListAsync();

                }
                if (generalInquire.equipmet.Equals("satPhone"))
                {
                    data = await _context.equipments
                    .Include(a => a.EquipmentTable)
                    .Include(a => a.EquipmentTable.MakeModels)
                    .Include(c => c.Base)
                    .Include(d => d.Base.Area)
                    .Include(d => d.SatPhone)
                    .Where(
                        e => e.Base.id.ToString().Equals(generalInquire.eqBase)
                        && e.Base.Area.id.ToString().Equals(generalInquire.area)
                        && e.make.ToString().Equals(generalInquire.make)
                        && e.model.ToString().Equals(generalInquire.model)
                        && e.state.ToString().Equals(generalInquire.status)
                        && e.SatPhone.type.ToString().Equals(generalInquire.type)
                    )
                    .ToListAsync();

                }
                    return View(data);
                }
                return View(generalInquire);
            }
        
        // GET: Equipments/Create
        [Route("Equipments/Create")]
        public IActionResult Create()
        {
            ViewData["eqBase"] = new SelectList(_context.bases, "id", "id");
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables, "id", "equipment");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Equipments/Create")]
        public async Task<IActionResult> Create([Bind("id,srNo,make,model,state,eqBase,remarks,userId,cDate,action,g47Remarks,g47Date,del,delDate,eqTId")] Models.Equipment  equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["eqBase"] = new SelectList(_context.bases, "id", "id", equipment.eqBase);
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables, "id", "equipment", equipment.eqTId);
            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Equipments/CreateColSet")]
        public async Task<IActionResult> CreateColSet([Bind("area, equipment")] AreaWise areaWise)
        {
            if (ModelState.IsValid)
            {

                var eq = await _context.equipment_Tables.Where(a => a.id.Equals(areaWise.equipment)).FirstOrDefaultAsync();

                List<SelectListItem> listEq = new List<SelectListItem>() { };

                if (eq.varName == EquipmentEnum.eqip.engine.ToString())
                {
                    EqType engine = new EqType() { };
                    listEq = engine.engineList();
                }
                else if (eq.varName == EquipmentEnum.eqip.radar.ToString())
                {
                    EqType radar = new EqType() { };
                    listEq = radar.radarList();
                }
                else if (eq.varName == EquipmentEnum.eqip.ais.ToString())
                {
                    EqType ais = new EqType() { };
                    listEq = ais.aisList(); 
                }
                else if (eq.varName == EquipmentEnum.eqip.anemometers.ToString())
                {
                    EqType anemometers = new EqType() { };
                    listEq = anemometers.anemometersList();
                }
                else if (eq.varName == EquipmentEnum.eqip.cctv.ToString())
                {
                    EqType cctv = new EqType() { };
                    listEq = cctv.cctvList();
                }
                else if (eq.varName == EquipmentEnum.eqip.communication.ToString())
                {
                    EqType communication = new EqType() { };
                    listEq = communication.communicationList();
                }
                else if (eq.varName == EquipmentEnum.eqip.dvr.ToString())
                {
                    EqType dvr = new EqType() { };
                    listEq = dvr.dvrList();
                }
                else if (eq.varName == EquipmentEnum.eqip.ecdis.ToString())
                {
                    EqType ecdis = new EqType() { };
                    listEq = ecdis.ecdisList();
                }
                else if (eq.varName == EquipmentEnum.eqip.eods.ToString())
                {
                    EqType eods = new EqType() { };
                    listEq = eods.ecdisList();
                }
                else if (eq.varName == EquipmentEnum.eqip.epirb.ToString())
                {
                    EqType epirb = new EqType() { };
                    listEq = epirb.epirbList();
                }
                else if (eq.varName == EquipmentEnum.eqip.generator.ToString())
                {
                    EqType generator = new EqType() { };
                    listEq = generator.generatorList();
                }
                else if (eq.varName == EquipmentEnum.eqip.gps.ToString())
                {
                    EqType gps = new EqType() { };
                    listEq = gps.gpsList();
                }
                else if (eq.varName == EquipmentEnum.eqip.guncom.ToString())
                {
                    EqType guncom = new EqType() { };
                    listEq = guncom.gpsList();
                }
                else if (eq.varName == EquipmentEnum.eqip.gyro.ToString())
                {
                    EqType gyro = new EqType() { };
                    listEq = gyro.gyroList();
                }
                else if (eq.varName == EquipmentEnum.eqip.integratedHeadingSensor.ToString())
                {
                    EqType integratedHeadingSensor = new EqType() { };
                    listEq = integratedHeadingSensor.sensorList();
                }
                else if (eq.varName == EquipmentEnum.eqip.miniSat.ToString())
                {
                    EqType miniSat = new EqType() { };
                    listEq = miniSat.minisatList();
                }
                else if (eq.varName == EquipmentEnum.eqip.navtex.ToString())
                {
                    EqType navtex = new EqType() { };
                    listEq = navtex.navtexList();
                }
                else if (eq.varName == EquipmentEnum.eqip.sart.ToString())
                {
                    EqType sart = new EqType() { };
                    listEq = sart.sartList();
                }
                else if (eq.varName == EquipmentEnum.eqip.satCompass.ToString())
                {
                    EqType satCompass = new EqType() { };
                    listEq = satCompass.satCompassList();
                }
                else if (eq.varName == EquipmentEnum.eqip.satPhone.ToString())
                {
                    EqType satPhone = new EqType() { };
                    listEq = satPhone.satPhoneList();
                }
                else if (eq.varName == EquipmentEnum.eqip.sonar.ToString())
                {
                    EqType sonar = new EqType() { };
                    listEq = sonar.sonarList();
                }
                else if (eq.varName == EquipmentEnum.eqip.speedLog.ToString())
                {
                    EqType speedLog = new EqType() { };
                    listEq = speedLog.speedLogList();
                }
                else if (eq.varName == EquipmentEnum.eqip.weapon.ToString())
                {
                    EqType weapon = new EqType() { };
                    listEq = weapon.anemometersList();
                }
                else if (eq.varName == EquipmentEnum.eqip.xenonSearchLight.ToString())
                {
                    EqType xenonSearchLight = new EqType() { };
                    listEq = xenonSearchLight.xenonSearchLightList();
                };
                ViewBag.area = areaWise.area;
                ViewBag.equipment = areaWise.equipment;
                return View(listEq);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Equipments/SelectByColumn")]
        public async Task<IActionResult> SelectByColumn(string[] equipmentData) 
        //public async void SelectByColumn(string[] equipmentData)
        {
            if (ModelState.IsValid)
            {
                string area = Request.Form["area"];
                string equipment = Request.Form["equipment"];
                var eq = await _context.equipment_Tables.Where(a => a.id.Equals(int.Parse(equipment))).FirstOrDefaultAsync();

                switch (eq.varName)
                {
                    case "engine":
                        return RedirectToAction("EngineSet", "Equipments", new { area, equipment, equipmentData });
                    case "radar":
                        return RedirectToAction("RadarSet", "Equipments", new { area, equipment, equipmentData });
                    case "gyro":
                        return RedirectToAction("GyroSet", "Equipments", new { area, equipment, equipmentData });
                    case "generator":
                        return RedirectToAction("GeneratorSet", "Equipments", new { area, equipment, equipmentData });
                    case "communication":
                        return RedirectToAction("CommunicationSet", "Equipments", new { area, equipment, equipmentData });
                    case "weapon":
                        return RedirectToAction("WeaponSet", "Equipments", new { area, equipment, equipmentData });
                    case "sonar":
                        return RedirectToAction("SonarSet", "Equipments", new { area, equipment, equipmentData });
                    case "gps":
                        return RedirectToAction("GPSSet", "Equipments", new { area, equipment, equipmentData });
                    case "guncom":
                        return RedirectToAction("GuncomSet", "Equipments", new { area, equipment, equipmentData });
                    case "integratedHeadingSensor":
                        return RedirectToAction("IntegratedHeadingSensorsSet", "Equipments", new { area, equipment, equipmentData });
                    case "ais":
                        return RedirectToAction("AisSet", "Equipments", new { area, equipment, equipmentData });
                    case "epirb":
                        return RedirectToAction("EPIRBSet", "Equipments", new { area, equipment, equipmentData });
                    case "dvr":
                        return RedirectToAction("DVRSet", "Equipments", new { area, equipment, equipmentData });
                    case "cctv":
                        return RedirectToAction("CCTVSet", "Equipments", new { area, equipment, equipmentData });
                    case "eods":
                        return RedirectToAction("EODSet", "Equipments", new { area, equipment, equipmentData });
                    case "satCompass":
                        return RedirectToAction("SatCompassSet", "Equipments", new { area, equipment, equipmentData });
                    case "satPhone":
                        return RedirectToAction("SatPhoneSet", "Equipments", new { area, equipment, equipmentData });
                    case "sart":
                        return RedirectToAction("SartSet", "Equipments", new { area, equipment, equipmentData });
                    case "speedLog":
                        return RedirectToAction("SpeedLogSet", "Equipments", new { area, equipment, equipmentData });
                    case "anemometers":
                        return RedirectToAction("AnemometerSet", "Equipments", new { area, equipment, equipmentData });
                    case "xenonSearchLight":
                        return RedirectToAction("XenonSet", "Equipments", new { area, equipment, equipmentData });
                    case "navtex":
                        return RedirectToAction("NavtexSet", "Equipments", new { area, equipment, equipmentData });
                    case "miniSat":
                        return RedirectToAction("MiniSatSet", "Equipments", new { area, equipment, equipmentData });
                    case "ecdis":
                        return RedirectToAction("ECDIsSet", "Equipments", new { area, equipment, equipmentData });
                    default:
                        break;
                }
            }
            return View(equipmentData); 
        }

        public async Task<IActionResult> EngineSet(string area, string equipment, string[] equipmentData) 
        {
            ViewBag.selectedColumn = equipmentData;
            var engine = await _context.engines
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();

            
            return View(engine);
        }

        public async Task<IActionResult> AisSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var ais = await _context.ais
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(ais); 
        }

        public async Task<IActionResult> RadarSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var radar = await _context.radars
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(radar);
        }

        public async Task<IActionResult> GeneratorSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var generator = await _context.generators
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(generator);
        }

        public async Task<IActionResult> CommunicationSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var communications = await _context.communications
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(communications);
        }

        public async Task<IActionResult> WeaponSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var weapons = await _context.weapons
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Include(d => d.Ammunition.description)
                        .Include(d => d.Country.description)
                        .Include(d => d.CanonType.description)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(weapons);
        }

        public async Task<IActionResult> SonarSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var sonars = await _context.sonars
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(sonars);
        }

        public async Task<IActionResult> GPSSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var gps = await _context.gps
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(gps);
        }

        public async Task<IActionResult> GuncomSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var guncoms = await _context.guncoms
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(guncoms);
        }

        public async Task<IActionResult> IntegratedHeadingSensorsSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var sensors = await _context.integratedHeadingSensors
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(sensors);
        }

        public async Task<IActionResult> GyroSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var gyros = await _context.gyros
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(gyros);
        }

        public async Task<IActionResult> EPIRBSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var epirbs = await _context.epirbs
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(epirbs);
        }

        public async Task<IActionResult> DVRSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var dVRs = await _context.dVRs
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(dVRs);
        }

        public async Task<IActionResult> CCTVSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var cCTVs = await _context.cCTVs
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(cCTVs);
        }

        public async Task<IActionResult> EODSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var eODs = await _context.eODs
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(eODs);
        }

        public async Task<IActionResult> SatCompassSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var satCompasses = await _context.satCompasses
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(satCompasses);
        }

        public async Task<IActionResult> SatPhoneSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var satPhones = await _context.satPhones
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(satPhones);
        }

        public async Task<IActionResult> SartSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var sarts = await _context.sarts
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(sarts);
        }

        public async Task<IActionResult> SpeedLogSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var speedLogs = await _context.speedLogs
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(speedLogs);
        }

        public async Task<IActionResult> AnemometerSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var anemometers = await _context.anemometers
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(anemometers);
        }

        public async Task<IActionResult> XenonSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var xenonSLights = await _context.xenonS
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(xenonSLights);
        }

        public async Task<IActionResult> NavtexSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var navtices = await _context.navtexs
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(navtices);
        }

        public async Task<IActionResult> MiniSatSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var miniSats = await _context.miniSats
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(miniSats);
        }

        public async Task<IActionResult> ECDIsSet(string area, string equipment, string[] equipmentData)
        {
            ViewBag.selectedColumn = equipmentData;
            var eCDIs = await _context.eCDIs
                        .Include(e => e.Equipment)
                        .Include(a => a.Equipment.Base)
                        .Include(c => c.Equipment.Base.SubUnits)
                        .Where(a => a.Equipment.eqTId.ToString().Equals(equipment)
                        && a.Equipment.Base.areaId.ToString().Equals(area))
                        .ToListAsync();


            return View(eCDIs);
        }

        // GET: Equipments/Edit/5
        [Route("Equipments/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["eqBase"] = new SelectList(_context.bases, "id", "id", equipment.eqBase);
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables, "id", "equipment", equipment.eqTId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Equipments/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("id,srNo,make,model,state,eqBase,remarks,userId,cDate,action,g47Remarks,g47Date,del,delDate,eqTId")] Models.Equipment equipment)
        {
            if (id != equipment.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.id))
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
            ViewData["eqBase"] = new SelectList(_context.bases, "id", "id", equipment.eqBase);
            ViewData["eqTId"] = new SelectList(_context.equipment_Tables, "id", "equipment", equipment.eqTId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        [Route("Equipments/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.equipments
                .Include(e => e.Base)
                .Include(e => e.EquipmentTable)
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = await _context.equipments.FindAsync(id);
            _context.equipments.Remove(equipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool EquipmentExists(int id)
        {
            return _context.equipments.Any(e => e.id == id);
        }
    }
}
