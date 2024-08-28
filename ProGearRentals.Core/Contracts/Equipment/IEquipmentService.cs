using ProGearRentals.Core.Models.Home;

namespace ProGearRentals.Core.Contracts.Equipment
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentIndexModel>> LastThreeEquipments();
    }
}
