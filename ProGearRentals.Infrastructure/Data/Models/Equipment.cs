
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;    
using System.ComponentModel.DataAnnotations.Schema;
using static ProGearRentals.Infrastructure.Constants.DataConstants;

namespace ProGearRentals.Infrastructure.Data.Models
{

    [Comment("Equipment to rent")]
    public class Equipment
    {
        [Key]
        [Comment("Equipment Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EquipmentTitleMaxLenght)]
        [Comment("Equipment Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(EqipmentDescriptionMaxLenght)]
        [Comment("Equipment Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Equipment image Url")]

        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Monthfly Price")]
        [Column(TypeName = "decimal(18,2)")]
        //[Range(typeof(decimal), EquipmentRentingPriceMinimum, EquipmentRentingPriceMaximum, ConvertValueInInvariantCulture = true)]
        public decimal PricePerMonth { get;set; }

        [Required]
        [Comment("Category Identifier")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("Agent Identifier")] 
        public int AgentId { get; set; }

        [Required]
        [Comment("User id of the renterer")]
        public string? RenterId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<Review> Reviews { get; set; } = new List<Review>(); 





    }
}