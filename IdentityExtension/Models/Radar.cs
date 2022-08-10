using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Radar
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Equipment Id")]
        [ForeignKey("Equipment")]
        public int eqId { get; set; }

        [Display(Name = "Power")]
        public string power { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }

        [Display(Name = "Voltage")]
        public string voltage { get; set; }

        [Display(Name = "Scanner Length")]
        public string scannerLength { get; set; }

        [Display(Name = "Supply")]
        public string supply { get; set; }

        [Display(Name = "Date Installed")]
        public DateTime? dateInstalled { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? dateModified { get; set; }

        [Display(Name = "Dingy Range")]
        public string dingyRange { get; set; }

        [Display(Name = "Trawler Range")]
        public string trawlerRange { get; set; }

        [Display(Name = "IPC Range")]
        public string ipcRange { get; set; }

        [Display(Name = "FAC Range")]
        public string facRange { get; set; }

        [Display(Name = "FGB Range")]
        public string fgbRange { get; set; }

        [Display(Name = "Running Hours")]
        public string runningHours { get; set; }

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

