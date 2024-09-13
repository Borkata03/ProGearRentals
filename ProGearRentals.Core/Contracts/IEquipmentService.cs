using ProGearRentals.Core.Enumeration;
using ProGearRentals.Core.Models.Equipment;
using ProGearRentals.Core.Models.Home;
using ProGearRentals.Infrastructure.Data.Models;

namespace ProGearRentals.Core.Contracts
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentIndexModel>> LastThreeEquipmentsAsync();

        Task<IEnumerable<EquipmentCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistAsync(int categoryId);

        Task<int> CreateAsync(EquipmentFormModel model, int agentId);

        Task<EquipmentQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            EquipmentSorting sorting = EquipmentSorting.Newest,
            int currentpage = 1,
            int equipmentPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<EquipmentServiceModel>> AllEquipmentsByAgentId(int agentId);   

        Task<IEnumerable<EquipmentServiceModel>> AllEquipmentsByUserId(string userId);


        Task<bool> ExistAsync(int id);

        Task<EquipmentDetailsServiceModel> EqipmentDetailsByIdAsync(int id);
    }
}
