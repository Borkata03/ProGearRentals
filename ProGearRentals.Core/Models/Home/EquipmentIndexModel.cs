using ProGearRentals.Core.Contracts;

namespace ProGearRentals.Core.Models.Home
{
    public  class EquipmentIndexModel : IEquipmentModel
    {
        public int Id { get; set; }

        public string Title { get; set; } =  string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Imageurl { get; set; } = string.Empty;

    }
}
