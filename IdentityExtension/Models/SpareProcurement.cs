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

        public string partNo { get; set; }

        public string sbRef { get; set; }

        public string currentStock { get; set; }

        public string firstRate { get; set; }

        public string secondRate { get; set; }

        public string thirdRate { get; set; }

        public string forthRate { get; set; }

        public int procuId { get; set; }                          
        public Procurement Procurement { get; set; }
    }
}
