using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class SpareProcurement
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Part Number")]
        public string partNo { get; set; }

        [Display(Name = "Sub Referance")]
        public string sbRef { get; set; }

        [Display(Name = "Current Stock")]
        public string currentStock { get; set; }

        [Display(Name = "First Rate")]
        public string firstRate { get; set; }

        [Display(Name = "Second Rate")]
        public string secondRate { get; set; }

        [Display(Name = "Third Rate")]
        public string thirdRate { get; set; }

        [Display(Name = "Forth Rate")]
        public string forthRate { get; set; }

        [Display(Name = "Procurement Id")]
        public int procuId { get; set; }                          
        public Procurement Procurement { get; set; }
    }
}
