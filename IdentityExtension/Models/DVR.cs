using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class DVR
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Equipment Id")]
        [ForeignKey("Equipment")]
        public int eqId { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }

        [Display(Name = "DVR Submit Type")]
        public string dvrSubmitType { get; set; }

        [Display(Name = "DVR Submit Srno")]
        public string dvrSubmitSrno { get; set; }

        [Display(Name = "DVR Submit State")]
        public string dvrSubmitState { get; set; }

        [Display(Name = "DVR Submit Make")]
        public string dvrSubmitMake { get; set; }

        [Display(Name = "DVR Submit Model")]
        public string dvrSubmitModel { get; set; }

        [Display(Name = "Date Installed")]
        public DateTime? dateInstalled { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? dateModified { get; set; }

        public Equipment Equipment { get; set; }

    }
}
