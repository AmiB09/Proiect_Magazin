using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin.Data;
using Proiect_Magazin.Models;

namespace Proiect_Magazin.Pages.Carts
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public CreateModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var clothList = _context.Cloth
                .Include(b => b.Designer)
                .Include(b => b.Size)
                .Include(b => b.Collection)
 .Select(x => new
 {
     x.ID,
    ItemFullName = x.Name + " - " + x.Designer.LastName + " " +
x.Designer.FirstName + " - " +x.Size.SizeName + " - " +x.Collection.CollectionName
 });

            ViewData["ClothID"] = new SelectList(clothList, "ID", "ItemFullName");
        ViewData["UserID"] = new SelectList(_context.User, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Cart Cart { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cart.Add(Cart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
