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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public IndexModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        public IList<Designer> Designer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Designer != null)
            {
                Designer = await _context.Designer.ToListAsync();
            }
        }
    }
}
