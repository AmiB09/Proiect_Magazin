using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Magazin.Models
{
    public class Designer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Full Name Designer")]
        public string DesignerName 
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Cloth>? Clothes { get; set; }
    }
}
