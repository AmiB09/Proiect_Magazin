namespace Proiect_Magazin.Models
{
    public class ClothData
    {
        public IEnumerable<Cloth> Clothes { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<ClothMaterial> ClothMaterials { get; set; }
    }
}
