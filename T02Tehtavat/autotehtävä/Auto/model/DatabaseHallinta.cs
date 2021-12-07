
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Autokauppa.model
{
    public class DatabaseHallinta
    {
        string yhteysTiedot;
        SqlConnection dbYhteys;


        public DatabaseHallinta()
        {
            yhteysTiedot = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Autokauppa; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        }

        public bool connectDatabase()
        {
            //Yhteyden testaus tietokantaan
            dbYhteys = new SqlConnection();
            dbYhteys.ConnectionString = yhteysTiedot;

            try
            {
                dbYhteys.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Virheilmoitukset:" + e);
                dbYhteys.Close();
                return false;

            }

        }

        public void disconnectDatabase()
        {
            dbYhteys.Close();
        }

        public bool saveAutoIntoDatabase(Auto newAuto)
        {
            bool palaute = false;
            return palaute;

        }

       public class AutonMerkki
        {
            public int Id { get; set; }
            public string MerkkiNimi { get; set; }

        }
        public class AutonMalli
        {
            public int Id { get; set; }
            public string MalliNimi { get; set; }
            public int MerkkiId { get; set; }
        }



        public List<AutonMerkki> getAllAutoMakersFromDatabase()
        //Hakee tietokannasta kaikki auton merkit ja palauttaa listan valmistaja luokasta
        {
            List <AutonMerkki> palaute= new List<AutonMerkki>();
            AutonMerkki autonMerkki = new AutonMerkki();
            
        
                // Lisätään listaan tietokannassa olevat autonmerkit 
                string query = "SELECT ID,Merkki FROM AutonMerkki";
            connectDatabase();
            using (SqlCommand cmd = new SqlCommand(query, dbYhteys))
                       {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                           {
                               while (reader.Read())
                               {
                                   palaute.Add(new AutonMerkki
                                   {
                                       Id = Convert.ToInt32(reader["ID"]),
                                       MerkkiNimi = reader["Merkki"].ToString()
                                   });
                               }
                           }
                       }
           
            return palaute;
        }

        public List<AutonMalli> getAutoModelsByMakerId(int makerId)
        //Hakee tietyn automerkin kaikki mallit ja palauttaa mallit listana kun merkkion valittu comboboxissa
        {
            List<AutonMalli> palaute = new List<AutonMalli>();
            AutonMalli autonMalli = new AutonMalli();

            string query = "SELECT ID,Auton_mallin_nimi FROM AutonMallit WHERE AutonMerkkiID = "+ makerId;
            connectDatabase();
            using (SqlCommand cmd = new SqlCommand(query, dbYhteys))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        palaute.Add(new AutonMalli
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            MalliNimi = reader["Auton_mallin_nimi"].ToString()
                        });
                    }
                }
            }
            return palaute;
        }
    }
}
