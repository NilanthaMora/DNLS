using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models.ViewModels
{
    public class ViewMakeModel
    {
        public string make { get; set; }

        public string model { get; set; }

        public int id { get; set; }

        public int eqTId { get; set; }
    }

    public class GeneralInquire 
    {
        public string equipmet { get; set; } 

        public string area { get; set; }

        public string eqBase { get; set; }

        public string make { get; set; }

        public string model { get; set; }

        public string status { get; set; }

        public string power { get; set; }

        public string type { get; set; }

        public string frequency { get; set; }

        public string ammunitionRange { get; set; } 
    }
}
