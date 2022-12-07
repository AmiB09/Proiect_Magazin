namespace Proiect_Magazin.Models
{
    public class ClothMaterial
    {
        public int ID { get; set; }
        public int ClothID { get; set; }
        public Cloth Cloth { get; set; }
        public int MaterialID { get; set; }
        public Material Material { get; set; }
    }
}
