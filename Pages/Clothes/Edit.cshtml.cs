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

namespace Proiect_Magazin.Pages.Clothes
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public EditModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cloth Cloth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cloth == null)
            {
                return NotFound();
            }

            var cloth =  await _context.Cloth.FirstOrDefaultAsync(m => m.ID == id);
            if (cloth == null)
            {
                return NotFound();
            }
            Cloth = cloth;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cloth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothExists(Cloth.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClothExists(int id)
        {
          return _context.Cloth.Any(e => e.ID == id);
        }
    }
}
