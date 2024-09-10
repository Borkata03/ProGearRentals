using ProGearRentals.Core.Models.Equipment;
using ProGearRentals.Core.Models.Home;

namespace ProGearRentals.Core.Contracts
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentIndexModel>> LastThreeEquipmentsAsync();

        Task<IEnumerable<EquipmentCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistAsync(int categoryId);

        Task<int> CreateAsync(EquipmentFormModel model, int agentId);
    }
}
