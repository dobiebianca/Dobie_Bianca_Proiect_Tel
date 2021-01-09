using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobie_Bianca_Proiect_Tel.Data;
using Dobie_Bianca_Proiect_Tel.Models;

namespace Dobie_Bianca_Proiect_Tel.Pages.Phones
{
    public class IndexModel : PageModel
    {
        private readonly Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext _context;

        public IndexModel(Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext context)
        {
            _context = context;
        }

        public IList<Phone> Phone { get;set; }

        public PhoneData PhoneD { get; set; }
        public int PhoneID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PhoneD = new PhoneData();

            PhoneD.Phones = await _context.Phone
            .Include(b => b.Seller)
            .Include(b => b.PhoneCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Brand)
            .ToListAsync();
            if (id != null)
            {
                PhoneID = id.Value;
                Phone phone = PhoneD.Phones
                .Where(i => i.ID == id.Value).Single();
                PhoneD.Categories = phone.PhoneCategories.Select(s => s.Category);
            }
        }

    }
}
