using ProGearRentals.Core.Contracts;
using ProGearRentals.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IEquipmentModel equipment)
        {
            string info =  equipment.Title.Replace(" ", "-") + GetDescription(equipment.Description);
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]",string.Empty);

            return info;
        }

        private static string GetDescription(string description)
        {
            description = string.Join("-", description.Split(" ").Take(3));


            return description;
        }
    }
}
 