using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobie_Bianca_Proiect_Tel.Models
{
    public class PhoneData
    {
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<PhoneCategory> PhoneCategories { get; set; }
    }
}
