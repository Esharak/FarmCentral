 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FarmCentral.Pages.Farmer
{
    public class EditModel : PageModel
    {
        public ProductInfo productInfo = new ProductInfo();
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
                    String sql = "SELECT * FROM FarmerProduct WHERE ID=@ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productInfo.ID = "" + reader.GetInt32(0);
                                productInfo.Name = reader.GetString(1);
                                productInfo.Description = reader.GetString(2);
                                productInfo.Price = reader.GetString(3);
                                productInfo.Quantity = reader.GetString(4);
                                productInfo.FarmerName = reader.GetString(5);
                                productInfo.FarmerPhone = reader.GetString(6);
                                productInfo.FarmerCell = reader.GetString(7);
                                productInfo.FarmerEmail = reader.GetString(8);

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
            productInfo.ID = Request.Form["ID"];
            productInfo.Name = Request.Form["Name"];
            productInfo.Description = Request.Form["Description"];
            productInfo.Price = Request.Form["Price"];
            productInfo.Quantity = Request.Form["Quantity"];
            productInfo.FarmerName = Request.Form["FarmerName"];
            productInfo.FarmerPhone = Request.Form["FarmerPhone"];
            productInfo.FarmerCell = Request.Form["FarmerCell"];
            productInfo.FarmerEmail = Request.Form["FarmerCell"];

            if (productInfo.ID.Length == 0 || productInfo.Name.Length == 0 ||
                productInfo.Description.Length == 0 || productInfo.Price.Length == 0 ||
                productInfo.Quantity.Length == 0 || productInfo.FarmerName.Length == 0 ||
                productInfo.FarmerPhone.Length == 0 || productInfo.FarmerCell.Length == 0 ||
                productInfo.FarmerEmail.Length == 0)

            {
                errorMessage = "All fields are required";
                return;
            }
            try
            {

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return; 
            }
            try
            {
                String connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProgData_st10091525;Integrated Security=True;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE FarmerProduct" +
                        "SET Name=@Name, Description=@Description, Price=@Price, Quantity=@Quantity, " +
                        "FarmerName=@FarmerName, FarmerPhone=@FarmerPhone, FarmerCell=@FarmerCell, FarmerEmail=@FarmerEmail" +
                        "WHERE ID=@ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", productInfo.Name);
                        command.Parameters.AddWithValue("@Description", productInfo.Description);
                        command.Parameters.AddWithValue("@Price", productInfo.Price);
                        command.Parameters.AddWithValue("@Quantity", productInfo.Quantity);
                        command.Parameters.AddWithValue("@FarmerName", productInfo.FarmerName);
                        command.Parameters.AddWithValue("@FarmerPhone", productInfo.FarmerPhone);
                        command.Parameters.AddWithValue("@FarmerCell", productInfo.FarmerCell);
                        command.Parameters.AddWithValue("@FarmerEmail", productInfo.FarmerEmail);
                        command.Parameters.AddWithValue("@ID", productInfo.ID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Farmer/Index");
        }
    }
}
