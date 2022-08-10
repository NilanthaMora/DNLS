using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class SelectCol
    {
      
    }

    public class EqType
    {
        public List<SelectListItem> engineList()
        {
            List<SelectListItem> listEngine = new List<SelectListItem>() { };
            listEngine.Add(new SelectListItem("1", "Id"));
            listEngine.Add(new SelectListItem("2", "Sr_No")); 
            listEngine.Add(new SelectListItem("3", "Make"));
            listEngine.Add(new SelectListItem("4", "Model"));
            listEngine.Add(new SelectListItem("5", "Power_Rating"));
            listEngine.Add(new SelectListItem("6", "Base"));
            listEngine.Add(new SelectListItem("7", "Sub_Unit"));
            listEngine.Add(new SelectListItem("8", "State"));
            listEngine.Add(new SelectListItem("9", "Date_Installed"));
            listEngine.Add(new SelectListItem("10", "Date_Modified"));
            listEngine.Add(new SelectListItem("11", "Remarks"));
            listEngine.Add(new SelectListItem("12", "Profile_Date"));
            listEngine.Add(new SelectListItem("13", "Warranty_Date"));
            listEngine.Add(new SelectListItem("14", "User_Id"));
            listEngine.Add(new SelectListItem("15", "C_Date"));
            listEngine.Add(new SelectListItem("16", "Action"));
            listEngine.Add(new SelectListItem("17", "G47_Remarks"));
            listEngine.Add(new SelectListItem("18", "G47_Date"));
            listEngine.Add(new SelectListItem("19", "Del"));
            listEngine.Add(new SelectListItem("20", "Del_Date"));

            return listEngine;
        }

        public List<SelectListItem> radarList()
        {
            List<SelectListItem> listRadar = new List<SelectListItem>() { };
            listRadar.Add(new SelectListItem("1", "Id"));
            listRadar.Add(new SelectListItem("2", "Sr_No"));
            listRadar.Add(new SelectListItem("3", "Make"));
            listRadar.Add(new SelectListItem("4", "Model"));
            listRadar.Add(new SelectListItem("5", "Power"));
            listRadar.Add(new SelectListItem("6", "Location"));
            listRadar.Add(new SelectListItem("7", "Voltage"));
            listRadar.Add(new SelectListItem("8", "Scanner_Length"));
            listRadar.Add(new SelectListItem("9", "Base"));
            listRadar.Add(new SelectListItem("10", "Sub_Unit"));
            listRadar.Add(new SelectListItem("11", "Supply"));
            listRadar.Add(new SelectListItem("12", "State"));
            listRadar.Add(new SelectListItem("13", "Date_Installed"));
            listRadar.Add(new SelectListItem("14", "Date_Modified"));
            listRadar.Add(new SelectListItem("15", "Remarks"));
            listRadar.Add(new SelectListItem("16", "Dingy_Range"));
            listRadar.Add(new SelectListItem("17", "Trawler_Range"));
            listRadar.Add(new SelectListItem("18", "IPC_Range"));
            listRadar.Add(new SelectListItem("19", "FAC_Range"));
            listRadar.Add(new SelectListItem("20", "Running_Hours"));
            listRadar.Add(new SelectListItem("21", "FGB_Range"));
            listRadar.Add(new SelectListItem("22", "User_Id"));
            listRadar.Add(new SelectListItem("23", "C_Date"));
            listRadar.Add(new SelectListItem("24", "Profile_Num"));
            listRadar.Add(new SelectListItem("25", "Profile_Date"));
            listRadar.Add(new SelectListItem("26", "Price"));
            listRadar.Add(new SelectListItem("27", "We_Date"));
            listRadar.Add(new SelectListItem("28", "Action"));
            listRadar.Add(new SelectListItem("29", "G47_Remarks"));
            listRadar.Add(new SelectListItem("30", "G47_Date"));
            listRadar.Add(new SelectListItem("31", "Del"));
            listRadar.Add(new SelectListItem("32", "Del_Date"));

            return listRadar;
        }

        public List<SelectListItem> gyroList()
        {
            List<SelectListItem> listGyro = new List<SelectListItem>() { };
            listGyro.Add(new SelectListItem("1", "Id"));
            listGyro.Add(new SelectListItem("2", "Sr_No"));
            listGyro.Add(new SelectListItem("3", "Make"));
            listGyro.Add(new SelectListItem("4", "Model"));
            listGyro.Add(new SelectListItem("5", "Location"));
            listGyro.Add(new SelectListItem("6", "Inter_Face_Used"));
            listGyro.Add(new SelectListItem("7", "Base"));
            listGyro.Add(new SelectListItem("8", "Sub_Unit"));
            listGyro.Add(new SelectListItem("9", "State"));
            listGyro.Add(new SelectListItem("10", "Date_Installed"));
            listGyro.Add(new SelectListItem("11", "Date_Modified"));
            listGyro.Add(new SelectListItem("12", "Remarks"));
            listGyro.Add(new SelectListItem("13", "User_Id"));
            listGyro.Add(new SelectListItem("14", "C_Date"));
            listGyro.Add(new SelectListItem("15", "Profile_Num"));
            listGyro.Add(new SelectListItem("16", "Profile_Date"));
            listGyro.Add(new SelectListItem("17", "Price"));
            listGyro.Add(new SelectListItem("18", "We_Date"));
            listGyro.Add(new SelectListItem("19", "Action"));
            listGyro.Add(new SelectListItem("20", "G47_Remarks"));
            listGyro.Add(new SelectListItem("21", "G47_Date"));
            listGyro.Add(new SelectListItem("22", "Del"));
            listGyro.Add(new SelectListItem("23", "Del_Date"));

            return listGyro;
        }

        public List<SelectListItem> generatorList() 
        {
            List<SelectListItem> listGenerator = new List<SelectListItem>() { };
            listGenerator.Add(new SelectListItem("1", "Id"));
            listGenerator.Add(new SelectListItem("2", "Base"));
            listGenerator.Add(new SelectListItem("3", "Mounted_At"));
            listGenerator.Add(new SelectListItem("4", "KVA"));
            listGenerator.Add(new SelectListItem("5", "Voltage"));
            listGenerator.Add(new SelectListItem("6", "Phase"));
            listGenerator.Add(new SelectListItem("7", "Frequancy"));
            listGenerator.Add(new SelectListItem("8", "Generator_Model"));
            listGenerator.Add(new SelectListItem("9", "Make"));
            listGenerator.Add(new SelectListItem("10", "Generator_Sr_No"));
            listGenerator.Add(new SelectListItem("11", "Alternator_Model"));
            listGenerator.Add(new SelectListItem("12", "Alternator_Make"));
            listGenerator.Add(new SelectListItem("13", "Alternator_Sr_No"));
            listGenerator.Add(new SelectListItem("14", "Primemover_Model"));
            listGenerator.Add(new SelectListItem("15", "Primemover_Make"));
            listGenerator.Add(new SelectListItem("16", "Primemover_Sr_No"));
            listGenerator.Add(new SelectListItem("17", "State"));
            listGenerator.Add(new SelectListItem("18", "M_R_H"));
            listGenerator.Add(new SelectListItem("19", "Total_Run_Hrs"));
            listGenerator.Add(new SelectListItem("20", "Full_Load"));
            listGenerator.Add(new SelectListItem("21", "Max_Load"));
            listGenerator.Add(new SelectListItem("22", "Presentage"));
            listGenerator.Add(new SelectListItem("23", "Remarks"));
            listGenerator.Add(new SelectListItem("24", "Ledger_Page_No"));
            listGenerator.Add(new SelectListItem("25", "Mode"));
            listGenerator.Add(new SelectListItem("26", "User_Id"));
            listGenerator.Add(new SelectListItem("27", "C_Date"));
            listGenerator.Add(new SelectListItem("28", "Action"));
            listGenerator.Add(new SelectListItem("29", "G47_Remarks"));
            listGenerator.Add(new SelectListItem("30", "G47_Date"));
            listGenerator.Add(new SelectListItem("31", "Del"));
            listGenerator.Add(new SelectListItem("32", "Del_Date"));
            listGenerator.Add(new SelectListItem("33", "Del_Modified")); 

            return listGenerator;
        }

        public List<SelectListItem> communicationList() 
        {
            List<SelectListItem> listCommunication = new List<SelectListItem>() { };
            listCommunication.Add(new SelectListItem("1", "Id"));
            listCommunication.Add(new SelectListItem("2", "Sr_No"));
            listCommunication.Add(new SelectListItem("3", "Make"));
            listCommunication.Add(new SelectListItem("4", "Model"));
            listCommunication.Add(new SelectListItem("5", "Frequency_Band"));
            listCommunication.Add(new SelectListItem("6", "Power_Op"));
            listCommunication.Add(new SelectListItem("7", "Location"));
            listCommunication.Add(new SelectListItem("8", "Security"));
            listCommunication.Add(new SelectListItem("9", "Type"));
            listCommunication.Add(new SelectListItem("10", "Base"));
            listCommunication.Add(new SelectListItem("11", "Sub_Unit"));
            listCommunication.Add(new SelectListItem("12", "State"));
            listCommunication.Add(new SelectListItem("13", "Date_Installed"));
            listCommunication.Add(new SelectListItem("14", "Date_Modified"));
            listCommunication.Add(new SelectListItem("15", "Remarks"));
            listCommunication.Add(new SelectListItem("16", "User_Id"));
            listCommunication.Add(new SelectListItem("17", "C_Date"));
            listCommunication.Add(new SelectListItem("18", "Profile_Number"));
            listCommunication.Add(new SelectListItem("19", "Profile_Date"));
            listCommunication.Add(new SelectListItem("20", "Price"));
            listCommunication.Add(new SelectListItem("21", "We_date"));
            listCommunication.Add(new SelectListItem("22", "Action"));
            listCommunication.Add(new SelectListItem("23", "G47_Remarks"));
            listCommunication.Add(new SelectListItem("24", "G47_Date"));
            listCommunication.Add(new SelectListItem("25", "Del"));
            listCommunication.Add(new SelectListItem("26", "Del_Date"));

            return listCommunication;
        }

        public List<SelectListItem> armamentList()
        {
            List<SelectListItem> listArmament = new List<SelectListItem>() { };
            listArmament.Add(new SelectListItem("1", "Id"));
            listArmament.Add(new SelectListItem("2", "Sr_No"));
            listArmament.Add(new SelectListItem("3", "Weapon_System"));
            listArmament.Add(new SelectListItem("4", "Country"));
            listArmament.Add(new SelectListItem("5", "Canon_Type"));
            listArmament.Add(new SelectListItem("6", "Ammunition"));
            listArmament.Add(new SelectListItem("7", "Base"));
            listArmament.Add(new SelectListItem("8", "Sub_Unit"));
            listArmament.Add(new SelectListItem("9", "State"));
            listArmament.Add(new SelectListItem("10", "Running_Hrs"));
            listArmament.Add(new SelectListItem("11", "Remarks"));
            listArmament.Add(new SelectListItem("12", "Profile_Num"));
            listArmament.Add(new SelectListItem("13", "Profile_Date"));
            listArmament.Add(new SelectListItem("14", "Price"));
            listArmament.Add(new SelectListItem("15", "We_Date"));
            listArmament.Add(new SelectListItem("16", "User_Id"));
            listArmament.Add(new SelectListItem("17", "C_Date"));
            listArmament.Add(new SelectListItem("18", "Action"));
            listArmament.Add(new SelectListItem("19", "G47_Remarks"));
            listArmament.Add(new SelectListItem("20", "G47_Date"));
            listArmament.Add(new SelectListItem("21", "Del"));
            listArmament.Add(new SelectListItem("22", "Del_Date"));
            listArmament.Add(new SelectListItem("23", "Make"));

            return listArmament;
        }

        public List<SelectListItem> sonarList()
        {
            List<SelectListItem> listSonar = new List<SelectListItem>() { };
            listSonar.Add(new SelectListItem("1", "Id"));
            listSonar.Add(new SelectListItem("2", "Sr_No"));
            listSonar.Add(new SelectListItem("3", "Make"));
            listSonar.Add(new SelectListItem("4", "Model"));
            listSonar.Add(new SelectListItem("5", "Location"));
            listSonar.Add(new SelectListItem("6", "Type_of_Transducer"));
            listSonar.Add(new SelectListItem("7", "Base"));
            listSonar.Add(new SelectListItem("8", "Sub_Unit"));
            listSonar.Add(new SelectListItem("9", "State"));
            listSonar.Add(new SelectListItem("10", "Date_Installed"));
            listSonar.Add(new SelectListItem("11", "Date_Modified"));
            listSonar.Add(new SelectListItem("12", "Remarks"));
            listSonar.Add(new SelectListItem("13", "User_Id"));
            listSonar.Add(new SelectListItem("14", "C_Date"));
            listSonar.Add(new SelectListItem("15", "Profile_Num"));
            listSonar.Add(new SelectListItem("16", "Profile_Date"));
            listSonar.Add(new SelectListItem("17", "Price"));
            listSonar.Add(new SelectListItem("18", "We_Date"));
            listSonar.Add(new SelectListItem("19", "Action"));
            listSonar.Add(new SelectListItem("20", "G47_Remarks"));
            listSonar.Add(new SelectListItem("21", "G47_Date"));
            listSonar.Add(new SelectListItem("22", "Del"));
            listSonar.Add(new SelectListItem("23", "Del_Date"));

            return listSonar;
        }

        public List<SelectListItem> gpsList()
        {
            List<SelectListItem> listGps = new List<SelectListItem>() { };
            listGps.Add(new SelectListItem("1", "Id"));
            listGps.Add(new SelectListItem("2", "Sr_No"));
            listGps.Add(new SelectListItem("3", "Make"));
            listGps.Add(new SelectListItem("4", "Model"));
            listGps.Add(new SelectListItem("5", "Base"));
            listGps.Add(new SelectListItem("6", "Sub_Unit"));
            listGps.Add(new SelectListItem("7", "Location"));
            listGps.Add(new SelectListItem("8", "State"));
            listGps.Add(new SelectListItem("9", "Date_Installed"));
            listGps.Add(new SelectListItem("10", "Date_Modified"));
            listGps.Add(new SelectListItem("11", "Remarks"));
            listGps.Add(new SelectListItem("12", "User_Id"));
            listGps.Add(new SelectListItem("13", "C_Date"));
            listGps.Add(new SelectListItem("14", "Profile_Num"));
            listGps.Add(new SelectListItem("15", "Profile_Date"));
            listGps.Add(new SelectListItem("16", "Price"));
            listGps.Add(new SelectListItem("17", "We_Date"));
            listGps.Add(new SelectListItem("18", "Action"));
            listGps.Add(new SelectListItem("19", "G47_Remarks"));
            listGps.Add(new SelectListItem("20", "G47_Date"));
            listGps.Add(new SelectListItem("21", "Del"));
            listGps.Add(new SelectListItem("22", "Del_Date"));

            return listGps;
        }

        public List<SelectListItem> guncomList()
        {
            List<SelectListItem> listGuncom = new List<SelectListItem>() { };
            listGuncom.Add(new SelectListItem("1", "Id"));
            listGuncom.Add(new SelectListItem("2", "Sr_No"));
            listGuncom.Add(new SelectListItem("3", "Make"));
            listGuncom.Add(new SelectListItem("4", "Model"));
            listGuncom.Add(new SelectListItem("5", "Base"));
            listGuncom.Add(new SelectListItem("6", "Sub_Unit"));
            listGuncom.Add(new SelectListItem("7", "Location"));
            listGuncom.Add(new SelectListItem("8", "State"));
            listGuncom.Add(new SelectListItem("9", "Date_Installed"));
            listGuncom.Add(new SelectListItem("10", "Date_Modified"));
            listGuncom.Add(new SelectListItem("11", "Remarks"));
            listGuncom.Add(new SelectListItem("12", "User_Id"));
            listGuncom.Add(new SelectListItem("13", "C_Date"));
            listGuncom.Add(new SelectListItem("14", "Profile_Num"));
            listGuncom.Add(new SelectListItem("15", "Profile_Date"));
            listGuncom.Add(new SelectListItem("16", "Price"));
            listGuncom.Add(new SelectListItem("17", "We_Date"));
            listGuncom.Add(new SelectListItem("18", "Action"));
            listGuncom.Add(new SelectListItem("19", "G47_Remarks"));
            listGuncom.Add(new SelectListItem("20", "G47_Date"));
            listGuncom.Add(new SelectListItem("21", "Del"));
            listGuncom.Add(new SelectListItem("22", "Del_Date"));

            return listGuncom;
        }

        public List<SelectListItem> sensorList()
        {
            List<SelectListItem> listSensor = new List<SelectListItem>() { };
            listSensor.Add(new SelectListItem("1", "Id"));
            listSensor.Add(new SelectListItem("2", "Sr_No"));
            listSensor.Add(new SelectListItem("3", "Make"));
            listSensor.Add(new SelectListItem("4", "Model"));
            listSensor.Add(new SelectListItem("5", "Base"));
            listSensor.Add(new SelectListItem("6", "Sub_Unit"));
            listSensor.Add(new SelectListItem("7", "Location"));
            listSensor.Add(new SelectListItem("8", "State"));
            listSensor.Add(new SelectListItem("9", "Date_Installed"));
            listSensor.Add(new SelectListItem("10", "Date_Modified"));
            listSensor.Add(new SelectListItem("11", "Remarks"));
            listSensor.Add(new SelectListItem("12", "User_Id"));
            listSensor.Add(new SelectListItem("13", "C_Date"));
            listSensor.Add(new SelectListItem("14", "Profile_Num"));
            listSensor.Add(new SelectListItem("15", "Profile_Date"));
            listSensor.Add(new SelectListItem("16", "Price"));
            listSensor.Add(new SelectListItem("17", "We_Date"));
            listSensor.Add(new SelectListItem("18", "Action"));
            listSensor.Add(new SelectListItem("19", "G47_Remarks"));
            listSensor.Add(new SelectListItem("20", "G47_Date"));
            listSensor.Add(new SelectListItem("21", "Del"));
            listSensor.Add(new SelectListItem("22", "Del_Date"));
            listSensor.Add(new SelectListItem("23", "Interface_Used"));
            return listSensor;
        }

        public List<SelectListItem> aisList()
        {
            List<SelectListItem> listAis = new List<SelectListItem>() { };
            listAis.Add(new SelectListItem("1", "Id"));
            listAis.Add(new SelectListItem("2", "Sr_No"));
            listAis.Add(new SelectListItem("3", "Make"));
            listAis.Add(new SelectListItem("4", "Model"));
            listAis.Add(new SelectListItem("5", "Base"));
            listAis.Add(new SelectListItem("6", "Sub_Unit"));
            listAis.Add(new SelectListItem("7", "Location"));
            listAis.Add(new SelectListItem("8", "State"));
            listAis.Add(new SelectListItem("9", "Date_Installed"));
            listAis.Add(new SelectListItem("10", "Date_Modified"));
            listAis.Add(new SelectListItem("11", "Remarks"));
            listAis.Add(new SelectListItem("12", "User_Id"));
            listAis.Add(new SelectListItem("13", "C_Date"));
            listAis.Add(new SelectListItem("14", "Profile_Num"));
            listAis.Add(new SelectListItem("15", "Profile_Date"));
            listAis.Add(new SelectListItem("16", "Price"));
            listAis.Add(new SelectListItem("17", "We_Date"));
            listAis.Add(new SelectListItem("18", "Action"));
            listAis.Add(new SelectListItem("19", "G47_Remarks"));
            listAis.Add(new SelectListItem("20", "G47_Date"));
            listAis.Add(new SelectListItem("21", "Del"));
            listAis.Add(new SelectListItem("22", "Del_Date"));
            listAis.Add(new SelectListItem("23", "Frequency_Band"));
            listAis.Add(new SelectListItem("24", "Power_Op"));
            listAis.Add(new SelectListItem("25", "Security"));
            listAis.Add(new SelectListItem("26", "Type"));
            listAis.Add(new SelectListItem("27", "Max_Detect_Range"));
            listAis.Add(new SelectListItem("28", "Antenna_Height"));
            return listAis;
        }

        public List<SelectListItem> epirbList()
        {
            List<SelectListItem> listEpirb = new List<SelectListItem>() { };
            listEpirb.Add(new SelectListItem("1", "Id"));
            listEpirb.Add(new SelectListItem("2", "Sr_No"));
            listEpirb.Add(new SelectListItem("3", "Make"));
            listEpirb.Add(new SelectListItem("4", "Model"));
            listEpirb.Add(new SelectListItem("5", "Base"));
            listEpirb.Add(new SelectListItem("6", "Sub_Unit"));
            listEpirb.Add(new SelectListItem("7", "Location"));
            listEpirb.Add(new SelectListItem("8", "State"));
            listEpirb.Add(new SelectListItem("9", "Date_Installed"));
            listEpirb.Add(new SelectListItem("10", "Date_Modified"));
            listEpirb.Add(new SelectListItem("11", "Remarks"));
            listEpirb.Add(new SelectListItem("12", "User_Id"));
            listEpirb.Add(new SelectListItem("13", "C_Date"));
            listEpirb.Add(new SelectListItem("14", "Profile_Num"));
            listEpirb.Add(new SelectListItem("15", "Profile_Date"));
            listEpirb.Add(new SelectListItem("16", "Price"));
            listEpirb.Add(new SelectListItem("17", "We_Date"));
            listEpirb.Add(new SelectListItem("18", "Action"));
            listEpirb.Add(new SelectListItem("19", "G47_Remarks"));
            listEpirb.Add(new SelectListItem("20", "G47_Date"));
            listEpirb.Add(new SelectListItem("21", "Del"));
            listEpirb.Add(new SelectListItem("22", "Del_Date"));
            listEpirb.Add(new SelectListItem("23", "MMSI_Reg"));
            listEpirb.Add(new SelectListItem("24", "Date_Inspection"));
            listEpirb.Add(new SelectListItem("25", "HRU_Rep_Date"));
            listEpirb.Add(new SelectListItem("26", "Battery_Expire_Date"));
            return listEpirb;
        }

        public List<SelectListItem> dvrList()
        {
            List<SelectListItem> listDvr = new List<SelectListItem>() { };
            listDvr.Add(new SelectListItem("1", "Id"));
            listDvr.Add(new SelectListItem("2", "Sr_No"));
            listDvr.Add(new SelectListItem("3", "Make"));
            listDvr.Add(new SelectListItem("4", "DVR_Model"));
            listDvr.Add(new SelectListItem("5", "Base"));
            listDvr.Add(new SelectListItem("6", "Sub_Unit"));
            listDvr.Add(new SelectListItem("7", "Location"));
            listDvr.Add(new SelectListItem("8", "DVR_Status"));
            listDvr.Add(new SelectListItem("9", "Date_Installed"));
            listDvr.Add(new SelectListItem("10", "Date_Modified"));
            listDvr.Add(new SelectListItem("11", "Remarks"));
            listDvr.Add(new SelectListItem("12", "User_Id"));
            listDvr.Add(new SelectListItem("13", "C_Date"));
            listDvr.Add(new SelectListItem("14", "DVR_Subitem_Type"));
            listDvr.Add(new SelectListItem("15", "DVR_Subitem_Sr_No"));
            listDvr.Add(new SelectListItem("16", "DVR_Subitem_State"));
            listDvr.Add(new SelectListItem("17", "DVR_Subitem_Make"));
            listDvr.Add(new SelectListItem("18", "DVR_Subitem_Model"));
            listDvr.Add(new SelectListItem("19", "G47_Remarks"));
            listDvr.Add(new SelectListItem("20", "G47_Date"));
            listDvr.Add(new SelectListItem("21", "Action"));

            return listDvr;
        }

        public List<SelectListItem> cctvList()
        {
            List<SelectListItem> listCCTV = new List<SelectListItem>() { };
            listCCTV.Add(new SelectListItem("1", "Id"));
            listCCTV.Add(new SelectListItem("2", "Sr_No"));
            listCCTV.Add(new SelectListItem("3", "Make"));
            listCCTV.Add(new SelectListItem("4", "Model"));
            listCCTV.Add(new SelectListItem("5", "Base"));
            listCCTV.Add(new SelectListItem("6", "Sub_Unit"));
            listCCTV.Add(new SelectListItem("7", "Location"));
            listCCTV.Add(new SelectListItem("8", "State"));
            listCCTV.Add(new SelectListItem("9", "Date_Installed"));
            listCCTV.Add(new SelectListItem("10", "Date_Modified"));
            listCCTV.Add(new SelectListItem("11", "Remarks"));
            listCCTV.Add(new SelectListItem("12", "User_Id"));
            listCCTV.Add(new SelectListItem("13", "C_Date"));
            listCCTV.Add(new SelectListItem("14", "System_Type"));
            listCCTV.Add(new SelectListItem("15", "System_Id"));
            listCCTV.Add(new SelectListItem("16", "Channels"));
            listCCTV.Add(new SelectListItem("17", "No_Of_Cameras"));
            listCCTV.Add(new SelectListItem("18", "Action"));
            listCCTV.Add(new SelectListItem("19", "G47_Remarks"));
            listCCTV.Add(new SelectListItem("20", "G47_Date"));
            listCCTV.Add(new SelectListItem("21", "Del"));
            listCCTV.Add(new SelectListItem("22", "Del_Date"));
            listCCTV.Add(new SelectListItem("23", "No_Of_Displays"));
            listCCTV.Add(new SelectListItem("24", "No_Of_HDD"));
            listCCTV.Add(new SelectListItem("25", "Type_Of_Cameras"));
            listCCTV.Add(new SelectListItem("26", "Type_Of_Displays"));
            listCCTV.Add(new SelectListItem("27", "Type_Of_HDD"));
            listCCTV.Add(new SelectListItem("28", "Warranty_Period"));

            return listCCTV;
        }

        public List<SelectListItem> eodsList()
        {
            List<SelectListItem> listEODS = new List<SelectListItem>() { };
            listEODS.Add(new SelectListItem("1", "Id"));
            listEODS.Add(new SelectListItem("2", "Sr_No"));
            listEODS.Add(new SelectListItem("3", "Make"));
            listEODS.Add(new SelectListItem("4", "Model"));
            listEODS.Add(new SelectListItem("5", "Base"));
            listEODS.Add(new SelectListItem("6", "Sub_Unit"));
            listEODS.Add(new SelectListItem("7", "Country"));
            listEODS.Add(new SelectListItem("8", "State"));
            listEODS.Add(new SelectListItem("9", "Date_Installed"));
            listEODS.Add(new SelectListItem("10", "Date_Modified"));
            listEODS.Add(new SelectListItem("11", "Remarks"));
            listEODS.Add(new SelectListItem("12", "User_Id"));
            listEODS.Add(new SelectListItem("13", "C_Date"));
            listEODS.Add(new SelectListItem("14", "Profile_Num"));
            listEODS.Add(new SelectListItem("15", "Profile_Date"));
            listEODS.Add(new SelectListItem("16", "Price"));
            listEODS.Add(new SelectListItem("17", "Pulse_Count"));
            listEODS.Add(new SelectListItem("18", "Action"));
            listEODS.Add(new SelectListItem("19", "G47_Remarks"));
            listEODS.Add(new SelectListItem("20", "G47_Date"));
            listEODS.Add(new SelectListItem("21", "Del"));
            listEODS.Add(new SelectListItem("22", "Del_Date"));

            return listEODS;
        }

        public List<SelectListItem> satCompassList()
        {
            List<SelectListItem> listSatCompass = new List<SelectListItem>() { };
            listSatCompass.Add(new SelectListItem("1", "Id"));
            listSatCompass.Add(new SelectListItem("2", "Sr_No"));
            listSatCompass.Add(new SelectListItem("3", "Make"));
            listSatCompass.Add(new SelectListItem("4", "Model"));
            listSatCompass.Add(new SelectListItem("5", "Base"));
            listSatCompass.Add(new SelectListItem("6", "Sub_Unit"));
            listSatCompass.Add(new SelectListItem("7", "Location"));
            listSatCompass.Add(new SelectListItem("8", "State"));
            listSatCompass.Add(new SelectListItem("9", "Date_Installed"));
            listSatCompass.Add(new SelectListItem("10", "Date_Modified"));
            listSatCompass.Add(new SelectListItem("11", "Remarks"));
            listSatCompass.Add(new SelectListItem("12", "User_Id"));
            listSatCompass.Add(new SelectListItem("13", "C_Date"));
            listSatCompass.Add(new SelectListItem("14", "Profile_Num"));
            listSatCompass.Add(new SelectListItem("15", "Profile_Date"));
            listSatCompass.Add(new SelectListItem("16", "Price"));
            listSatCompass.Add(new SelectListItem("17", "We_Date"));
            listSatCompass.Add(new SelectListItem("18", "Action"));
            listSatCompass.Add(new SelectListItem("19", "G47_Remarks"));
            listSatCompass.Add(new SelectListItem("20", "G47_Date"));
            listSatCompass.Add(new SelectListItem("21", "Del"));
            listSatCompass.Add(new SelectListItem("22", "Del_Date"));

            return listSatCompass;
        }

        public List<SelectListItem> satPhoneList()
        {
            List<SelectListItem> listSatPhone = new List<SelectListItem>() { };
            listSatPhone.Add(new SelectListItem("1", "Id"));
            listSatPhone.Add(new SelectListItem("2", "Sr_No"));
            listSatPhone.Add(new SelectListItem("3", "Make"));
            listSatPhone.Add(new SelectListItem("4", "Model"));
            listSatPhone.Add(new SelectListItem("5", "Base"));
            listSatPhone.Add(new SelectListItem("6", "Sub_Unit"));
            listSatPhone.Add(new SelectListItem("7", "Location"));
            listSatPhone.Add(new SelectListItem("8", "State"));
            listSatPhone.Add(new SelectListItem("9", "Date_Installed"));
            listSatPhone.Add(new SelectListItem("10", "Date_Modified"));
            listSatPhone.Add(new SelectListItem("11", "Remarks"));
            listSatPhone.Add(new SelectListItem("12", "User_Id"));
            listSatPhone.Add(new SelectListItem("13", "C_Date"));
            listSatPhone.Add(new SelectListItem("14", "Profile_Num"));
            listSatPhone.Add(new SelectListItem("15", "Profile_Date"));
            listSatPhone.Add(new SelectListItem("16", "Price"));
            listSatPhone.Add(new SelectListItem("17", "We_Date"));
            listSatPhone.Add(new SelectListItem("18", "Action"));
            listSatPhone.Add(new SelectListItem("19", "G47_Remarks"));
            listSatPhone.Add(new SelectListItem("20", "G47_Date"));
            listSatPhone.Add(new SelectListItem("21", "Del"));
            listSatPhone.Add(new SelectListItem("22", "Del_Date"));
            listSatPhone.Add(new SelectListItem("23", "In_SNo"));
            listSatPhone.Add(new SelectListItem("24", "Antenna_Sr_No"));
            listSatPhone.Add(new SelectListItem("25", "Receiver_Sr_No"));
            listSatPhone.Add(new SelectListItem("26", "Fax"));
            listSatPhone.Add(new SelectListItem("27", "Email"));
            listSatPhone.Add(new SelectListItem("28", "Data_Limit"));
            listSatPhone.Add(new SelectListItem("29", "IME_No"));
            listSatPhone.Add(new SelectListItem("30", "Expire_Date_Battery"));
            listSatPhone.Add(new SelectListItem("31", "Type"));
            listSatPhone.Add(new SelectListItem("32", "Voice"));

            return listSatPhone;
        }

        public List<SelectListItem> sartList()
        {
            List<SelectListItem> listSart = new List<SelectListItem>() { };
            listSart.Add(new SelectListItem("1", "Id"));
            listSart.Add(new SelectListItem("2", "Sr_No"));
            listSart.Add(new SelectListItem("3", "Make"));
            listSart.Add(new SelectListItem("4", "Model"));
            listSart.Add(new SelectListItem("5", "Base"));
            listSart.Add(new SelectListItem("6", "Sub_Unit"));
            listSart.Add(new SelectListItem("7", "Location"));
            listSart.Add(new SelectListItem("8", "State"));
            listSart.Add(new SelectListItem("9", "Date_Installed"));
            listSart.Add(new SelectListItem("10", "Date_Modified"));
            listSart.Add(new SelectListItem("11", "Remarks"));
            listSart.Add(new SelectListItem("12", "User_Id"));
            listSart.Add(new SelectListItem("13", "C_Date"));
            listSart.Add(new SelectListItem("14", "Profile_Num"));
            listSart.Add(new SelectListItem("15", "Profile_Date"));
            listSart.Add(new SelectListItem("16", "Price"));
            listSart.Add(new SelectListItem("17", "We_Date"));
            listSart.Add(new SelectListItem("18", "Action"));
            listSart.Add(new SelectListItem("19", "G47_Remarks"));
            listSart.Add(new SelectListItem("20", "G47_Date"));
            listSart.Add(new SelectListItem("21", "Del"));
            listSart.Add(new SelectListItem("22", "Del_Date"));
            listSart.Add(new SelectListItem("23", "Output_Power"));
            

            return listSart; 
        }

        public List<SelectListItem> speedLogList()
        {
            List<SelectListItem> listSpeedLog = new List<SelectListItem>() { };
            listSpeedLog.Add(new SelectListItem("1", "Id"));
            listSpeedLog.Add(new SelectListItem("2", "Sr_No"));
            listSpeedLog.Add(new SelectListItem("3", "Make"));
            listSpeedLog.Add(new SelectListItem("4", "Model"));
            listSpeedLog.Add(new SelectListItem("5", "Base"));
            listSpeedLog.Add(new SelectListItem("6", "Sub_Unit"));
            listSpeedLog.Add(new SelectListItem("7", "Location"));
            listSpeedLog.Add(new SelectListItem("8", "State"));
            listSpeedLog.Add(new SelectListItem("9", "Date_Installed"));
            listSpeedLog.Add(new SelectListItem("10", "Date_Modified"));
            listSpeedLog.Add(new SelectListItem("11", "Remarks"));
            listSpeedLog.Add(new SelectListItem("12", "User_Id"));
            listSpeedLog.Add(new SelectListItem("13", "C_Date"));
            listSpeedLog.Add(new SelectListItem("14", "Profile_Num"));
            listSpeedLog.Add(new SelectListItem("15", "Profile_Date"));
            listSpeedLog.Add(new SelectListItem("16", "Price"));
            listSpeedLog.Add(new SelectListItem("17", "We_Date"));
            listSpeedLog.Add(new SelectListItem("18", "Action"));
            listSpeedLog.Add(new SelectListItem("19", "G47_Remarks"));
            listSpeedLog.Add(new SelectListItem("20", "G47_Date"));
            listSpeedLog.Add(new SelectListItem("21", "Del"));
            listSpeedLog.Add(new SelectListItem("22", "Del_Date"));
            listSpeedLog.Add(new SelectListItem("23", "Output_Power"));


            return listSpeedLog;
        }

        public List<SelectListItem> anemometersList()
        {
            List<SelectListItem> listAnemometers = new List<SelectListItem>() { };
            listAnemometers.Add(new SelectListItem("1", "Id"));
            listAnemometers.Add(new SelectListItem("2", "Sr_No"));
            listAnemometers.Add(new SelectListItem("3", "Make"));
            listAnemometers.Add(new SelectListItem("4", "Model"));
            listAnemometers.Add(new SelectListItem("5", "Base"));
            listAnemometers.Add(new SelectListItem("6", "Sub_Unit"));
            listAnemometers.Add(new SelectListItem("7", "Location"));
            listAnemometers.Add(new SelectListItem("8", "State"));
            listAnemometers.Add(new SelectListItem("9", "Date_Installed"));
            listAnemometers.Add(new SelectListItem("10", "Date_Modified"));
            listAnemometers.Add(new SelectListItem("11", "Remarks"));
            listAnemometers.Add(new SelectListItem("12", "User_Id"));
            listAnemometers.Add(new SelectListItem("13", "C_Date"));
            listAnemometers.Add(new SelectListItem("14", "Profile_Num"));
            listAnemometers.Add(new SelectListItem("15", "Profile_Date"));
            listAnemometers.Add(new SelectListItem("16", "Price"));
            listAnemometers.Add(new SelectListItem("17", "We_Date"));
            listAnemometers.Add(new SelectListItem("18", "Action"));
            listAnemometers.Add(new SelectListItem("19", "G47_Remarks"));
            listAnemometers.Add(new SelectListItem("20", "G47_Date"));
            listAnemometers.Add(new SelectListItem("21", "Del"));
            listAnemometers.Add(new SelectListItem("22", "Del_Date"));
            listAnemometers.Add(new SelectListItem("23", "Output_Power"));


            return listAnemometers;
        }

        public List<SelectListItem> xenonSearchLightList()
        {
            List<SelectListItem> listXenonSearchLight = new List<SelectListItem>() { };
            listXenonSearchLight.Add(new SelectListItem("1", "Id"));
            listXenonSearchLight.Add(new SelectListItem("2", "Sr_No"));
            listXenonSearchLight.Add(new SelectListItem("3", "Make"));
            listXenonSearchLight.Add(new SelectListItem("4", "Model"));
            listXenonSearchLight.Add(new SelectListItem("5", "Base"));
            listXenonSearchLight.Add(new SelectListItem("6", "Sub_Unit"));
            listXenonSearchLight.Add(new SelectListItem("7", "Location"));
            listXenonSearchLight.Add(new SelectListItem("8", "State"));
            listXenonSearchLight.Add(new SelectListItem("9", "Date_Installed"));
            listXenonSearchLight.Add(new SelectListItem("10", "Date_Modified"));
            listXenonSearchLight.Add(new SelectListItem("11", "Remarks"));
            listXenonSearchLight.Add(new SelectListItem("12", "User_Id"));
            listXenonSearchLight.Add(new SelectListItem("13", "C_Date"));
            listXenonSearchLight.Add(new SelectListItem("14", "Profile_Num"));
            listXenonSearchLight.Add(new SelectListItem("15", "Profile_Date"));
            listXenonSearchLight.Add(new SelectListItem("16", "Price"));
            listXenonSearchLight.Add(new SelectListItem("17", "We_Date"));
            listXenonSearchLight.Add(new SelectListItem("18", "Action"));
            listXenonSearchLight.Add(new SelectListItem("19", "G47_Remarks"));
            listXenonSearchLight.Add(new SelectListItem("20", "G47_Date"));
            listXenonSearchLight.Add(new SelectListItem("21", "Del"));
            listXenonSearchLight.Add(new SelectListItem("22", "Del_Date"));
            listXenonSearchLight.Add(new SelectListItem("23", "Output_Power"));


            return listXenonSearchLight;
        }

        public List<SelectListItem> navtexList()
        {
            List<SelectListItem> listNavtex = new List<SelectListItem>() { };
            listNavtex.Add(new SelectListItem("1", "Id"));
            listNavtex.Add(new SelectListItem("2", "Sr_No"));
            listNavtex.Add(new SelectListItem("3", "Make"));
            listNavtex.Add(new SelectListItem("4", "Model"));
            listNavtex.Add(new SelectListItem("5", "Base"));
            listNavtex.Add(new SelectListItem("6", "Sub_Unit"));
            listNavtex.Add(new SelectListItem("7", "Location"));
            listNavtex.Add(new SelectListItem("8", "State"));
            listNavtex.Add(new SelectListItem("9", "Date_Installed"));
            listNavtex.Add(new SelectListItem("10", "Remarks"));
            listNavtex.Add(new SelectListItem("11", "User_Id"));
            listNavtex.Add(new SelectListItem("12", "C_Date"));
            listNavtex.Add(new SelectListItem("13", "We_Date"));
            listNavtex.Add(new SelectListItem("14", "Action"));
            listNavtex.Add(new SelectListItem("15", "G47_Remarks"));
            listNavtex.Add(new SelectListItem("16", "G47_Date"));
            listNavtex.Add(new SelectListItem("17", "Del"));
            listNavtex.Add(new SelectListItem("18", "Del_Date"));
            listNavtex.Add(new SelectListItem("19", "Profile_Num"));
            listNavtex.Add(new SelectListItem("20", "Profile_Date"));

            return listNavtex;
        }

        public List<SelectListItem> minisatList()
        {
            List<SelectListItem> listMinisat = new List<SelectListItem>() { };
            listMinisat.Add(new SelectListItem("1", "Id"));
            listMinisat.Add(new SelectListItem("2", "Sr_No"));
            listMinisat.Add(new SelectListItem("3", "Make"));
            listMinisat.Add(new SelectListItem("4", "Model"));
            listMinisat.Add(new SelectListItem("5", "Base"));
            listMinisat.Add(new SelectListItem("6", "Sub_Unit"));
            listMinisat.Add(new SelectListItem("7", "Location"));
            listMinisat.Add(new SelectListItem("8", "State"));
            listMinisat.Add(new SelectListItem("9", "Date_Installed"));
            listMinisat.Add(new SelectListItem("10", "Remarks"));
            listMinisat.Add(new SelectListItem("11", "User_Id"));
            listMinisat.Add(new SelectListItem("12", "C_Date"));
            listMinisat.Add(new SelectListItem("13", "Profile_Num"));
            listMinisat.Add(new SelectListItem("14", "Profile_Date"));
            listMinisat.Add(new SelectListItem("15", "We_Date"));
            listMinisat.Add(new SelectListItem("16", "Action"));
            listMinisat.Add(new SelectListItem("17", "G47_Remarks"));
            listMinisat.Add(new SelectListItem("18", "G47_Date"));
            listMinisat.Add(new SelectListItem("19", "Del"));
            listMinisat.Add(new SelectListItem("20", "Del_Date"));


            return listMinisat;
        }

        public List<SelectListItem> ecdisList()
        {
            List<SelectListItem> listECDIS = new List<SelectListItem>() { };
            listECDIS.Add(new SelectListItem("1", "Id"));
            listECDIS.Add(new SelectListItem("2", "Sr_No"));
            listECDIS.Add(new SelectListItem("3", "Make"));
            listECDIS.Add(new SelectListItem("4", "Model"));
            listECDIS.Add(new SelectListItem("5", "Base"));
            listECDIS.Add(new SelectListItem("6", "Sub_Unit"));
            listECDIS.Add(new SelectListItem("7", "Location"));
            listECDIS.Add(new SelectListItem("8", "State"));
            listECDIS.Add(new SelectListItem("9", "Date_Installed"));
            listECDIS.Add(new SelectListItem("10", "Remarks"));
            listECDIS.Add(new SelectListItem("11", "User_Id"));
            listECDIS.Add(new SelectListItem("12", "C_Date"));
            listECDIS.Add(new SelectListItem("13", "Profile_Num"));
            listECDIS.Add(new SelectListItem("14", "Profile_Date"));
            listECDIS.Add(new SelectListItem("15", "We_Date"));
            listECDIS.Add(new SelectListItem("16", "Action"));
            listECDIS.Add(new SelectListItem("17", "G47_Remarks"));
            listECDIS.Add(new SelectListItem("18", "G47_Date"));
            listECDIS.Add(new SelectListItem("19", "Del"));
            listECDIS.Add(new SelectListItem("20", "Del_Date"));


            return listECDIS;
        }
    }
}