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

namespace Proiect_Magazin.Pages.Collections
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public IndexModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        public IList<Collection> Collection { get;set; } = default!;
        public CollectionIndexData CollectionData { get; set; }
        public int CollectionID { get; set; }
        public int ClothID { get; set; }
        public async Task OnGetAsync(int? id, int? clothID)
        {
            CollectionData = new CollectionIndexData();
            CollectionData.Collections = await _context.Collection
            .Include(i => i.Clothes)
            .ThenInclude(c => c.Category)
            .OrderBy(i => i.CollectionName)
            .ToListAsync();
            if (id != null)
            {
                CollectionID = id.Value;
                Collection collection = CollectionData.Collections
                .Where(i => i.ID == id.Value).Single();
                CollectionData.Clothes = collection.Clothes;
            }
        }
      //  public async Task OnGetAsync()
       // {
        //    if (_context.Collection != null)
         //   {
         //       Collection = await _context.Collection.ToListAsync();
          //  }
        //}
    }
}
