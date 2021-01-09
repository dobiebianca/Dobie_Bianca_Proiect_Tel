using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dobie_Bianca_Proiect_Tel.Data;
using Dobie_Bianca_Proiect_Tel.Models;

namespace Dobie_Bianca_Proiect_Tel.Pages.Phones
{
    public class CreateModel : PhoneCategoriesPageModel
    {
        private readonly Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext _context;

        public CreateModel(Dobie_Bianca_Proiect_Tel.Data.Dobie_Bianca_Proiect_TelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SellerID"] = new SelectList(_context.Set<Seller>(), "ID", "SellerName");
            var phone = new Phone();
            phone.PhoneCategories = new List<PhoneCategory>();
            PopulateAssignedCategoryData(_context, phone);
            return Page();
        }

        [BindProperty]
        public Phone Phone { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newPhone = new Phone();
            if (selectedCategories != null)
            {
                newPhone.PhoneCategories = new List<PhoneCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new PhoneCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newPhone.PhoneCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Phone>(
            newPhone,
            "Phone",
            i => i.Brand, i => i.Name,
            i => i.Price, i => i.PublishingDate, i => i.SellerID))
            {
                _context.Phone.Add(newPhone);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newPhone);
            return Page();
        }
    }
}