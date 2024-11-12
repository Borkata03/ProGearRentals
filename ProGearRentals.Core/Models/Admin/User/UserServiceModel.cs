using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Models.Admin.UserServiceModel
{
    public class UserServiceModel
    {
        public string Email { get; set; } = null!;

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;   
        
        public bool IsAgent {  get; set; }  
    }
}
