namespace Proiect_Magazin.Models
{
    public class Collection
    {
        public int ID { get; set; }
        public string CollectionName { get; set; }
        public ICollection<Cloth>? Clothes { get; set; }
        //public object Designer { get; set; }
    }
}
