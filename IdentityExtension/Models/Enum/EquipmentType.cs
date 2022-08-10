using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models.Enum
{
    public class EquipmentEnum
    {
        public enum eqip
        {
            engine,
            radar,
            gyro,
            generator,
            communication,
            weapon,
            sonar,
            gps,
            guncom,
            integratedHeadingSensor,
            ais,
            epirb,
            dvr,
            cctv,
            eods,
            satCompass,
            satPhone,
            sart,
            speedLog,
            anemometers,
            xenonSearchLight,
            navtex,
            miniSat, 
            ecdis
        }

        public enum EqStatus
        {
            [Display(Name = "OP")]
            OP = 1,
            [Display(Name = "NOP")]
            NOP = 2,
            [Display(Name = "SOP")]
            SOP = 3
        }
    }
}
