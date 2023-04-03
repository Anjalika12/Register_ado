using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Register_ado.Models;
using System.Data;
using System.Security.Claims;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Runtime.ConstrainedExecution;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection.Metadata;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Register_ado.Controllers
{
  
    public class FormController : Controller
    {
        private IConfiguration _configuration;
        public FormController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
 
            List<Form> forms = new List<Form>();
            var dbconfig = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json").Build();
            string dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(dbconnectionStr))
            {
                string sql = "RetrieveSp";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    {
                        while (rdr.Read())
                        {
                            Form form1 = new Form();
                            form1.Name = rdr["name"].ToString();
                            form1.Email = rdr["email"].ToString();
                           // form1.Hobbies = rdr["hobbies"].ToString();
                            form1.Department = rdr["department"].ToString();
                            form1.Designation = rdr["designation"].ToString();
                            forms.Add(form1);
                        }
                    
                    }
                    connection.Close();
                }
               
            }
            return View(forms);
        }
        public IActionResult Create()
        {
            Form form = new Form();
            // form.Hobbieslist = GethobbyList().ToList();
            ViewBag.SelectHobbyList = GethobbyList();

            return View(form);

        }
        [HttpPost]
        public IActionResult Create(Form form,string data)
        
        {
        
            form.Hobbies = string.Join(",", form.Hobbieslist);
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
                        string sql = "Savesp";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@name", form.Name);
                            cmd.Parameters.AddWithValue("@email", form.Email);
                            cmd.Parameters.AddWithValue("@hobbies", form.Hobbies);
                            cmd.Parameters.AddWithValue("@department", form.Department);
                            cmd.Parameters.AddWithValue("@designation", form.Designation);
                            cmd.Parameters.AddWithValue("@password", form.Password);
                            cmd.Parameters.AddWithValue("@confirmpassword", form.ConfirmPassword);
                                    connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
            }
            return RedirectToAction("Login", "Form");
        }

        public List<SelectListItem> GethobbyList()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Text = "Singing", Value = "Singing" });
            selectListItems.Add(new SelectListItem { Text = "Dancing", Value = "Dancing" });
            selectListItems.Add(new SelectListItem { Text = "Reading", Value = "Reading" });
            selectListItems.Add(new SelectListItem { Text = "Yoga", Value = "Yoga" });
            return selectListItems;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Form form)
        {

            string sqlcon = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(sqlcon);
                con.Open();
            SqlCommand cm = new SqlCommand("select * from Form where email= @email and password= @pass", con);
            cm.Parameters.Add("@email", SqlDbType.VarChar).Value = form.Email;
            cm.Parameters.Add("@pass", SqlDbType.VarChar).Value = form.Password;
            
                SqlDataReader rdr = cm.ExecuteReader();
                {
               
                    while (rdr.Read())
                    {
                        form.Department = rdr["department"].ToString();
                        form.Designation = rdr["designation"].ToString();
                    }
                    con.Close();
               
            }
                if(form.Department!=null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim("department", form.Department));
                    claims.Add(new Claim("designation", form.Designation));
                    var claimsIdentity = new ClaimsIdentity(claims, "Login");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }

            else
                {
                return BadRequest("Enter valid Credentials");
                }
            
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
     
    }
}







     