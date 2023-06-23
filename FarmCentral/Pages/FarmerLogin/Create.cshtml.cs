using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FarmCentral.Pages.FarmerLogin
{
    public class CreateModel : PageModel
    {
        public LoginFarmInfo loginFarmInfo = new LoginFarmInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            loginFarmInfo.Name = Request.Form["Name"];
            loginFarmInfo.Password = Request.Form["Password"];



            {
                errorMessage = "All the fields are required";
                return;
            }

            //save the new farmer into the database
            try
            {
                String connectionString = "Server=tcp:esharak-sr.database.windows.net,1433;Initial Catalog=FarmDB;Persist Security Info=False;User ID=esharak;Password={Yourdoor80};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO LoginFarm" +
                                 "(Name, Password) Values " +
                                 "(@Name, @Password);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", loginFarmInfo.Name);
                        command.Parameters.AddWithValue("@Password", loginFarmInfo.Password);


                        command.ExecuteNonQuery();
                        //(Rick-Anderson. 2022)
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            loginFarmInfo.Name = "";
            loginFarmInfo.Password = "";


            Response.Redirect("/Farmer/Index");
        }
    }
}
//(Rick-Anderson. 2022)
//Rick-Anderson. 2022. Introduction to Working with a Database in ASP.NET Web Pages (Razor) Sites | Microsoft Learn. [ONLINE]
//Available at: https://learn.microsoft.com/en-us/aspnet/web-pages/overview/data/5-working-with-data.
//[Accessed 29 May 2023].