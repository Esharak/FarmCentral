using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FarmCentral.Pages.Employee
{
    public class CreateModel : PageModel
    {
        public FarmerInfo farmerInfo = new FarmerInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            farmerInfo.Name = Request.Form["Name"];
            farmerInfo.Surname = Request.Form["Surname"];
            farmerInfo.TradingName = Request.Form["TradingName"];
            farmerInfo.Address = Request.Form["Address"];
            farmerInfo.Phone = Request.Form["Phone"];
            farmerInfo.Cellphone = Request.Form["Cellphone"];
            farmerInfo.Email = Request.Form["Email"];

            if(farmerInfo.Name.Length == 0 || 
               farmerInfo.Surname.Length == 0 ||
               farmerInfo.TradingName.Length == 0 ||
               farmerInfo.Address.Length == 0||
               farmerInfo.Phone.Length == 0 ||
               farmerInfo.Cellphone.Length == 0||
               farmerInfo.Email.Length == 0
               )
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
                    String sql = "INSERT INTO AddFarmer" +
                                 "(Name, Surname, TradingName, Address, Phone, Cellphone, Email) Values " +
                                 "(@Name, @Surname, @TradingName, @Address, @Phone, @Cellphone, @Email);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", farmerInfo.Name);
                        command.Parameters.AddWithValue("@Surname", farmerInfo.Surname);
                        command.Parameters.AddWithValue("@TradingName", farmerInfo.TradingName);
                        command.Parameters.AddWithValue("@Address", farmerInfo.Address);
                        command.Parameters.AddWithValue("@Phone", farmerInfo.Phone);
                        command.Parameters.AddWithValue("@Cellphone", farmerInfo.Cellphone);
                        command.Parameters.AddWithValue("@Email", farmerInfo.Email);

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

            farmerInfo.Name = ""; 
            farmerInfo.Surname = "";
            farmerInfo.TradingName = "";
            farmerInfo.Address = "";
            farmerInfo.Phone = "";
            farmerInfo.Cellphone = "";
            farmerInfo.Email = "";

            successMessage = "New Farmer added Successfully";

            Response.Redirect("/Employee/Index");
        }
    }
}
//(Rick-Anderson. 2022)
//Rick-Anderson. 2022. Introduction to Working with a Database in ASP.NET Web Pages (Razor) Sites | Microsoft Learn. [ONLINE]
//Available at: https://learn.microsoft.com/en-us/aspnet/web-pages/overview/data/5-working-with-data.
//[Accessed 29 May 2023].