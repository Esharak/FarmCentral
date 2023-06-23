using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FarmCentral.Pages.EmployeeLogin
{
    public class IndexModel : PageModel
    {
        public List<LoginEmpInfo> listLoginEmp = new List<LoginEmpInfo>();

        //(C# List Collection)
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProgData_st10091525;Integrated Security=True;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM LoginEmp";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LoginEmpInfo loginEmpInfo = new LoginEmpInfo();
                                loginEmpInfo.ID = "" + reader.GetInt32(0);
                                loginEmpInfo.Name = reader.GetString(1);
                                loginEmpInfo.Password = reader.GetString(2);
                               

                                listLoginEmp.Add(loginEmpInfo);

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

    public class LoginEmpInfo
    {
        public string ID;
        public string Name;
        public string Password;
        

    }
}
//C# List Collection. 2023. C# List Collection. [ONLINE] Available
//at: https://www.tutorialsteacher.com/csharp/csharp-list. [Accessed 29 May 2023].