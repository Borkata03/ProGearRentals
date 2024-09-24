using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Infrastructure.Data.Models
{

    [Comment("Equipment Review")]
    public class Review
    {
        [Key]
        [Comment("Review Identifier")]
        public int Id { get; set; }


        [Required]
        [Comment("Rating given by the user (1 to 5)")]
        [Range(1,5)]

        public int Rating { get; set; }

        [Required]
        [Comment("Review comment")]
        [MaxLength(500)]
        public string Comment { get; set; } = string.Empty;

        [Required]
        [Comment("Equipment Identifier")]
        public int EquipmentId { get; set; }

        [Required]
        [Comment("User Identifier Reviewer")]
        public string ReviewerId { get; set; } = string.Empty;


        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; } = null!;

        [ForeignKey(nameof(ReviewerId))]
        public ApplicationUser Reviewer { get; set; } = null!;






    }
}
