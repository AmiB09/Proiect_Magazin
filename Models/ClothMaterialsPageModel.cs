using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Magazin.Data;
using Proiect_Magazin.Migrations;

namespace Proiect_Magazin.Models
{
    public class ClothMaterialsPageModel : PageModel
    {
        public List<AssignedMaterialData> AssignedMaterialDataList;
        public void PopulateAssignedMaterialData(Proiect_MagazinContext context, Cloth cloth)
        {
            var allMaterials = context.Material;
            var clothMaterials = new HashSet<int>(
            cloth.ClothMaterials.Select(c => c.MaterialID)); //
            AssignedMaterialDataList = new List<AssignedMaterialData>();
            foreach (var mat in allMaterials)
            {
                AssignedMaterialDataList.Add(new AssignedMaterialData
                {
                    MaterialID = mat.ID,
                    Name = mat.MaterialName,
                    Assigned = clothMaterials.Contains(mat.ID)
                });
            }
        }
        public void UpdateClothMaterials(Proiect_MagazinContext context, string[] selectedMaterials, Cloth clothToUpdate)
        {
            if (selectedMaterials == null)
            {
                clothToUpdate.ClothMaterials = new List<ClothMaterial>();
                return;
            }
            var selectedMaterialsHS = new HashSet<string>(selectedMaterials);
            var clothMaterials = new HashSet<int>
            (clothToUpdate.ClothMaterials.Select(c => c.Material.ID));
            foreach (var mat in context.Material)
            {
                if (selectedMaterialsHS.Contains(mat.ID.ToString()))
                {
                    if (!clothMaterials.Contains(mat.ID))
                    {
                        clothToUpdate.ClothMaterials.Add(
                        new ClothMaterial
                        {
                            ClothID = clothToUpdate.ID,
                            MaterialID = mat.ID
                        });
                    }
                }
                else
                {
                    if (clothMaterials.Contains(mat.ID))
                    {
                        ClothMaterial courseToRemove
                        = clothToUpdate
                            .ClothMaterials
                            .SingleOrDefault(i => i.MaterialID == mat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
