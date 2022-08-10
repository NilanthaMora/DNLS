using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Generator
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Equipment Id")]
        [ForeignKey("Equipment")]
        public int eqId { get; set; }

        [Display(Name = "Mounted At")]
        public string mountedAt { get; set; }

        [Display(Name = "KVA")]
        public string kva { get; set; }

        [Display(Name = "Voltage")]
        public string voltage { get; set; }

        [Display(Name = "Phase")]
        public string phase { get; set; }

        [Display(Name = "Frequancy")]
        public string frequancy { get; set; }

        [Display(Name = "Alternator Model")]
        public string alternatorModel { get; set; }

        [Display(Name = "Alternator Make")]
        public string alternatorMake { get; set; }

        [Display(Name = "Alternator SR Number")]
        public string alternatorSrno { get; set; }

        [Display(Name = "Primemover Model")]
        public string primemoverModel { get; set; }

        [Display(Name = "Primemover Make")]
        public string primemoverMake { get; set; }

        [Display(Name = "Primemover SR Number")]
        public string primemoverSrno { get; set; }

        [Display(Name = "MRH")]
        public string mrh { get; set; }

        [Display(Name = "Total Run Hours")]
        public string totalRunHours { get; set; }

        [Display(Name = "Full Load")]
        public string fullLoad { get; set; }

        [Display(Name = "Max Load")]
        public string maxLoad { get; set; }

        [Display(Name = "Presentage")]
        public string presentage { get; set; }

        [Display(Name = "Ledger Page Number")]
        public string ledgerPageNo { get; set; }

        [Display(Name = "Mode")]
        public string mode { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? dateModified { get; set; }

        public Equipment Equipment { get; set; }
    }
}
