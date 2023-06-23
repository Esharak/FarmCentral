using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FarmCentral.Pages.Employee
{
    public class IndexModel : PageModel
    {
        public List<FarmerInfo> listFarmers = new List<FarmerInfo>();
        //(C# List Collection)
        public void OnGet()
        {
            try
            {
                String connectionString = "Server=tcp:esharak-sr.database.windows.net,1433;Initial Catalog=FarmDB;Persist Security Info=False;User ID=esharak;Password={Yourdoor80};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM AddFarmer";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FarmerInfo farmerInfo = new FarmerInfo();
                                farmerInfo.ID = "" + reader.GetInt32(0);
                                farmerInfo.Name = reader.GetString(1);
                                farmerInfo.Surname = reader.GetString(2);
                                farmerInfo.TradingName = reader.GetString(3);
                                farmerInfo.Address = reader.GetString(4);
                                farmerInfo.Phone = reader.GetString(5);
                                farmerInfo.Cellphone = reader.GetString(6);
                                farmerInfo.Email = reader.GetString(7);
                                farmerInfo.Created_at = reader.GetDateTime(8).ToString();

                                listFarmers.Add(farmerInfo);

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

        }
    }

    public class FarmerInfo
    {
        public string ID;
        public string Name;
        public string Surname;
        public string TradingName;
        public string Address;
        public string Phone;
        public string Cellphone;
        public string Email;
        public string Created_at;

    }
}
//C# List Collection. 2023. C# List Collection. [ONLINE] Available
//at: https://www.tutorialsteacher.com/csharp/csharp-list. [Accessed 29 May 2023].