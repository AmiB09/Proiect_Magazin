using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin.Data;
using Proiect_Magazin.Models;

namespace Proiect_Magazin.Pages.Clothes
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public DetailsModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

      public Cloth Cloth { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cloth == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloth.FirstOrDefaultAsync(m => m.ID == id);
            if (cloth == null)
            {
                return NotFound();
            }
            else 
            {
                Cloth = cloth;
            }
            return Page();
        }
    }
}
