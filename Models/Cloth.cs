using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Security.Policy;

namespace Proiect_Magazin.Models
{
    public class Cloth
    {
        public int ID { get; set; }
        [Display(Name = "Cloth name")]
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public int? DesignerID { get; set; }
        public Designer? Designer { get; set; }
        public int? SizeID { get; set; }
        public Size? Size { get; set; }
        public decimal Price { get; set; }
        public int? CollectionID { get; set; }
        public Collection? Collection { get; set; }
    }
}
