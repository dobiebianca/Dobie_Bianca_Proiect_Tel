using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobie_Bianca_Proiect_Tel.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<PhoneCategory> PhoneCategories { get; set; }
    }
}
