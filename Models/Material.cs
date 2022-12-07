namespace Proiect_Magazin.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string MaterialName { get; set; }
        public ICollection<ClothMaterial>? ClothMaterials { get; set; }
    }
}
