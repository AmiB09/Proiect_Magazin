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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public DetailsModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

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
    }
}
