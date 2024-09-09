using System.ComponentModel.DataAnnotations;
using static ProGearRentals.Core.Constants.MessageConstants;
using static ProGearRentals.Infrastructure.Constants.DataConstants;

namespace ProGearRentals.Core.Models.Agent
{
	public class BecomeAgentFormModel
	{
		[Required(ErrorMessage = (RequiredMessage))]
		[StringLength(AgentPhoneNumberMaxLength,
		    MinimumLength = AgentPhoneNumberMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Phone Number")]
		[Phone]
		public string PhoneNumber { get; set; } = null!;
	}
}
