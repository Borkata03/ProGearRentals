using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ProGearRentals.Infrastructure.Constants.DataConstants;

namespace ProGearRentals.Infrastructure.Data.Models
{
    [Comment("Equipment category")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

      
        [Required]
        [MaxLength(NameLength)]
        [Comment("Category Name")]
        public string Name { get; set; } = string.Empty;


        [Comment("Collection of Equipment")]
        public List<Equipment> Equipments { get; set; } = new List<Equipment>();

        

    }
}
