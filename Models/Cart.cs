using System.Diagnostics.Metrics;

namespace Proiect_Magazin.Models
{
    public class Cart
    {

        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? ClothID { get; set; }
        public Cloth? Cloth { get; set; }
   
    }
}
