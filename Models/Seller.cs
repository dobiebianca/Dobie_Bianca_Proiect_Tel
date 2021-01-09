using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobie_Bianca_Proiect_Tel.Models
{
    public class Seller
    {
        public int ID { get; set; }
        public string SellerName { get; set; }
        public ICollection<Phone> Phones { get; set; }
        
    }
}
