using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient; 

namespace FarmCentral.Pages.Farmer
{
    public class CreateModel : PageModel
    {
        public ProductInfo productInfo = new ProductInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            productInfo.Name = Request.Form["Name"];
            productInfo.Description = Request.Form["Description"];
            productInfo.Price = Request.Form["Price"];
            productInfo.Quantity = Request.Form["Quantity"];
            productInfo.FarmerName = Request.Form["FarmerName"];
            productInfo.FarmerPhone = Request.Form["FarmerPhone"];
            productInfo.FarmerCell = Request.Form["FarmerCell"];
            productInfo.FarmerEmail = Request.Form["FarmerEmail"];

            if (productInfo.Name.Length == 0 ||
                productInfo.Description.Length == 0 ||
                productInfo.Price.Length == 0 ||
                productInfo.Quantity.Length == 0 ||
                productInfo.FarmerName.Length == 0 ||
                productInfo.FarmerPhone.Length == 0 ||
                productInfo.FarmerCell.Length == 0 ||
                productInfo.FarmerEmail.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            //save the new product data into the database
            try
            {
                String connectionString = "Server=tcp:esharak-sr.database.windows.net,1433;Initial Catalog=FarmDB;Persist Security Info=False;User ID=esharak;Password={Yourdoor80};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO FarmerProduct" +
                                 "(Name, Description, Price, Quantity, FarmerName, FarmerPhone, FarmerCell, " +
                                 "FarmerEmail) Values " +
                                 "(@Name, @Description, @Price, @Quantity, @FarmerName, @FarmerPhone," +
                                 " @FarmerCell, @FarmerEmail);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", productInfo.Name);
                        command.Parameters.AddWithValue("@Description", productInfo.Description);
                        command.Parameters.AddWithValue("@Price", productInfo.Price);
                        command.Parameters.AddWithValue("@Quantity", productInfo.Quantity);
                        command.Parameters.AddWithValue("@FarmerName", productInfo.FarmerName);
                        command.Parameters.AddWithValue("@FarmerPhone", productInfo.FarmerPhone);
                        command.Parameters.AddWithValue("@FarmerCell", productInfo.FarmerCell);
                        command.Parameters.AddWithValue("@FarmerEmail ", productInfo.FarmerEmail);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            productInfo.Name = "";
            productInfo.Description = "";
            productInfo.Price = "";
            productInfo.Quantity = "";
            productInfo.FarmerName = "";
            productInfo.FarmerPhone = "";
            productInfo.FarmerCell = "";
            productInfo.FarmerEmail = "";

            successMessage = "New Product Added Successfully!";

            Response.Redirect("/Farmer/Index");
        }
    }
}
