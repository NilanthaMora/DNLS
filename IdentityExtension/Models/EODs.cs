using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class EODs
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Equipment Id")]
        [ForeignKey("Equipment")]
        public int eqId { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

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

        [Display(Name = "Pulse Count")]
        public string pulseCount { get; set; }

        public Equipment Equipment { get; set; }
    }
}
