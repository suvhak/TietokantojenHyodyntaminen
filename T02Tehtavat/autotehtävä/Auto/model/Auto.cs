using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Autokauppa.model
{
    public class Auto
    {
        //Attribuutit sekä niiden get set
        public int id { get; set; }
        public decimal hinta { get; set; }
        public DateTime rekisteri_paivamaara { get; set; }
        public decimal moottorin_tilavuus { get; set; }
        public int mittarilukema { get; set; }
        public int autonmerkkiId { get; set; }
        public int autonmalliId { get; set; }
        public int varitId { get; set; }
        public int polttoaineId { get; set; }

    }
    
    public class AutonMerkki
    {
        public int id { get; set; }
        public string merkkiNimi { get; set; }
    }
    public class AutonMalli
    {
        public int id { get; set; }
        public string malliNimi { get; set; }
        public int merkkiId { get; set; }
    }


}
