using System.ComponentModel.DataAnnotations;

namespace ProGearRentals.Core.Models.Agent
{
    public class AgentServiceModel
    {

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;



    }
}