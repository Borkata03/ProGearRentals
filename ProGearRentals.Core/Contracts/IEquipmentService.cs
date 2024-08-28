using ProGearRentals.Core.Models.Home;

namespace ProGearRentals.Core.Contracts
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentIndexModel>> LastThreeEquipments();
    }
}
