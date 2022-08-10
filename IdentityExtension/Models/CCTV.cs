using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class CCTV
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Equipment Id")]
        [ForeignKey("Equipment")]
        public int eqId { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }

        [Display(Name = "Date Installed")]
        public DateTime? dateInstalled { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? dateModified { get; set; }

        [Display(Name = "System Type")]
        public string systemType { get; set; }

        [Display(Name = "System Id")]
        public string systemId { get; set; }

        [Display(Name = "Channel")]
        public string channels { get; set; }

        [Display(Name = "Number of Cameras")]
        public string noOfCameras { get; set; }

        [Display(Name = "Number of Displays")]
        public string noOfDisplays { get; set; }

        [Display(Name = "Number of HDD")]
        public string noOfHdd { get; set; }

        [Display(Name = "Type of Cameras")]
        public string typeOfCameras { get; set; }

        [Display(Name = "Type of Displays")]
        public string typeOfDisplays { get; set; }

        [Display(Name = "Type of HDD")]
        public string typeOfHdd { get; set; }

        [Display(Name = "Type of Period")]
        public string typeOfPeriod { get; set; }

        public Equipment Equipment { get; set; }
    }
}
