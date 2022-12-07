using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin.Data;
using Proiect_Magazin.Models;

namespace Proiect_Magazin.Pages.Clothes
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public IndexModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        public IList<Cloth> Cloth { get;set; } = default!;
        public ClothData ClothD { get; set; }
        public int ClothID { get; set; }
        public int MaterialID { get; set; }
        public string NameSort { get; set; }
        // public string DesignerSort { get; set; }
        // public string CollectionSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? materialID, string sortOrder, string searchString)

        {
            ClothD = new ClothData();
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //  DesignerSort = String.IsNullOrEmpty(sortOrder) ? "designer_desc" : "";
            //  CollectionSort = String.IsNullOrEmpty(sortOrder) ? "collection_desc" : "";
            CurrentFilter = searchString;

            ClothD.Clothes = await _context.Cloth
                    .Include(c => c.Category)
                    .Include(c => c.Collection)
                    .Include(c => c.Size)
                    .Include(c => c.Designer)
                    .Include(c => c.ClothMaterials)
                    .ThenInclude(b => b.Material)
                    .AsNoTracking()
                    .OrderBy(b => b.Name)
                    .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                ClothD.Clothes = ClothD.Clothes.Where(s=>s.Name.Contains(searchString));
            }

            if (id != null)
            {
                ClothID = id.Value;
                Cloth cloth = ClothD.Clothes
                .Where(i => i.ID == id.Value).Single();
                ClothD.Materials = cloth.ClothMaterials.Select(s => s.Material);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    ClothD.Clothes = ClothD.Clothes.OrderByDescending(s =>
                   s.Name);
                    break;

            }

        }
    }
}
