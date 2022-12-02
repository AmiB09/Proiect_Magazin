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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public IndexModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        public IList<Size> Size { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Size != null)
            {
                Size = await _context.Size.ToListAsync();
            }
        }
    }
}
