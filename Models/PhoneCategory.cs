using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobie_Bianca_Proiect_Tel.Models
{
    public class PhoneCategory
    {
        public int ID { get; set; }
        public int PhoneID { get; set; }
        public Phone Phone { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
