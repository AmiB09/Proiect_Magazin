namespace Proiect_Magazin.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Cloth>? Clothes { get; set; }
    }
}
