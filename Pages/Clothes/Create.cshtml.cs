using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Magazin.Data;
using Proiect_Magazin.Models;

namespace Proiect_Magazin.Pages.Clothes
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
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID",
"CategoryName");
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID",
"DesignerName");
            ViewData["SizeID"] = new SelectList(_context.Set<Size>(), "ID",
"SizeName");
            ViewData["CollectionID"] = new SelectList(_context.Set<Collection>(), "ID",
"CollectionName");
            return Page();
        }

        [BindProperty]
        public Cloth Cloth { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cloth.Add(Cloth);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
