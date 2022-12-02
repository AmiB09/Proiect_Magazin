namespace Proiect_Magazin.Models
{
    public class Size
    {
        public int ID { get; set; }
        public string SizeName { get; set; }
        public ICollection<Cloth>? Clothes { get; set; }
    }
}
