using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

using System.Xml.Linq;

namespace Register_ado.Models
{
    public class Form
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
   
        public string Email { get; set; }
        public string Hobbies { get; set; }

        public string Department { get; set; }
    
        public string Designation { get; set; }
     
        public string Password { get; set; }
    
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public List<string> Hobbieslist { get; set; }

     
    }
}
