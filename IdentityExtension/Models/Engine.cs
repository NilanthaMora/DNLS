using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Engine
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Equipment Id")]
        [ForeignKey("Equipment")] 
        public int equipId { get; set; }

        [Display(Name = "Power Rating")]
        public string powerRating { get; set; }

        [Display(Name = "Date Installed")]
        public DateTime? dateInstalled { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? dateModified { get; set; }

        [Display(Name = "Profile Date")]
        public DateTime? proFileDate { get; set; }

        [Display(Name = "Warranty Date")]
        public DateTime? warrantyDate { get; set; }

        public Equipment Equipment { get; set; } 

    }
}
