using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Models.Review
{
    public class AllReviewQueryModel
    {
        public int Id {  get; set; }

        public string Name { get; set; } = null!;

        public string Comment { get; set; } = null!;   

        public int Rating { get; set; }
    }
}
