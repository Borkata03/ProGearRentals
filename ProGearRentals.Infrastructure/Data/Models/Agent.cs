using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ProGearRentals.Infrastructure.Constants.DataConstants;

namespace ProGearRentals.Infrastructure.Data.Models
{

    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Comment("Equipment Agent")]
    public class Agent
    {
        [Key]
        [Comment("Agent identifier")]
        public int Id { get; set; }


        [Required]
        [MaxLength(AgentPhoneNumberMaxLength)]
        [Comment("Agent's Phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public List<Equipment> Equipments { get; set; } = null!; 
        


    }
}