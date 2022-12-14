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
        [StringLength(150, MinimumLength=3)]
        [Required]
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public int? DesignerID { get; set; }
        public Designer? Designer { get; set; }
        public int? SizeID { get; set; }
        public Size? Size { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
        public int? CollectionID { get; set; }
        public Collection? Collection { get; set; }
        public ICollection<ClothMaterial>? ClothMaterials { get; set; }
    }
}
