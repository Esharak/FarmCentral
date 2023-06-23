using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FarmCentral.Pages.View
{
    public class IndexViewModel : PageModel
    {
        public List<ProductInfo> listProducts = new List<ProductInfo>();
        //(C# List Collection. 2023)
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProgData_st10091525;Integrated Security=True;Pooling=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM FarmerProduct ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductInfo productInfo = new ProductInfo();
                                productInfo.ID = "" + reader.GetInt32(0);
                                productInfo.Name = reader.GetString(1);
                                productInfo.Description = reader.GetString(2);
                                productInfo.Price = reader.GetString(3);
                                productInfo.Quantity = reader.GetString(4);
                                productInfo.FarmerName = reader.GetString(5);
                                productInfo.FarmerPhone = reader.GetString(6);
                                productInfo.FarmerCell = reader.GetString(7);
                                productInfo.FarmerEmail = reader.GetString(8);
                                productInfo.Created_at = reader.GetDateTime(9).ToString();

                                listProducts.Add(productInfo);
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

    public class ProductInfo
    {
        public String ID;
        public String Name;
        public String Description;
        public String Price;
        public String Quantity;
        public String FarmerName;
        public String FarmerPhone;
        public String FarmerCell;
        public String FarmerEmail;
        public String Created_at;

    }
}
//C# List Collection. 2023. C# List Collection. [ONLINE] Available
//at: https://www.tutorialsteacher.com/csharp/csharp-list. [Accessed 29 May 2023].