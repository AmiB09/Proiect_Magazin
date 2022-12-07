using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin.Data;
using Proiect_Magazin.Models;
using Proiect_Magazin.Models.ViewModels;

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
        public DesignerIndexData DesignerData { get; set; }
        public int DesignerID { get; set; }
        public int ClothID { get; set; }
        public async Task OnGetAsync(int? id, int? clothID)
        {
            DesignerData = new DesignerIndexData();
            DesignerData.Designers = await _context.Designer
            .Include(i => i.Clothes)
            .ThenInclude(c => c.Collection)
            .OrderBy(i => i.FirstName)
            .ToListAsync();
            if (id != null)
            {
                DesignerID = id.Value;
                Designer designer = DesignerData.Designers
                .Where(i => i.ID == id.Value).Single();
                DesignerData.Clothes = designer.Clothes;
            }
        }

        //  public async Task OnGetAsync()
        // {
        //    if (_context.Designer != null)
        //   {
        //        Designer = await _context.Designer.ToListAsync();
        //    }
        // }
    }
}
