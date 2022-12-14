using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    public class EditModel : ClothMaterialsPageModel

    {
        private readonly Proiect_Magazin.Data.Proiect_MagazinContext _context;

        public EditModel(Proiect_Magazin.Data.Proiect_MagazinContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cloth Cloth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            Cloth =  await _context.Cloth
                .Include(c => c.Designer)
                .Include(c => c.Size)
                .Include(c => c.Category)
                .Include(c => c.Collection)
                .Include(b => b.ClothMaterials).ThenInclude(b => b.Material)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Cloth == null)
            {
                return NotFound();
            }
           

            PopulateAssignedMaterialData(_context, Cloth);
            var designerList = _context.Designer.Select(x => new
            {
                x.ID,
                DesignerName = x.LastName + " " + x.FirstName
            });
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID",
"CategoryName");
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID",
"DesignerName");
            ViewData["SizeID"] = new SelectList(_context.Set<Size>(), "ID",
"SizeName");
            ViewData["CollectionID"] = new SelectList(_context.Set<Collection>(), "ID",
"CollectionName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedMaterials)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothToUpdate = await _context.Cloth
            .Include(c => c.Designer)
                .Include(c => c.Size)
                .Include(c => c.Category)
                .Include(c => c.Collection)
                .Include(c => c.ClothMaterials).ThenInclude(c => c.Material)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (clothToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Cloth>(
            clothToUpdate,
            "Cloth",
            c => c.Name, c => c.CategoryID,
            c => c.Price, c => c.DesignerID, c => c.SizeID,c =>c.CollectionID))
            {
                UpdateClothMaterials(_context, selectedMaterials, clothToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdateClothMaterials(_context, selectedMaterials, clothToUpdate);
            PopulateAssignedMaterialData(_context, clothToUpdate);
            return Page();
        }
    }

}

