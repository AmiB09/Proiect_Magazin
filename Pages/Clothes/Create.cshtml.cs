using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin.Data;
using Proiect_Magazin.Models;

namespace Proiect_Magazin.Pages.Clothes
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ClothMaterialsPageModel
    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public CreateModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var designerList = _context.Designer.Select(x => new
            {
                x.ID,
                DesignerName= x.LastName + " " + x.FirstName
            });

            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID","CategoryName");
            ViewData["FirstName"] = new SelectList(_context.Set<Designer>(), "ID", "FirstName");
            ViewData["LastName"] = new SelectList(_context.Set<Designer>(), "ID", "LastName");
            ViewData["SizeID"] = new SelectList(_context.Set<Size>(), "ID","SizeName");
            ViewData["CollectionID"] = new SelectList(_context.Set<Collection>(), "ID","CollectionName");

            var cloth = new Cloth();
            cloth.ClothMaterials = new List<ClothMaterial>();
            PopulateAssignedMaterialData(_context, cloth);

            return Page();
        }

        [BindProperty]
        public Cloth Cloth { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedMaterials)
        {
            var newCloth = new Cloth();
            if (selectedMaterials != null)
            {
                newCloth.ClothMaterials = new List<ClothMaterial>();
                foreach (var cat in selectedMaterials)
                {
                    var catToAdd = new ClothMaterial
                    {
                        MaterialID = int.Parse(cat)
                    };
                    newCloth.ClothMaterials.Add(catToAdd);
                }
            }
            Cloth.ClothMaterials = newCloth.ClothMaterials;
            _context.Cloth.Add(Cloth);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedMaterialData(_context, newCloth);
            return Page();
        }

    }
}

