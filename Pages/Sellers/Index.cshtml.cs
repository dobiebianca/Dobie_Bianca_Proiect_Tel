using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobie_Bianca_Proiect_Tel.Data;
using Dobie_Bianca_Proiect_Tel.Models;

namespace Dobie_Bianca_Proiect_Tel.Pages.Sellers
{
    public class IndexModel : PageModel
    {
        private readonly Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext _context;

        public IndexModel(Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext context)
        {
            _context = context;
        }

        public IList<Seller> Seller { get;set; }

        public async Task OnGetAsync()
        {
            Seller = await _context.Seller.ToListAsync();
        }
    }
}
