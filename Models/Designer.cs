namespace Proiect_Magazin.Models
{
    public class Designer
    {
        public int ID { get; set; }
        public string DesignerName { get; set; }
        public ICollection<Cloth>? Clothes { get; set; }
    }
}
