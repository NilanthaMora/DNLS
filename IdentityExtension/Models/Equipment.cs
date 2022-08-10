using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Equipment
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "SRNO")]
        public string srNo { get; set; }

        [Display(Name = "Make")]
        public string make { get; set; }

        [Display(Name = "Model")]
        public string model { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "Base")]
        [ForeignKey("Base")]
        public int eqBase { get; set; }

        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        [Display(Name = "User Id")]
        public string userId { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? cDate { get; set; }

        [Display(Name = "Action")]
        public string action { get; set; }

        [Display(Name = "G47 Remarks")]
        public string g47Remarks { get; set; }

        [Display(Name = "G47 Date")]
        public DateTime? g47Date { get; set; }

        [Display(Name = "Del")]
        public string del { get; set; }

        [Display(Name = "Del Date")]
        public DateTime? delDate { get; set; }

        [Display(Name = "Equipment Table Id")]
        [ForeignKey("EquipmentTable")]
        public int eqTId { get; set; }

        public EquipmentTable EquipmentTable { get; set; }
        public Base Base { get; set; }

        public Engine Engine { get; set; }
        public Radar Radar { get; set; }
        public Gyro Gyro { get; set; }
        public Generator Generator { get; set; }
        public Communication Communication { get; set; }
        public Weapon Weapon { get; set; }
        public Sonar Sonar { get; set; }
        public Gps Gps { get; set; }
        public Guncom Guncom { get; set; }
        public IntegratedHeadingSensor IntegratedHeadingSensor { get; set; }
        public Ais Ais { get; set; }
        public Epirb Epirb { get; set; }
        public DVR DVR { get; set; }
        public CCTV CCTV { get; set; }
        public EODs EODs { get; set; }
        public SatCompass SatCompass { get; set; }
        public SatPhone SatPhone { get; set; }
        public Sart Sart { get; set; }
        public speedLog SpeedLog { get; set; }
        public Anemometers Anemometers { get; set; }
        public XenonSLight XenonSLight { get; set; }
        public Navtex Navtex { get; set; }
        public MiniSat MiniSat { get; set; }
        public ECDI ECDI { get; set; }
    }
}
