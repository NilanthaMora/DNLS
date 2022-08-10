﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Ammunition
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Ammunition")]
        public string description { get; set; }
        
        public List<Weapon> Weapon { get; set; }
    }
}
