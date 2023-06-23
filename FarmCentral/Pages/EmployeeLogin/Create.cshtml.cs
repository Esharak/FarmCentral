using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace FarmCentral.Pages.EmployeeLogin
{
    public class CreateModel : PageModel
    {
        public LoginEmpInfo loginEmpInfo = new LoginEmpInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            loginEmpInfo.Name = Request.Form["Name"];
            loginEmpInfo.Password = Request.Form["Password"];
           

          
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
                    String sql = "INSERT INTO LoginEmp" +
                                 "(Name, Password) Values " +
                                 "(@Name, @Password);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", loginEmpInfo.Name);
                        command.Parameters.AddWithValue("@Password", loginEmpInfo.Password);
                       

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            loginEmpInfo.Name = "";
            loginEmpInfo.Password = "";
           

            Response.Redirect("/Employee/Index");
        }
    }
}
