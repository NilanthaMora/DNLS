using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Ais
    {
        [Key] 
        public int id { get; set; }

        [Required]
        [Display(Name = "Equipment Id")]
        [ForeignKey("Equipment")]
        public int eqId { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }

        [Display(Name = "Frequency Band")]
        public string freqBand { get; set; }

        [Display(Name = "Power OP")]
        public string powerOp { get; set; }

        [Display(Name = "Security")]
        public string security { get; set; }

        [Display(Name = "Type")]
        public string type { get; set; }

        [Display(Name = "Max Detect Range")]
        public string maxDetectRange { get; set; }

        [Display(Name = "Antenna Height")]
        public string antennaHeight { get; set; }

        [Display(Name = "Date Installed")]
        public DateTime? dateInstalled { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? dateModified { get; set; }

        [Display(Name = "PFile Number")]
        public string pfileNum { get; set; }

        [Display(Name = "PFile Date")]
        public DateTime? pfileDate { get; set; }

        [Display(Name = "Price")]
        public string price { get; set; }

        [Display(Name = "We Date")]
        public DateTime? weDate { get; set; }

        public Equipment Equipment { get; set; }
    }
}

