using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using Register_ado.Models;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Register_ado.Controllers
{
    [Authorize]
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult GetAll()
        {

            //
            // List<string> hobbies = form.Hobbies.Split(',').ToList();

            //var draw = Request.Form["draw"].FirstOrDefault();
           
            int filterrecords = 0;
          
            List<Form> forms = new List<Form>();
            var dbconfig = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json").Build();
            string dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(dbconnectionStr))
            {
                string sql = "spserver";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    int DisplayLength = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
                    int DisplayStart = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
                    var SortCol = Request.Form["order[0][column]"].FirstOrDefault();
                    var SortDir = Request.Form["order[0][dir]"].FirstOrDefault();
                    var Search = Request.Form["search[value]"].FirstOrDefault();
                   
                    cmd.Parameters.AddWithValue("@DisplayLength",DisplayLength );
                    cmd.Parameters.AddWithValue("@DisplayStart", DisplayStart);
                    cmd.Parameters.AddWithValue("@SortCol", SortCol);
                    cmd.Parameters.AddWithValue("@SortDir", SortDir);
                    cmd.Parameters.AddWithValue("@Search", Search);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    {
                        while (rdr.Read())
                        {
                            Form form1 = new Form();
                            form1.Id =Convert.ToInt32(rdr["id"]);
                            form1.Name = rdr["name"].ToString();
                            form1.Email = rdr["email"].ToString();
                            form1.Hobbies= rdr["hobbies"].ToString();
                            form1.Department = rdr["department"].ToString();
                            form1.Designation = rdr["designation"].ToString();
                            forms.Add(form1);
                 
                         
                            filterrecords = Convert.ToInt32(rdr["TotalCount"]);
                           
                        }
                      
                    }
                  
                    connection.Close();
                }
              
            }
            return Json(new { recordsFiltered = filterrecords, /*draw = draw,*/ data = forms });          
        }


        public IActionResult updateuser(int id)
        {
            
            //ViewBag.SelectHobbyList = GethobbyList();
            List<Form> forms = new List<Form>();
            var dbconfig = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json").Build();
            string dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(dbconnectionStr))
            {
                string sql = "edituser";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                   
                    SqlDataReader rdr = cmd.ExecuteReader();
                    {
                        while (rdr.Read())
                        {
                            Form form1 = new Form();
                            form1.Id = Convert.ToInt32(rdr["id"]);
                            form1.Name = rdr["name"].ToString();
                            form1.Email = rdr["email"].ToString();
                            form1.Hobbies = rdr["hobbies"].ToString();
                            form1.Department = rdr["department"].ToString();
                            form1.Designation = rdr["designation"].ToString();
                            
                            forms.Add(form1);
                        }

                    }
                  // form.Hobbieslist = form.Hobbies.ToList();
                    connection.Close();
                }

            }
            return Json(new { data = forms });
           
        }

        [HttpPost]
        public IActionResult updateuser(Form form)
        {
           // form.Hobbies = string.Join(",", form.Hobbieslist);
            //  form.Hobbies = hobbies;

            if (!ModelState.IsValid)
            {

                var dbconfig = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();
                if (!string.IsNullOrEmpty(dbconfig.ToString()))
                {
                    string dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
                    using (SqlConnection connection = new SqlConnection(dbconnectionStr))
                    {
                        string sql = "updateinfo";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@userId",form.Id);
                            cmd.Parameters.AddWithValue("@name", form.Name);
                            cmd.Parameters.AddWithValue("@email", form.Email);
                            cmd.Parameters.AddWithValue("@hobbies", form.Hobbies);
                            cmd.Parameters.AddWithValue("@department", form.Department);
                            cmd.Parameters.AddWithValue("@designation", form.Designation);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
            }
            return RedirectToAction("Login", "Form");
        }
    
        public IActionResult Index()
        {
           // ViewBag.SelectHobbyList = GethobbyList();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       

           
    }
}



























































//if (!string.IsNullOrEmpty(Search))
//{
//    forms = forms.Where(x => x.Name.ToLower().Contains(Search.ToLower()) || x.Email.ToLower().Contains(Search.ToLower()) || x.Department.ToLower().Contains(Search.ToLower()) || x.Designation.ToString().ToLower().Contains(Search.ToLower())).ToList<Form>();
//}
