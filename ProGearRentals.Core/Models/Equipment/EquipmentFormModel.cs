using ProGearRentals.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static ProGearRentals.Core.Constants.MessageConstants;
using static ProGearRentals.Infrastructure.Constants.DataConstants;
namespace ProGearRentals.Core.Models.Equipment
{
	public class EquipmentFormModel : IEquipmentModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(EquipmentTitleMaxLenght,
			MinimumLength = EquipmentTitleMinLenght,
			ErrorMessage = LengthMessage)]
		public string Title { get;  set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(EqipmentDescriptionMaxLenght,
			MinimumLength = EqipmentDescriptionMinLenght,
			ErrorMessage = LengthMessage)]
		public string Description { get; set; } = null!;


		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name ="Image URL")]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Range(typeof(decimal),EquipmentRentingPriceMinimum,
			EquipmentRentingPriceMaximum,ConvertValueInInvariantCulture = true,
			ErrorMessage = "Price per month must be a positive number and less than {2} leva.")]
		[Display(Name = "Price Per Month")]
		public decimal PricePerMonth { get; set; }

		[Display(Name = "Category")]
		public int CategoryId { get; set; }


		public IEnumerable<EquipmentCategoryServiceModel> Categories = new List<EquipmentCategoryServiceModel>();
	}

}
