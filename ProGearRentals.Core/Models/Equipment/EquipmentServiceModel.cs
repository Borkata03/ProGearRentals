using System.ComponentModel.DataAnnotations;
using static ProGearRentals.Core.Constants.MessageConstants;
using static ProGearRentals.Infrastructure.Constants.DataConstants;

namespace ProGearRentals.Core.Models.Equipment
{
    public class EquipmentServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EquipmentTitleMaxLenght,
            MinimumLength = EquipmentTitleMinLenght,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), EquipmentRentingPriceMinimum,
            EquipmentRentingPriceMaximum, ConvertValueInInvariantCulture = true,
            ErrorMessage = "Price per month must be a positive number and less than {2} leva.")]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "is Rented")]
        public bool IsRented { get; set; }
    }
}