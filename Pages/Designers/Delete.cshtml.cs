using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin.Data;
using Proiect_Magazin.Models;

namespace Proiect_Magazin.Pages.Designers
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public DeleteModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Designer Designer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Designer == null)
            {
                return NotFound();
            }

            var designer = await _context.Designer.FirstOrDefaultAsync(m => m.ID == id);

            if (designer == null)
            {
                return NotFound();
            }
            else 
            {
                Designer = designer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Designer == null)
            {
                return NotFound();
            }
            var designer = await _context.Designer.FindAsync(id);

            if (designer != null)
            {
                Designer = designer;
                _context.Designer.Remove(Designer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
