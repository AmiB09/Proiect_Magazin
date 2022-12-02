using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin.Data;
using Proiect_Magazin.Models;

namespace Proiect_Magazin.Pages.Sizes
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public DeleteModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Size Size { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Size == null)
            {
                return NotFound();
            }

            var size = await _context.Size.FirstOrDefaultAsync(m => m.ID == id);

            if (size == null)
            {
                return NotFound();
            }
            else 
            {
                Size = size;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Size == null)
            {
                return NotFound();
            }
            var size = await _context.Size.FindAsync(id);

            if (size != null)
            {
                Size = size;
                _context.Size.Remove(Size);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
