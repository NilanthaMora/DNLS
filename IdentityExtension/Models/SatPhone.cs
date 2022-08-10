using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class SatPhone
    {
        [Key] 
        public int id { get; set; }

        [Required]
        [Display(Name = "Equipment Id")]
        [ForeignKey("Equipment")]
        public int eqId { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }

        [Display(Name = "In SNo")]
        public string inSNo { get; set; }

        [Display(Name = "Antenna SRNo")]
        public string antennaSrno { get; set; }

        [Display(Name = "Receiver SRNo")]
        public string receiverSrno { get; set; }

        [Display(Name = "Voice")]
        public string voice { get; set; }

        [Display(Name = "Fax")]
        public string fax { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Data Limit")]
        public string dataLimit { get; set; }

        [Display(Name = "Ime Number")]
        public string imeNo { get; set; }

        [Display(Name = "Type")]
        public string type { get; set; }

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

        [Display(Name = "Expire Date Battery")]
        public DateTime? expireDateBattery { get; set; }

        public Equipment Equipment { get; set; }
    }
}