using System.Security.Policy;

namespace Proiect_Magazin.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Cloth> Clothes { get; set; }

    }
}
