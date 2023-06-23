using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FarmCentral.Pages.FarmerLogin
{
    public class IndexModel : PageModel
    {
        public List<LoginFarmInfo> listLoginFarm = new List<LoginFarmInfo>();
        //(C# List Collection. 2023)
        public void OnGet()
        {
            try
            {
                String connectionString = "Server=tcp:esharak-sr.database.windows.net,1433;Initial Catalog=FarmDB;Persist Security Info=False;User ID=esharak;Password={Yourdoor80};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM LoginFarm";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LoginFarmInfo loginFarmInfo = new LoginFarmInfo();
                                loginFarmInfo.ID = "" + reader.GetInt32(0);
                                loginFarmInfo.Name = reader.GetString(1);
                                loginFarmInfo.Password = reader.GetString(2);


                                listLoginFarm.Add(loginFarmInfo);

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

    public class LoginFarmInfo
    {
        public string ID;
        public string Name;
        public string Password;


    }
}
//C# List Collection. 2023. C# List Collection. [ONLINE] Available
//at: https://www.tutorialsteacher.com/csharp/csharp-list. [Accessed 29 May 2023].