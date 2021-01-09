using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dobie_Bianca_Proiect_Tel.Data;
using Dobie_Bianca_Proiect_Tel.Models;

namespace Dobie_Bianca_Proiect_Tel.Pages.Phones
{
    public class EditModel : PhoneCategoriesPageModel
    {
        private readonly Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext _context;

        public EditModel(Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Phone Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone
  .Include(b => b.Seller)
  .Include(b => b.PhoneCategories).ThenInclude(b => b.Category)
  .AsNoTracking()
  .FirstOrDefaultAsync(m => m.ID == id);

            if (Phone == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Phone);
            ViewData["SellerID"] = new SelectList(_context.Set<Seller>(), "ID", "SellerName");
            return Page();
        }
       
        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var phoneToUpdate = await _context.Phone
            .Include(i => i.Seller)
            .Include(i => i.PhoneCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (phoneToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Phone>(
            phoneToUpdate,
            "Phone",
            i => i.Brand, i => i.Name,
            i => i.Price, i => i.PublishingDate, i => i.Seller))
            {
                UpdatePhoneCategories(_context, selectedCategories, phoneToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdatePhoneCategories(_context, selectedCategories, phoneToUpdate);
            PopulateAssignedCategoryData(_context, phoneToUpdate);
            return Page();
        }
    }


}
