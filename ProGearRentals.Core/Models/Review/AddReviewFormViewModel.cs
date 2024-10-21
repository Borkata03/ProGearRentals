using Microsoft.EntityFrameworkCore;
using ProGearRentals.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Models.Review
{
    public class AddReviewFormViewModel
    {

        public int Id { get; set; }


        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; } = string.Empty;

        [Required]
    
        public int EquipmentId { get; set; }

        [Required]
        public string ReviewerId { get; set; } = string.Empty;


    }
}
