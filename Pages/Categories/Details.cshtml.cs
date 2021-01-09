using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dobie_Bianca_Proiect_Tel.Data;
using Dobie_Bianca_Proiect_Tel.Models;

namespace Dobie_Bianca_Proiect_Tel.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext _context;

        public DetailsModel(Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
