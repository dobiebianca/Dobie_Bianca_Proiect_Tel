using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dobie_Bianca_Proiect_Tel.Models
{
    public class Phone
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Phone Name")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele Brand-ului trebuie sa fie de forma 'Nume'"), Required,
StringLength(50, MinimumLength = 3)]
        public string Brand { get; set; }
        
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
       
        public DateTime PublishingDate { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; }
        public ICollection<PhoneCategory> PhoneCategories { get; set; }
  

    }
}
