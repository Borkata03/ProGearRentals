using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Infrastructure.Data.Models
{
    [Comment("Equipment reservation record")]
    public class Reservation
    {
        [Key]
        [Comment("Reservation Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Start date of the reservation period")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("End date of the reservation period")]
        public DateTime EndDate { get; set; }

        [Required]
        [Comment("Equipment Identifier")]
        public int EquipmentId { get; set; }

        [Required]
        [Comment("User Identifier who made the reservation")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}

