using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Models
{
    [Serializable]
    public class InputDeck
    {
        public InputDeck()
        {
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public string Version_Name { get; set; }
        public string Asset_Team { get; set; }
        public string Field { get; set; }
        public string Reservoir { get; set; }
        public string Drainage_Point { get; set; }
        public string Production_String { get; set; }
        public string Module { get; set; }
        public string PEEP_Project { get; set; }
        public string Activity_Entity { get; set; }
        public string Flow_station { get; set; }
        public string Hydrocarbon_Stream { get; set; }
        public string Resource_Class { get; set; }
        public string Change_Category { get; set; }
        public string Technique_1P { get; set; }
        public double URo_1P_1C { get; set; }
        public double URo_Low { get; set; }
        public double URo_2P_2C { get; set; }
        public double URo_3P_3C { get; set; }
        public double Np { get; set; }
        public double URg_1P_1C { get; set; }
        public double URg_Low { get; set; }
        public double URg_2P_2C { get; set; }
        public double URg_3P_3C { get; set; }
        public double Gp { get; set; }
        public double Init_Oil_Gas_Rate_1P_1C { get; set; }
        public double Init_Oil_Gas_Rate_Low { get; set; }
        public double Init_Oil_Gas_Rate_2P_2C { get; set; }
        public double Init_Oil_Gas_Rate_3P_3C { get; set; }
        public double Aband_Oil_Gas_Rate_1P_1C { get; set; }
        public double Aband_Oil_Gas_Rate_2P_2C { get; set; }
        public double Aband_Oil_Gas_Rate_3P_3C { get; set; }
        public double Init_BSW_WGR { get; set; }
        public double Aband_BSW_WGR_1P_1C { get; set; }
        public double Aband_BSW_WGR_2P_2C { get; set; }
        public double Aband_BSW_WGR_3P_3C { get; set; }
        public double Init_GOR_CGR { get; set; }
        public double Aband_GOR_CGR_1P_1C { get; set; }
        public double Aband_GOR_CGR_2P_2C { get; set; }
        public double Aband_GOR_CGR_3P_3C { get; set; }
        public double lift_Gas_Rate { get; set; }
        public double Plateau_Oil_Gas { get; set; }
        public string In_year_Booking { get; set; }
        public string LE_LV { get; set; }
        public string PRCS { get; set; }
        public string On_stream_Date_1P_1C { get; set; }
        public string On_stream_Date_2P_2C { get; set; }
        public string On_stream_Date_3P_3C { get; set; }
        public string Remarks { get; set; }
        public string TRANCHE { get; set; }
        public Guid InputDeckId { get; set; }
    }
}
