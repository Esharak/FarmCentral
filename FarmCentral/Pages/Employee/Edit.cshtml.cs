using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FarmCentral.Pages.Employee
{
    public class EditModel : PageModel
    {
        public FarmerInfo farmerInfo = new FarmerInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String ID = Request.Query["ID"];

            try
            {
                String connectionString = "Server=tcp:esharak-sr.database.windows.net,1433;Initial Catalog=FarmDB;Persist Security Info=False;User ID=esharak;Password={Yourdoor80};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM AddFarmer WHERE ID=@ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                farmerInfo.ID = "" + reader.GetInt32(0);
                                farmerInfo.Name = reader.GetString(1);
                                farmerInfo.Surname = reader.GetString(2);
                                farmerInfo.TradingName = reader.GetString(3);
                                farmerInfo.Address = reader.GetString(4);
                                farmerInfo.Phone = reader.GetString(5);
                                farmerInfo.Cellphone = reader.GetString(6);
                                farmerInfo.Email = reader.GetString(7);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            farmerInfo.ID = Request.Form["ID"];
            farmerInfo.Name = Request.Form["Name"];
            farmerInfo.Surname = Request.Form["Surname"];
            farmerInfo.TradingName = Request.Form["TradingName"];
            farmerInfo.Address = Request.Form["Address"];
            farmerInfo.Phone = Request.Form["Phone"];
            farmerInfo.Cellphone = Request.Form["Cellphone"];
            farmerInfo.Email = Request.Form["Email"];

            if (farmerInfo.ID.Length == 0 || farmerInfo.Name.Length == 0 ||
                farmerInfo.Surname.Length == 0 || farmerInfo.TradingName.Length == 0 ||
                farmerInfo.Address.Length == 0 || farmerInfo.Phone.Length == 0 ||
                farmerInfo.Cellphone.Length == 0 || farmerInfo.Email.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }

            try
            {
                String connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProgData_st10091525;Integrated Security=True;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE AddFarmer" +
                        "SET Name=@Name, Surname=@Surname, TradingName=@TradingName, Address=@Address, " +
                        "Phone=@Phone, Cellphone=@Cellphone, Email=@Email" +
                        "WHERE ID=@ID";

                    //(Guru99. 2022)

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", farmerInfo.Name);
                        command.Parameters.AddWithValue("@Surname", farmerInfo.Surname);
                        command.Parameters.AddWithValue("@TradingName", farmerInfo.TradingName);
                        command.Parameters.AddWithValue("@Address", farmerInfo.Address);
                        command.Parameters.AddWithValue("@Phone", farmerInfo.Phone);
                        command.Parameters.AddWithValue("@Cellphone", farmerInfo.Cellphone);
                        command.Parameters.AddWithValue("@Email", farmerInfo.Email);
                        command.Parameters.AddWithValue("@ID", farmerInfo.ID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Employee/Index");
        }
    }
}
//(Guru99. 2022)
//Guru99. 2022. Insert, Update, Delete: ASP.NET Database Connection Tutorial. [ONLINE]
//Available at: https://www.guru99.com/insert-update-delete-asp-net.html.
//[Accessed 29 May 2023].